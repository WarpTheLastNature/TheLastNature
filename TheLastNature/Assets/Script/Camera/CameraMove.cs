 using UnityEngine;
using System.Collections;

public class CameraMove : Actor
{
	float offsetX;
    float fLastPositionX;
    public float fSmothMoveGuide = 10.0f;

    public bool bCameraMoving = true;
    public GameObject camera_left_pivot;
    public GameObject camera_right_pivot;

    public GameObject left_boundary;
    public GameObject right_boundary;

    bool bCoroutine = false;

   private Vector3 smoothTime = new Vector3(0.0f, 0.0f, 0.0f);
   public float maxSpeed = 1.0f;

    void Start()
    {
        camera_left_pivot  = GameObject.Find("CameraLeftPivot");
        camera_right_pivot = GameObject.Find("CameraRightPivot");

        left_boundary  = GameObject.Find("LeftBoundary");
        right_boundary = GameObject.Find("RightBoundary");


        //float lx = left_boundary.transform.position.x;
        //float rx = right_boundary.transform.position.x;
        //fPivotDis = lx - rx;

        v3 = transform.position;
        v3.x = gameManager.Player.transform.position.x;
        transform.position = v3;

    
        offsetX = transform.position.x - gameManager.Player.transform.position.x;
        fLastPositionX = 0.0f;

    }

	void LateUpdate()
	{
        v3 = transform.position;
        fLastPositionX = v3.x;
        v3.x = gameManager.Player.transform.position.x + offsetX;

        transform.position = Vector3.SmoothDamp(transform.position, v3, ref smoothTime, maxSpeed);


       // transform.position = v3;

        if (false == bCameraMoving) return;
            
        if (camera_right_pivot.transform.position.x >= right_boundary.transform.position.x)
        {
            v3.x = fLastPositionX;
            transform.position = v3;
        }

        if (camera_left_pivot.transform.position.x <= left_boundary.transform.position.x)
        {
            v3.x = fLastPositionX;
            transform.position = v3;
        }
        

    }

    IEnumerator SmothMove()
    {
        bCoroutine = true;

        float fLerp = 0.0f;
        float fStart = fLastPositionX;

        while (fLerp <= 1.0f)
        {
            float dist = Mathf.Lerp(fStart, v3.x, fLerp);
            v3.x = dist;
            print(dist);
            transform.position = v3;
            fLerp += 0.1f;
            yield return new WaitForSeconds(1f);
        }

        bCoroutine = false;
        yield return null;
    }
}

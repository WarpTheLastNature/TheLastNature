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

        float distance = Mathf.Abs(fLastPositionX - v3.x);
        if(distance > fSmothMoveGuide)
            StartCoroutine("SmothMove");

        transform.position = v3;

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
        float fLerp = 0.0f;
        float fStart = fLastPositionX;
        float fEnd = v3.x;

        while (fLerp <= 1.0f)
        {
            v3.x = Mathf.Lerp(fStart, fEnd, fLerp);
            transform.position = v3;
            fLerp += 0.01f;
        }
        yield return null;
    }
}

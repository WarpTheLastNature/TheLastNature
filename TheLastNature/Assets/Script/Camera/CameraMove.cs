 using UnityEngine;
using System.Collections;

public class CameraMove : Actor
{
	float offsetX;
    float fLastPositionX;

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
}

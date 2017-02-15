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

   private Vector3 smoothTime = new Vector3(0.0f, 0.0f, 0.0f);
   public float maxSpeed = 1.0f;

    public int CameraTriggerNumber;

    CameraLockTrigger cameraLockTrigger;

    void Start()
    {
        camera_left_pivot  = transform.FindChild(Define.NAME_CAMERA_LEFT_PIVOT).gameObject;
        camera_right_pivot = transform.FindChild(Define.NAME_CAMERA_RIGHT_PIVOT).gameObject;// GameObject.Find("CameraRightPivot");

        left_boundary  = GameObject.Find(Define.NAME_LEFT_LIMIT_BOUNDARY);
        right_boundary = GameObject.Find(Define.NAME_RIGHT_LIMIT_BOUNDARY);

        cameraLockTrigger = GetComponent<CameraLockTrigger>();

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
        
        else
            transform.position = Vector3.SmoothDamp(transform.position, v3, ref smoothTime, maxSpeed);
    }

   
}

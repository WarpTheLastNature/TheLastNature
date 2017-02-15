using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockMove : Actor
{
    public GameObject camera_left_pivot;
    public GameObject camera_right_pivot;

    public GameObject left_boundary;
    public GameObject right_boundary;

    private void Start()
    {
        camera_left_pivot = transform.FindChild(Define.NAME_CAMERA_LEFT_PIVOT).gameObject;
        camera_right_pivot = transform.FindChild(Define.NAME_CAMERA_RIGHT_PIVOT).gameObject;// GameObject.Find("CameraRightPivot");

        left_boundary = GameObject.Find(Define.NAME_LEFT_LIMIT_BOUNDARY);
        right_boundary = GameObject.Find(Define.NAME_RIGHT_LIMIT_BOUNDARY);

    }

    private void LateUpdate()
    {
		
	}
}

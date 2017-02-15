using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraLockTrigger : Actor
{

   public GameObject[] Camera_Left_Object;
   public GameObject[] Camera_Right_Object;

   int LeftTriggerCount = 0;
   int RightTriggerCount = 0;

    public GameObject camera_left_pivot;
    public GameObject camera_right_pivot;


    public override void Awake()
    {
        base.Awake();
        gameManager.CameraLockTrigger = GetComponent<CameraLockTrigger>();
    }


    void Start ()
    {
        GameObject[] tag_find_objects = GameObject.FindGameObjectsWithTag(Define.TAG_CAMERA_TRIGGER);

       List<GameObject> list_object = new List<GameObject>();
        foreach (GameObject g_obj in tag_find_objects)
        {
            list_object.Add(g_obj);
        }
        list_object.Sort(compare_object);

        int tag_size = list_object.Count;
        tag_size /= 2;

        Camera_Right_Object = new GameObject[tag_size];
        Camera_Left_Object = new GameObject[tag_size];

        int left_index= 0;
        int right_index = 0;

        foreach (GameObject g_obj in list_object)
        {
            if (-1 ==  g_obj.name.IndexOf("left"))   // right
            {
                Camera_Right_Object[right_index++] = g_obj;
            }
            else                                    // left
            {
                Camera_Left_Object[left_index++] = g_obj;
            }
        }


        camera_left_pivot  = GameObject.Find(Define.NAME_LEFT_LIMIT_BOUNDARY).gameObject;
        camera_right_pivot = GameObject.Find(Define.NAME_RIGHT_LIMIT_BOUNDARY).gameObject;// GameObject.Find("CameraRightPivot");

        LeftTriggerCount++;
        RightTriggerCount++;
    }

    public void StartLeftTrigger()
    {
        if (LeftTriggerCount > Camera_Left_Object.Length)
        {
            LeftTriggerCount = (Camera_Left_Object.Length - 1);
        }

        v3 = Camera_Left_Object[LeftTriggerCount].transform.position;
        v3.y = 5.23f;

        camera_left_pivot.transform.position = v3;
        LeftTriggerCount++;
    }

    public void StartRightTrigger()
    {
        if(RightTriggerCount > Camera_Right_Object.Length)
        {
            RightTriggerCount = (Camera_Right_Object.Length - 1);
        }

        v3 = Camera_Right_Object[RightTriggerCount].transform.position;
        v3.y = 5.23f;

        camera_right_pivot.transform.position = v3;
        RightTriggerCount++;
    }

    public static int compare_object(GameObject left, GameObject right)
    {
        return left.gameObject.name.CompareTo(right.gameObject.name);
    }

}

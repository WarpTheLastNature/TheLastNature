using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_CameraM : MonoBehaviour {

    float fspeed;
    bool asdf=false;

    bool moveCheck = false;//얘 한번만 움직여야하는데 어떻게하지 일단 움직였는지안움직였는지 확인하는애를 만들었다.


    Vector3 des_position;

    // Use this for initialization
    void Start () {

        fspeed = 1.0f;
        des_position= transform.position;
        des_position.x+=5;
    }
	
	// Update is called once per frame
	void Update () {
        if (asdf)
        {
            transform.Translate((0.8f)*fspeed*Time.deltaTime, 0, 0);
            if (des_position.x < transform.position.x)
            {
                asdf = false;
            }
        }

    }
    void B_Cameramove(float qfspeed)
    {
        if (!moveCheck)
        {
            fspeed = qfspeed;
            asdf = true;
            moveCheck = true;

        }
    }



}

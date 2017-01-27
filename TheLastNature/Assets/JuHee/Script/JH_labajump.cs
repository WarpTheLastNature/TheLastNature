using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_labajump : MonoBehaviour {
    float fRange;
    float fNowPivot;
    float fSpeed;
    bool B_Jump=false;

    // Use this for initialization
    void Start () {
        // Update is called once per frame
        fSpeed = 5.0f;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            B_Jump = true;
        }




    }

    //물리처리는 여기가좋대....
    void FixedUpdate()
    {

        if (B_Jump)
        {

            transform.Translate(0, fSpeed * Time.deltaTime, 0.0f);
        }


    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        B_Jump = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        B_Jump = false;
    }




}
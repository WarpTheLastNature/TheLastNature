
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_RigidGravityO : MonoBehaviour
{

    bool b_Ladder;
    Rigidbody2D rigid;
    // Use this for initialization
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();

        //        rigid.gravityScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (b_Ladder)
        {
            rigid.gravityScale = 0.0f;
            rigid.velocity = new Vector2(0.0f, 0.0f);
        }

        else
        {
            rigid.gravityScale = 1.0f;

        }

    }

    public void RigidGraviyB(bool q)
    {
        b_Ladder = q;
    }

}

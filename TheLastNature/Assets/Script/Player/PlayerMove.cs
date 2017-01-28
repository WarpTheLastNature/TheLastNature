using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : ActorBehaviour {

    //Player Speed
    public float fSpeed = 5.0f;

    //Player Jump
    //public float fJumpPower     = 7.0f;
    //public float fJumpDuringTime = 7.0f;
    public float fJumpDownPower = 950.0f;

    //Ladder
    bool bLadder = false;
    float fLastGrivateSclae = 0.0f;


    //private ----------
    Vector2 veolcity;
    //float fJump;
    //bool bIsJump;
    bool bStandingGround;

    public override void Awake()
    {
        base.Awake();
        rigid2D.gravityScale = 9.8f;// fJumpDownPower;
        gameManager.Player = gameObject;
        bStandingGround = true;
    }

    void Start() { Init(); }

    void Init()
    {
        veolcity = new Vector2(0.0f, 0.0f);
        //fJump = 0.0f;
        //bIsJump = false;
        bLadder = false;
        rigid2D.gravityScale = 9.8f;
        fLastGrivateSclae = rigid2D.gravityScale;
    }



    void FixedUpdate()
    {
        gameManager.Player = gameObject;

        if (Input.GetKey(KeyCode.LeftArrow))  veolcity.x = -fSpeed;
        if (Input.GetKey(KeyCode.RightArrow)) veolcity.x =  fSpeed;


       // if (Input.GetKey(KeyCode.DownArrow))   veolcity.y = -fSpeed;
       // if (Input.GetKey(KeyCode.UpArrow))     veolcity.y = fSpeed;




        if (bStandingGround & Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(Vector2.up * fJumpDownPower);
            //bIsJump = true;
            bStandingGround = false;
        }

        Jump();

        if (bLadder)
        {
            fLastGrivateSclae = rigid2D.gravityScale;
            rigid2D.gravityScale = 0.0f;
        }
        else
        {
            rigid2D.gravityScale = fLastGrivateSclae;
        }

        // Moving
        fastTransform.Translate(veolcity * Time.deltaTime);
        veolcity.x = 0.0f; veolcity.y = 0.0f;

    }

    void Jump()
    {
        //if(bIsJump == false)
        //{
        //    if(bStandingGround)
        //    {
        //        rigid.gravityScale = 9.8f;
        //    }
        //    else
        //    {
        //        rigid.gravityScale = 1.0f;
        //    }
        //}
        //
        //if (fJump == 0)
        //{
        //    bIsJump = false;
        //    return;
        //}
        //
        //fJump--;
        //veolcity.y = fJump;

    }

    public void SetStandGround(bool flag) { bStandingGround = flag; }
    public void SetLadder(bool flag) { bLadder = flag; }
}

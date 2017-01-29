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

    public Vector3 LayPosition = new Vector3(0.0f, 0.0f, 0.0f);
    public LayerMask LayerMask = Define.LAYER_INT_BOX;
    public float Layerdistance = 2.0f;

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

        if (Input.GetKey(KeyCode.LeftArrow))  veolcity.x = -fSpeed;
        if (Input.GetKey(KeyCode.RightArrow)) veolcity.x =  fSpeed;


        RaycastHit2D hit = Physics2D.Raycast((transform.position + LayPosition), Vector2.down * transform.localScale.x, Layerdistance, LayerMask);
        if (hit.collider != null)
        {

            if (Input.GetKeyDown(KeyCode.Space) & bStandingGround)
            {
                rigid2D.AddForce(Vector2.up * fJumpDownPower);
                bStandingGround = false;

                fLastGrivateSclae = rigid2D.gravityScale;
                rigid2D.gravityScale = 0.0f;
            }
           if(hit.collider.tag == Define.TAG_MOVING_FLOOR)
            {
                MovingFloor script = hit.collider.gameObject.GetComponent<MovingFloor>();
                fastTransform.Translate(script.GetSpeed());
            }
        }
        else
        {
            bStandingGround = true;
            rigid2D.gravityScale = fLastGrivateSclae;

        }


        fastTransform.Translate(veolcity * Time.deltaTime);
        veolcity.x = 0.0f; veolcity.y = 0.0f;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine((transform.position + LayPosition), (Vector2)(transform.position + LayPosition) + Vector2.down * transform.localScale.x * Layerdistance);
    }
}

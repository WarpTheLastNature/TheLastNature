using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : ActorBehaviour
{
    //public
    public Vector2 offset = new Vector2(0.0f, 0.2f);
    public float fColiderExtendScale = 1.5f;

    //private
    private float fHeight;
    private bool  bTouch    = false;
    private float offsetX   = 0.0f;
    private int   offset_dir = 1;
    private float finit_Height = 0.0f;

    //Component
    BoxCollider2D boxColider2D;
    Vector2 coliderSize = new Vector2(1.0f, 1.0f);
    Animator PlayerAnimator;
    PlayerObstacle playerObstacle;

    public override void Awake()
    {
        base.Awake();
        boxColider2D = GetComponent<BoxCollider2D>();
        coliderSize = boxColider2D.size;
        v2 = coliderSize;
    }

    void Start()
    {
        fHeight = gameObject.transform.position.y;
        playerObstacle = gameManager.Player.GetComponent<PlayerObstacle>();
        PlayerAnimator = gameManager.Player.GetComponent<Animator>();
    }   

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            bTouch = false;
            playerObstacle.SetBoxInstanceIDClear();
        }
    }
    void FixedUpdate()
    {
        v3 = transform.position;
        v3.y = fHeight;

        if (bTouch)
        {
            v3.x += offsetX;
            v3.y  = gameManager.Player.transform.position.y + offset.y;
            boxColider2D.size = coliderSize * fColiderExtendScale;
        }
        else
        {
            boxColider2D.size = coliderSize;

        }
        transform.position = v3;
    }

    public void BoxTouch(bool isTouch)
    {
        offsetX = gameManager.Player.transform.position.x - transform.position.x - (offset.x * offset_dir);
        
        if (PlayerAnimator.GetFloat("State") < 0)
            offset_dir =  1;
        else if(PlayerAnimator.GetFloat("State") > 0)
            offset_dir = -1;

        bTouch = isTouch;
    }
}
    
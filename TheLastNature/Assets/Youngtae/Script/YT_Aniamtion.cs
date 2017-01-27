using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_Aniamtion : MonoBehaviour {


    Animator animator;
    BoxCollider2D boxColider2D;
    int state;

    void Awake()
    {
        animator = GetComponent<Animator>();
        boxColider2D = GetComponent<BoxCollider2D>();
        state = Define.PlAYER_IDEL;

        animator.SetInteger("State", state);
    }
    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.T))
        {
            Vector2 v2 = boxColider2D.offset;
            v2.y *= 1.5f;
            boxColider2D.offset = v2;
        }

        if (Input.GetKey(KeyCode.E))
        {
            state = Define.PlAYER_EVENT_MOTION;
        }
        else
        {
            state = Define.PlAYER_IDEL;
        }
        
        if(state == Define.PlAYER_EVENT_MOTION)
        {
            animator.Play("YT_PlayeEvent");
        }
        else
        {
            animator.Play("Idel");
        }
    }

    public int GetState() { return state; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacle : ActorBehaviour
{
    PlayerMove scPlayerMove;

    //Box 관련
    int nBoxMovingInstanceID;

    public override void Awake()
    {
        base.Awake();
        scPlayerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        nBoxMovingInstanceID = 0;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.tag == Define.TAG_MOVING_FLOOR)
        {
            MovingFloor script = other.GetComponent<MovingFloor>();
            fastTransform.Translate(script.GetSpeed());
        }

        if (other.tag == Define.TAG_GROUND_LAYER_1)
        {
            scPlayerMove.SetStandGround(true);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == Define.NAME_BOX)
        {
            if (Input.GetKey(KeyCode.E))
            {
                int id = other.GetInstanceID();

                if (nBoxMovingInstanceID == 0 || nBoxMovingInstanceID == id)
                {
                    BoxScript script = other.GetComponent<BoxScript>();
                    script.BoxTouch(true);
                    nBoxMovingInstanceID = id;
                }

            }
        }

        if (other.name == Define.FIRST_LIGHT_TRIGGER)
        {
            if (Input.GetKey(KeyCode.E))
                gameObject.transform.Translate(4.0f, 0.0f, 0.0f);
        }
    }

    public void SetBoxInstanceIDClear() { nBoxMovingInstanceID = 0; }
}


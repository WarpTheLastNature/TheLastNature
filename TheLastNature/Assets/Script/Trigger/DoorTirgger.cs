using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTirgger : ActorBehaviour
{

    public Vector3 LayPosition = new Vector3(0.0f, 0.0f, 0.0f);
    public LayerMask LayerMask = Define.LAYER_INT_PLAYER;
    public float Layerdistance = 5.0f;
    public bool DrawGizomo = false;
    public Vector2 DoorDir = Vector2.left;

    public bool CameraLockTrigger = false;

    void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast((transform.position + LayPosition), DoorDir * transform.localScale.x, Layerdistance, LayerMask);

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.name == "Player")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Open();
                }
            }
        }

    }

    void Open()
    {
        animator.SetTrigger("Open");
        GetComponent<BoxCollider2D>().isTrigger = true;

        if(CameraLockTrigger)
        {
            gameManager.CameraLockTrigger.StartRightTrigger();
        }

        Invoke("Close", 2.0f);
    }

    void Close()
    {
        animator.SetTrigger("Close");
        GetComponent<BoxCollider2D>().isTrigger = false;
    }


    private void OnDrawGizmos()
    {
        if (!DrawGizomo) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine((transform.position + LayPosition), (Vector2)(transform.position + LayPosition) + DoorDir * transform.localScale.x * Layerdistance);
    }
}

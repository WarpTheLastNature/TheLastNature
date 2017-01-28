using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : ActorBehaviour {

    public float distance = 5.0f;
    public LayerMask boxMask = Define.LAYER_INT_BOX;


    public Vector3 LayPosition = new Vector3(0.0f, 0.0f, 0.0f);

    GameObject box_gameObject;
    Rigidbody2D box_rigid2D;
    FixedJoint2D box_fixedJoin2D;


	void FixedUpdate ()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast((transform.position + LayPosition), Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && Input.GetKey(KeyCode.E))
        {

            box_gameObject  = hit.collider.gameObject;
            box_rigid2D     = box_gameObject.GetComponent<Rigidbody2D>();
            box_fixedJoin2D = box_gameObject.GetComponent<FixedJoint2D>();

            //Rigid2D setting
           // box_rigid2D.bodyType = RigidbodyType2D.Dynamic;
            //box_rigid2D.mass = 0.0f;

            //Joint connect
            box_fixedJoin2D.enabled = true;
            box_fixedJoin2D.connectedBody = rigid2D;

            Vector2 otherV2 = (Vector2)hit.collider.gameObject.transform.position;
            v2 = (Vector2)fastTransform.position;

            //fixed Joint Setting
            box_fixedJoin2D.connectedAnchor = new Vector2(otherV2.x - v2.x, 0.0f);

        }

        else if(Input.GetKeyUp(KeyCode.E))
        {
            if(box_fixedJoin2D != null)
            {
                //box_rigid2D.mass = 300.0f;
               // box_rigid2D.bodyType = RigidbodyType2D.Static;

                box_fixedJoin2D.enabled = false;
                box_fixedJoin2D.connectedBody = null;

                box_rigid2D = null;
                box_gameObject = null;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine((transform.position + LayPosition), (Vector2)(transform.position + LayPosition) + Vector2.right * transform.localScale.x * distance);
    }

}

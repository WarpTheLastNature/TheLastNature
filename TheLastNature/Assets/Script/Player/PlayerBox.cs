using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : ActorBehaviour {

    public float distance = 5f;
    public int colliderCount = 0;
    public LayerMask boxMask;

    GameObject box;

	void Update ()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && Input.GetKey(KeyCode.E) && hit.collider.gameObject.name == "box_obj")
        {
            print("hit"+ colliderCount++);
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            if(box != null)
                box.GetComponent<FixedJoint2D>().enabled = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

}

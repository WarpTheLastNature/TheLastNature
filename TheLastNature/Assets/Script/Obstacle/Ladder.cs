using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Actor
{
    Rigidbody2D PlayerRigid;
    float fSpeed = 5.0f;

    private Vector3 smoothTime = new Vector3(0.0f, 0.0f, 0.0f);
    public float maxSpeed = 1.0f;

    private void Start()
    {
        PlayerRigid = gameManager.Player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == Define.TAG_PALYER)
        {
            v3 = gameManager.Player.transform.position;
            v3.x = fastTransform.position.x;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //transform.position = Vector3.SmoothDamp(v3, gameManager.Player.transform.position, ref smoothTime, maxSpeed);
                gameManager.Player.transform.position = v3;
                PlayerRigid.velocity = Vector2.up * fSpeed;//new Vector2(0, fSpeed);
            }

        }
    }
}

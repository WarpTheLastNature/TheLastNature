using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Actor
{
    Rigidbody2D PlayerRigid;
    float fSpeed = 5.0f;

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
                gameManager.Player.transform.position = v3;
                PlayerRigid.velocity = Vector2.up * fSpeed;//new Vector2(0, fSpeed);
            }

        }
    }
}

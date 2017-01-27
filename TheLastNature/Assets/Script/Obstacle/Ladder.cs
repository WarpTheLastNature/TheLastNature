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
            if(Input.GetKey(KeyCode.UpArrow))
                PlayerRigid.velocity = new Vector2(0, fSpeed);

            else if(Input.GetKey(KeyCode.UpArrow))
                PlayerRigid.velocity = new Vector2(0, -fSpeed);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ActorBehaviour
{
    //public
    public float offsetY = 0.2f;
    
    //private
    float fHeight;
    bool bTouch = false;
    float offsetX = 0.0f;

    void Start()
    {
        fHeight = gameObject.transform.position.y;
        name = "Box";
    }


    void FixedUpdate()
    {
        v3 = transform.position;
        v3.y = fHeight;

        if (bTouch)
        {
            v3.x += offsetX;
            v3.y += offsetY;
        }
        transform.position = v3;
	}

    void BoxTouch(bool isTouch)
    {
        bTouch = isTouch;
        offsetX =  gameManager.Player.transform.position.x - transform.position.x;
    }

}

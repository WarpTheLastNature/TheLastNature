using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : Actor
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            gameManager.CameraLockTrigger.StartLeftTrigger();
        }
    }
}

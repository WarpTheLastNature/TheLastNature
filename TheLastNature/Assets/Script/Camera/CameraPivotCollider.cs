using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotCollider : MonoBehaviour {


    void OnTriggerStay2D(Collider2D other)
    {
        print("CameraPivotCollider TriggerStay2D");
    }

}

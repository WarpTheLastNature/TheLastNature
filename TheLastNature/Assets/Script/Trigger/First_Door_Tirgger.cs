using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Door_Tirgger : Actor
{
    private void OnTriggerStay2D(Collider2D col)
    {
      if(col.tag == Define.TAG_PALYER)
        {

        }
    }
}

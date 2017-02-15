using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Actor
{
    public GameObject DynamicLight;
    public bool on_off = true;


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

                DynamicLight.SetActive(on_off);

                if (on_off) on_off = false;
                else on_off = true;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_GrapLope : MonoBehaviour
{

    bool asdf = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Lope")
        {
            return;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Lope")
        {
            return;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {


        if (other.tag == "Lope")
        {
            return;
        }
        if (other.tag == "Lope_handle")
        {
            
                JH_lopeHandle script = other.GetComponent<JH_lopeHandle>();
                script.F_BlopeHandle();

            //-------------------------

            Collider2D asdfaColl=GetComponent<Collider2D>();
            //collider.isTrigger = true;
            asdfaColl.isTrigger = true;

            //-----------------------

        }
    }

//    void OnColider


}
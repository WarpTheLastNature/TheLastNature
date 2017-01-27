using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_MoveBar : MonoBehaviour {
    public float fRange;
    public float fNowPivot         ;
    public float fSpeed            ;
    //  Rigidbody2D     rigid             ;
    // Use this for initialization
    GameObject player;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(fSpeed * Time.deltaTime, 0, 0.0f);
       
        
        if (fNowPivot > fRange)
        {
            fSpeed *= -1;
            fNowPivot = 0.0f;
        }
        fNowPivot += 0.1f;
    }
    //der은 istirres앧ㄱㅁㄹㄴ
    //collision

        /*
   void OnCollisionStay2D(Collision2D collision)

    {

        GameObject other = collision.collider.gameObject;
        
        if (other.tag == "Player")
        {
                
            
        }
    }
    */


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            
            other.SendMessage("RigidGraviyB", true);
           // other.transform.Translate(fSpeed * Time.deltaTime, 0, 0.0f);
           // other.transform.Translate(0, 0.1f, 0);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (other.transform.position.y>= transform.position.y)
            other.transform.Translate(fSpeed * Time.deltaTime, 0, 0.0f);
            other.SendMessage("RigidGraviyB", true);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {

 
        if (other.tag == "Player")
        {
            other.SendMessage("RigidGraviyB", false);
        }
    }







}

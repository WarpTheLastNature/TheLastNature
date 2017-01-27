using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_CollisionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        print("OnCollisionStay2D");
    }
}

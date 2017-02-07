using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_lopeHandle : Actor {

    bool B_lopeHandle = false;
    // Use this for initialization
    void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
		      //플레이어를 따라다니자
        if (B_lopeHandle)
        {
            gameManager.Player.transform.position = (transform.position);
        }
	}

    public void F_BlopeHandle()
    {
        B_lopeHandle = true;
    }
}

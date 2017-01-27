using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_flashlight : MonoBehaviour {
    bool B_flashlight=false;
    public GameObject Player = null;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //플레이어를 따라다니자
        if (B_flashlight)
        {
            transform.Translate(Player.transform.position.x-transform.position.x, Player.transform.position.y - transform.position.y, 0);
        }
		
	}

    //플레이어가 f누르면 들고다니고 다시 누른다면 들고다니지 않아 플레이어가 이친구랑 붇틷혔을때 F키를 누른다면
    //이함수를 호출해서 상태를 바꿔주자!
    public void F_Bflashlight() 
    {
        B_flashlight = !B_flashlight;
    }


}

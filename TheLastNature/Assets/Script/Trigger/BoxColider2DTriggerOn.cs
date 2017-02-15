using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColider2DTriggerOn : Actor
{
    BoxCollider2D boxColider2D;
    float fLadderHeight = 0.0f;
    GameObject player;

    public override void Awake()
    {
        base.Awake();
        boxColider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = gameManager.Player;
        fLadderHeight = transform.FindChild("Child_Pivot").transform.position.y;
    }

    private void Update()
    {
       if (player.transform.position.y > fLadderHeight)
           boxColider2D.isTrigger = false;
       else
           boxColider2D.isTrigger = true;
    }
}

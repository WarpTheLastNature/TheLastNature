using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : ActorBehaviour
{
    void Start()
    {
        gameManager.Player = gameObject;
    }

	void Update()
    {
        float press = Input.GetAxis("Horizontal") * Time.deltaTime;
        animator.SetFloat("State", press);
    }
}

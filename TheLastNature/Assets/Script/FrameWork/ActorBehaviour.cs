using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBehaviour : Actor
{

    public Animator animator { private set; get; }

    public override void Awake()
    {
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
    }
}

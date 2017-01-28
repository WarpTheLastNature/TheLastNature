using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBehaviour : Actor
{
    public Animator animator { private set; get; }
    public Rigidbody2D rigid2D { private set; get; }

    public override void Awake()
    {
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }
}

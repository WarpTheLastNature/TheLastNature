using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : Actor
{

    public bool  bMovingType   = true;

    public float fMovingRange = 5.0f;
    public float fMovingSpeed = 5.0f;

    private int   MovingDir          = 1;
    private float MovingInitPosition = 0;

    public Vector3 v3Speed;


    void Start()
    {
        if (bMovingType)
        {
            MovingInitPosition = fastTransform.position.x;
        }
        else
        {
            MovingInitPosition = fastTransform.position.y;
        }

        v3Speed.x = 0.0f;
        v3Speed.y = 0.0f;
        v3Speed.z = 0.0f;

    }
	void FixedUpdate ()
    {
        if (bMovingType)
            Moving_Horizontal();
        else
          Moving_Vertical();

        fastTransform.Translate(v3Speed);
	}

   
    void Moving_Horizontal()
    {
        float distance = Mathf.Abs(MovingInitPosition - fastTransform.position.x);
        if(distance > fMovingRange)  MovingDir *= -1;
        v3Speed.x = Time.deltaTime * MovingDir * fMovingSpeed;
    }

    void Moving_Vertical()
    {
        float distance = Mathf.Abs(MovingInitPosition - fastTransform.position.y);
        if (distance > fMovingRange) MovingDir *= -1;
        v3Speed.y = Time.deltaTime * MovingDir * fMovingSpeed;
    }

    public bool     GetMovingType() { return bMovingType; }
    public Vector3  GetSpeed()      { return v3Speed; }
}

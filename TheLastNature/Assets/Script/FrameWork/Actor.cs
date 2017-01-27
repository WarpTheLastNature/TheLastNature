using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public GameManager gameManager { private set; get; }
    public Transform fastTransform { private set; get; }
    public GameObject fastObject   { private set; get; }
    public Vector3 worldPositon;
    protected Vector3 v3;
    protected Vector2 v2;

    public virtual void Awake()
    {
        gameManager = GameManager.instance;
        fastTransform = transform;
        fastObject = gameObject;
        v3 = new Vector3(0.0f, 0.0f, 0.0f);
        v2 = new Vector3(0.0f, 0.0f);
    }

}

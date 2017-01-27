using UnityEngine;
using System.Collections;

public class YT_Moving : MonoBehaviour {

    float fRange = 3.0f;
    float fNowPivot = 0.0f;
    float fSpeed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        transform.Translate(0, fSpeed * Time.deltaTime, 0.0f);

        if (fNowPivot > fRange)
        {
            fSpeed *= -1;
            fNowPivot = 0.0f;
        }
        fNowPivot += 0.1f;

	}
}

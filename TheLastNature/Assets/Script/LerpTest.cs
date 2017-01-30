using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour {


    public float fSpeed = 1.0f;
    public float fLerp = 0.0f;
    public float fStart = 0.0f;
    public float fEnd = 1.0f;
    
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame

    private void OnGUI()
    {
        if(fLerp < 1.0f) fLerp += Time.deltaTime / fSpeed;
        GUI.TextField(new Rect(500, 500, 550, 520), "Lerp : " + Mathf.Lerp(fStart, fEnd, fLerp));
    }

}

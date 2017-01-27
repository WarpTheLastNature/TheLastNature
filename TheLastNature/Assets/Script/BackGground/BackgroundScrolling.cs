using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//배경 3개를 일렬로 [정확하게] 배치를 해야된다.

public class BackgroundScrolling : Actor
{

    public string TAG_BACKGROUND_LAYER_0 = Define.TAG_BACKGROUND_LAYER_0;
    public string BACKGROUND_LAYER_LEFT = Define.BACKGROUND_LAYER_LEFT;
    public string BACKGROUND_LAYER_CENTER = Define.BACKGROUND_LAYER_CENTER;
    public string BACKGROUND_LAYER_RIGHT = Define.BACKGROUND_LAYER_RIGHT;

    public GameObject[] backgroundList;
    public Vector3 LastPosition;

    public float fMoveRange = 40.0f;
    public float fMoveTriggerRange = 10.0f;

    private float fBackgroundDistance;
    private float fBackgroundSize;
    private int nLeft   = 0;
    private int nCenter = 1;
    private int nRight  = 2;

    void Start()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag(TAG_BACKGROUND_LAYER_0);
        backgroundList = new GameObject[3];

        foreach (GameObject obj in list)
        {
            if (obj.name == BACKGROUND_LAYER_LEFT)
                backgroundList[nLeft] = obj;

            if (obj.name == BACKGROUND_LAYER_CENTER)
                backgroundList[nCenter] = obj;

            if (obj.name == BACKGROUND_LAYER_RIGHT)
                backgroundList[nRight] = obj;
        }

        fBackgroundDistance = backgroundList[nCenter].transform.position.x - backgroundList[nLeft].transform.position.x;
        fBackgroundSize = fBackgroundDistance * 0.5f;

        // 위치를 받아와서 left, cetner, right에 넣어준다.
         v3 = backgroundList[nLeft].transform.position;

         v3.x = gameManager.Player.transform.position.x - fBackgroundDistance;
         backgroundList[nLeft].transform.position = v3;
          
         v3.x = gameManager.Player.transform.position.x;
         backgroundList[nCenter].transform.position = v3;

         v3.x = gameManager.Player.transform.position.x + fBackgroundDistance;
         backgroundList[nRight].transform.position = v3;

        LastPosition = backgroundList[0].transform.position;
    }

    // Update is called once per frame
    void Update() 
    {
        Vector3 vPlayerPosition = gameManager.Player.transform.position;

        if (vPlayerPosition.x + fBackgroundSize < (backgroundList[nRight].transform.position.x - fBackgroundSize))
        {
            RightMove();
            v3 = backgroundList[nLeft].transform.position;
            v3.x -= (fBackgroundDistance * 2);
            backgroundList[nLeft].transform.position = v3;
        }

        if (vPlayerPosition.x - fBackgroundSize > (backgroundList[nLeft].transform.position.x + fBackgroundSize))
        {
            LeftMove();
            v3 = backgroundList[nRight].transform.position;
            v3.x += (fBackgroundDistance * 2);
            backgroundList[nRight].transform.position = v3;
        }
    }

    void LeftMove()
    {
        nLeft++;
        nCenter++;
        nRight++;

        if (nLeft > 2) nLeft = 0;
        if (nCenter > 2) nCenter = 0;
        if (nRight > 2) nRight = 0;
    }

    void RightMove()
    {
          nLeft--;
        nCenter--;
         nRight--;
 
          if (nLeft < 0) nLeft = 2;
        if (nCenter < 0) nCenter = 2;
         if (nRight < 0) nRight = 2;
    } 
}

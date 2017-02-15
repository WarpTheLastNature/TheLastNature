using UnityEngine;
using System.Collections;


public class GameManager
{
    private static GameManager m_instance;

    public float fGlobalTime;
    bool bPlaying;

    public GameObject Player;

    public CameraLockTrigger CameraLockTrigger;

    public GameManager()
    {
        fGlobalTime = 0.0f;
        bPlaying = true;
        Player = null;

        InputSystem.Instance.init();
    }

    public void Init()
    {
        fGlobalTime = 0.0f;
        bPlaying = true;

        Player = null;
        
    }

    public bool IsPlaying() {return bPlaying;}

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameManager();
            }

            return m_instance;
        }
    }
   
}

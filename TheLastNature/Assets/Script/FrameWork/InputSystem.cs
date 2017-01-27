using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_INPUT_TYPE
{
    TOUCH_LEFT,
    TOUCH_RIGHT,
    TOUCH_UP,
    TOUCH_DOWN,
    TOUCH_EVENT
}

public class InputSystem : ActorBehaviour
{                          
    private static InputSystem m_instance = null;

    public static InputSystem Instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = FindObjectOfType(typeof(InputSystem)) as InputSystem;
            }

            if (!m_instance)
            {
                GameObject newInstance = new GameObject("InputManager");
                m_instance = newInstance.AddComponent<InputSystem>();
            }
            return m_instance;
        }
    }

    private InputSystem()
    {
    }

    private C_TOUCH_MANAGER m_cTouchManager;

    private Dictionary<E_INPUT_TYPE, bool> m_dicData = new Dictionary<E_INPUT_TYPE, bool>();

    public bool IsKeyDown(E_INPUT_TYPE InputType)
    {
        return m_dicData[InputType];
    }
    public void KeyDown(E_INPUT_TYPE InputType)
    {
        m_dicData[InputType] = true;
    }
    public void KeyUp(E_INPUT_TYPE InputType)
    {
        m_dicData[InputType] = false;
    }
    public C_TOUCH_MANAGER GetTouchManager()
    {
        return m_cTouchManager;
    }
    public void init()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            m_cTouchManager = new C_TOUCH_MANAGER();
            m_cTouchManager.init();
        }
        //
        m_cTouchManager = new C_TOUCH_MANAGER();
        m_cTouchManager.init();
    }

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (m_cTouchManager != null)
        {
            m_cTouchManager.update();
        }
    }
}

public class C_TOUCH_MANAGER 
{
    public const string Begin = "Begin";
    public const string Move  = "Move";
    public const string End   = "End";

    private InputSystem m_cInputManager;

    delegate void listener(string strType, int nId, float fX, float fY, float fDx, float fDy);
    event listener listenerBegin0, listenerBegin1, listenerBegin2, listenerBegin3, listenerBegin4, listenerBegin5, listenerBegin6;
    event listener listenerMove0, listenerMove1, listenerMove2, listenerMove3, listenerMove4, listenerMove5, listenerMove6;
    event listener listenerEnd0, listenerEnd1, listenerEnd2, listenerEnd3, listenerEnd4, listenerEnd5, listenerEnd6;

    private const float JS_DISTANCE_MAX = 60.0f;
    private bool m_bUseJS = true;
    private Vector2[] m_vec2Delta = new Vector2[7];
    private Vector2[] m_vec2NowPos = new Vector2[7];
    private Vector2 m_vec2ScreenBounds = new Vector2(400.0f, 240.0f);
    //private SceneManager scenemanager;

    public void init()
    {
       //scenemanager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        m_cInputManager = InputSystem.Instance;
        listenerBegin0 += OnTouch;
        listenerMove0 += OnTouch;
        listenerEnd0 += OnTouch;

        listenerBegin1 += OnTouch;
        listenerMove1 += OnTouch;
        listenerEnd1 += OnTouch;
        listenerBegin3 += OnTouch;
        listenerMove3 += OnTouch;
        listenerEnd3 += OnTouch;
        listenerBegin4 += OnTouch;
        listenerMove4 += OnTouch;
        listenerEnd4 += OnTouch;
        listenerBegin5 += OnTouch;
        listenerMove5 += OnTouch;
        listenerEnd5 += OnTouch;
        listenerBegin6 += OnTouch;
        listenerMove6 += OnTouch;
        listenerEnd6 += OnTouch;
        listenerBegin2 += OnTouch;
        listenerMove2 += OnTouch;
        listenerEnd2 += OnTouch;
    }

    public Vector2 GetNowTouchPos(int nFingerCount)
    {
        return m_vec2NowPos[nFingerCount];
    }
    public Vector2 GetBeginTouchPos(int nFingerCount)
    {
        return m_vec2Delta[nFingerCount];
    }
    public void setUseJS(bool bUse)
    {
        m_bUseJS = bUse;
    }
    public bool isUseJS()
    {
        return m_bUseJS;
    }
    private void OnTouch(string type, int nId, float x, float y, float dx, float dy)
    {
        switch (type)
        {
            case Begin:
                {

                }
                break;

            case End:
                {

                }
                break;

            case Move:
                {

                }
                break;
        }
    }
    private float getSlope(Vector2 vec2First, Vector2 vec2Second)
    {
        Vector2 vec2NormalFirst = vec2First.normalized;
        Vector2 vec2NormalSecond = vec2Second.normalized;
        return vec2NormalSecond.y - vec2NormalFirst.y / vec2NormalSecond.x - vec2NormalFirst.x;
        /*return vec2Second.y - vec2First.y / vec2Second.x - vec2First.x;*/
    }
    private Vector2 getPoint(Vector2 vec2Origin, float fDistance, float fSlope)
    {
        float fDx = fDistance / Mathf.Sqrt(1 + fSlope * fSlope);
        float fDy = fDistance * fSlope / Mathf.Sqrt(1 + fSlope * fSlope);

        return new Vector2(vec2Origin.x + fDx, vec2Origin.y + fDy);
    }
    public void update()
    {
        int count = Input.touchCount;

        for (int i = 0; i < count; i++)
        {
            Touch touch = Input.GetTouch(i);
           // print("Touch Count : " + count);
            int nId = touch.fingerId; 

            m_vec2NowPos[nId] = touch.position;
            if (touch.phase == TouchPhase.Began)
                m_vec2Delta[nId] = touch.position;
            float fX, fY, fDx, fDy;
            fX = m_vec2NowPos[nId].x;
            fY = m_vec2NowPos[nId].y;
            if (touch.phase == TouchPhase.Began)
            {
                fDx = fDy = 0;
            }
            else
            {
                fDx = m_vec2NowPos[nId].x - m_vec2Delta[nId].x;
                fDy = m_vec2NowPos[nId].y - m_vec2Delta[nId].y;
            }

            if (touch.phase == TouchPhase.Began)
            {
                switch (nId)
                {
                    case 0:
                        if (listenerBegin0 != null)
                            listenerBegin0(Begin, nId, fX, fY, fDx, fDy);
                        break;
                    case 1:
                        if (listenerBegin1 != null)
                            listenerBegin1(Begin, nId, fX, fY, fDx, fDy);
                        break;
                    case 2:
                        if (listenerBegin2 != null)
                            listenerBegin2(Begin, nId, fX, fY, fDx, fDy);
                        break;
                    case 3:
                        if (listenerBegin3 != null)
                            listenerBegin3(Begin, nId, fX, fY, fDx, fDy);
                        break;
                    case 4:
                        if (listenerBegin4 != null)
                            listenerBegin4(Begin, nId, fX, fY, fDx, fDy);
                        break;
                    case 5:
                        if (listenerBegin4 != null)
                            listenerBegin4(Begin, nId, fX, fY, fDx, fDy);
                        break;
                    case 6:
                        if (listenerBegin4 != null)
                            listenerBegin4(Begin, nId, fX, fY, fDx, fDy);
                        break;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                switch (nId)
                {
                    case 0:
                        if (listenerMove0 != null)
                            listenerMove0(Move, nId, fX, fY, fDx, fDy);
                        break;
                    case 1:
                        if (listenerMove1 != null)
                            listenerMove1(Move, nId, fX, fY, fDx, fDy);
                        break;
                    case 2:
                        if (listenerMove2 != null)
                            listenerMove2(Move, nId, fX, fY, fDx, fDy);
                        break;
                    case 3:
                        if (listenerMove3 != null)
                            listenerMove3(Move, nId, fX, fY, fDx, fDy);
                        break;
                    case 4:
                        if (listenerMove4 != null)
                            listenerMove4(Move, nId, fX, fY, fDx, fDy);
                        break;
                    case 5:
                        if (listenerMove4 != null)
                            listenerMove4(Move, nId, fX, fY, fDx, fDy);
                        break;
                    case 6:
                        if (listenerMove4 != null)
                            listenerMove4(Move, nId, fX, fY, fDx, fDy);
                        break;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                switch (nId)
                {
                    case 0:
                        if (listenerEnd0 != null)
                            listenerEnd0(End, nId, fX, fY, fDx, fDy);
                        break;
                    case 1:
                        if (listenerEnd1 != null)
                            listenerEnd1(End, nId, fX, fY, fDx, fDy);
                        break;
                    case 2:
                        if (listenerEnd2 != null)
                            listenerEnd2(End, nId, fX, fY, fDx, fDy);
                        break;
                    case 3:
                        if (listenerEnd3 != null)
                            listenerEnd3(End, nId, fX, fY, fDx, fDy);
                        break;
                    case 4:
                        if (listenerEnd4 != null)
                            listenerEnd4(End, nId, fX, fY, fDx, fDy);
                        break;
                    case 5:
                        if (listenerEnd4 != null)
                            listenerEnd4(End, nId, fX, fY, fDx, fDy);
                        break;
                    case 6:
                        if (listenerEnd4 != null)
                            listenerEnd4(End, nId, fX, fY, fDx, fDy);
                        break;
                }
            }
        }
    }
}


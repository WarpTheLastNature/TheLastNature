using UnityEngine;
using System.Collections;

public class JH_labarun : MonoBehaviour {

    //bool b_Jump;
    bool b_Ladder;
    float fspeed;
    public GameObject testObj = null;
    public GameObject pivotObj = null;

    public BoxCollider2D box_colider2D;
    public Vector2 coilder2D_Size;
    

    // Use this for initialization
    void Start () {

        fspeed = 1.0f;
        box_colider2D = GetComponent<BoxCollider2D>();
        coilder2D_Size = box_colider2D.size * 0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 down_pos = transform.position;
        down_pos.y -= coilder2D_Size.y;
        print("down pos : " + down_pos);
        if (b_Ladder)
        {
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, fspeed * Time.deltaTime, 0);
                print("UpArrow");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {

                transform.Translate(0, (-1)*fspeed * Time.deltaTime, 0);
                print("UpArrow");
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(fspeed * Time.deltaTime * (-1), 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(fspeed * Time.deltaTime , 0, 0);
        }

        /*

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!b_Jump)
            {
                b_Jump = true;
            }
            //근데 이거 필요하나

        }
        if (b_Jump)
        {

            transform.Translate(0, fspeed * Time.deltaTime*(3.2f), 0);
            
            if (pivotObj.transform.position.y > transform.position.y)
            {
                b_Jump = false;
            }
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            b_Ladder = true;
            SendMessage("RigidGraviyB", b_Ladder);
            return;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Ladder")
        {
            b_Ladder = false;

            SendMessage("RigidGraviyB", b_Ladder);

            return;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {


        if (other.tag == "Flashlight")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                JH_flashlight script = other.GetComponent<JH_flashlight>();
                script.F_Bflashlight();
            }
        }

        if (other.tag == "Bar")
        {
            return;
        }
        Vector3 otherPos = other.gameObject.transform.position;


        if (other.tag == "Ladder")
        {
            b_Ladder = true;
            SendMessage("RigidGraviyB", b_Ladder);
            return;
        }





        if (other.tag == "Box")
        {

            //      otherPos.y -= -0.5f;
            //      transform.position = otherPos;
            //   other.transform.position = transform.position;
            if (transform.position.x < otherPos.x)
            {
                other.transform.Translate(fspeed * Time.deltaTime, 0, 0);
                if (testObj != null)
                {

                    testObj.SendMessage("B_Cameramove", fspeed);

                }
            }

            if (transform.position.x > otherPos.x)
                other.transform.Translate(-1 * fspeed * Time.deltaTime, 0, 0);
            

        }
    }

}

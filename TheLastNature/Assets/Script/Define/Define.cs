
public static class Define
{
    //name
    public static string NAME_BOX                   = "Box";
    public static string NAME_LADDER                = "Ladder";
    public static string NAME_PIVOT_LADDER_HEIGHT   = "LadderHeight";
    public static string NAME_CHILD_PIVOT           = "Child_Pivot";

    public static string NAME_BACKGROUND_LAYER_LEFT      = "Background_Left";
    public static string NAME_BACKGROUND_LAYER_CENTER    = "Background_Center";
    public static string NAME_BACKGROUND_LAYER_RIGHT     = "Background_Right";
    public static string NAME_FIRST_LIGHT_TRIGGER        = "First_Light_Trigger";

    //Tage
    public static string TAG_PALYER                 = "Player";
    public static string TAG_MOVING_FLOOR           = "MovingFloor";
    public static string TAG_BACKGROUND_LAYER_0     = "Background_Layer_0";
    public static string TAG_GROUND_LAYER_1         = "Background_Layer_1";


    public static string LAYER_STRING_BOX           = "Box";
    public static int    LAYER_INT_BOX              = 8;

    public static string LAYER_STRING_MOVINGFLOOR   = "MovingFloor";
    public static int LAYER_INT_MOVINGFLOOR         = 9;



    //Moving State
    public static bool MOVING_TYPE_HOR = true;
    public static bool MOVING_TYPE_VER = false;

    //Player State
    public static int PlAYER_IDEL = 0;
    public static int PlAYER_EVENT_MOTION = 1;

}

/*
 *      float x = transform.worldToLocalMatrix.m03;
        float y = transform.worldToLocalMatrix.m13;
        float z = transform.worldToLocalMatrix.m23;
        print("x"+x +"y"+ y + "z"+ z);
 * 
 */

using UnityEngine;

public class Rectangle
{
    public float x, y, w, h;

    Rectangle()
    {
        x = y = w = h = 0;
    }

    void set(float ix = 0, float iy = 0, float iw = 0, float ih = 0)
    {
        x = ix; y = iy; w = iw; h = ih;
    }

    void set(Rectangle rect)
    {
        set(rect.x, rect.y, rect.w, rect.h);
    }


    bool contains(float ix, float iy)
    {
        float l = x - w; 
        float r = x + w; 

        float t = y - h; 
        float b = y + h;

        return l < r && t < b && ix >= l && ix < r && iy >= t && iy < b;
    }

    bool contains(float ix, float iy, float iw, float ih)
    {
        float l = x - w; float col_l = ix - iw;
        float r = x + w; float col_r = ix + iw;
                                         
        float t = y - h; float col_t = iy - ih;
        float b = y + h; float col_b = iy + ih;

        if (l > col_r) return false;
        if (r < col_l) return false;
        if (t > col_b) return false;
        if (b < col_t) return false;
        return true;
    }

    bool contains(Rectangle rect)
    {
        float l = x - w;  float col_l = rect.x - rect.w;
        float r = x + w;  float col_r = rect.x + rect.w;

        float t = y - h;  float col_t = rect.y - rect.h;
        float b = y + h;  float col_b = rect.y + rect.h;

        if (l > col_r) return false;
        if (r < col_l) return false;
        if (t > col_b) return false;
        if (b < col_t) return false;
        return true;
    }
}


public static class Util
{
    public static int Int32ParseFast(string value)
    {
        int result = 0;
        int length = value.Length;
        bool minus = false;
        for (int i = 0; i < length; i++)
        {
            if (value[i].CompareTo('-') == 0)
            {
                minus = true;
                continue;
            }
            result = 10 * result + (value[i] - 48);
        }
        return minus == false ? result : -result;
    }

    public static bool IsPlatformAndroid()
    {
        return Application.platform == RuntimePlatform.Android;
    }

    public static bool IsPlatformIOS()
    {
        return Application.platform == RuntimePlatform.IPhonePlayer;
    }

    public static bool IsMobilePlatform()
    {
        if (Application.platform == RuntimePlatform.Android
            || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            return true;
        }
        return false;
    }

    public static bool IsEditorPlatform()
    {
#if UNITY_EDITOR
        return true;
#else
            return false;
#endif
    }
}
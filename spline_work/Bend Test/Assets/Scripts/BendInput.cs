using UnityEngine;
using System.Collections;

public class BendInput : MonoBehaviour {

    public BezierSpline[] xCurves;
    public BezierSpline[] zCurves;

    void Update () {
        if (Input.GetKey(KeyCode.Keypad7)) //top-corner-bend-up (lava moves towards bottom-left)
        {
            NorthEastUp();
        }
        else if (Input.GetKey(KeyCode.Keypad9)) //top-corner-bend-down (lava moves towards top-right)
        {
            NorthEastDown();
        }
        else if (Input.GetKey(KeyCode.Keypad1)) //bottom-corner-bend-up (lava moves towards top-left)
        {
            SouthEastUp();
        }
        else if (Input.GetKey(KeyCode.Keypad3)) //bottom-corner-bend-down (lava moves towards bottom-right)
        {
            SouthEastDown();
        }
        else if (Input.GetKey(KeyCode.Keypad4)) //midline-bend-up (lava moves towards left)
        {
            EastUp();
        }
        else if (Input.GetKey(KeyCode.Keypad6)) //midline-bend-down (lava moves towards right)
        {
            EastDown();
        }
    }

    void NorthEastUp()
    {
        /*
        X1Z4(0.1f);
        X1Z3(0.05f);
        X2Z4(0.05f);
        X1Z2(0.025f);
        X2Z3(0.025f);
        X3Z4(0.025f);
        */

        

        Debug.Log("NE-U");
    }

    void NorthEastDown()
    {
        /*
        X1Z4(-0.1f);
        X1Z3(-0.05f);
        X2Z4(-0.05f);
        X1Z2(-0.025f);
        X2Z3(-0.025f);
        X3Z4(-0.025f);
        */

        Debug.Log("NE-D");
    }

    void SouthEastUp()
    {

    }

    void SouthEastDown()
    {

    }

    void EastUp()
    {

    }

    void EastDown()
    {

    }
    /*
    void X1Z1(float change)
    {
        xCurves[0].points[0].y += change;
        zCurves[0].points[0].y += change;
    }

    void X1Z2(float change)
    {
        xCurves[0].points[1].y += change;
        zCurves[1].points[0].y += change;
    }

    void X1Z3(float change)
    {
        xCurves[0].points[2].y += change;
        zCurves[2].points[0].y += change;
    }

    void X1Z4(float change)
    {
        xCurves[0].points[3].y += change;
        zCurves[3].points[0].y += change;
    }

    void X2Z1(float change)
    {
        xCurves[1].points[0].y += change;
        zCurves[0].points[1].y += change;
    }

    void X2Z2(float change)
    {
        xCurves[1].points[1].y += change;
        zCurves[1].points[1].y += change;
    }
    void X2Z3(float change)
    {
        xCurves[1].points[2].y += change;
        zCurves[2].points[1].y += change;
    }

    void X2Z4(float change)
    {
        xCurves[1].points[3].y += change;
        zCurves[3].points[1].y += change;
    }

    void X3Z1(float change)
    {
        xCurves[2].points[0].y += change;
        zCurves[0].points[2].y += change;
    }

    void X3Z2(float change)
    {
        xCurves[2].points[1].y += change;
        zCurves[1].points[2].y += change;
    }

    void X3Z3(float change)
    {
        xCurves[2].points[2].y += change;
        zCurves[2].points[2].y += change;
    }

    void X3Z4(float change)
    {
        xCurves[2].points[3].y += change;
        zCurves[3].points[2].y += change;
    }

    void X4Z1(float change)
    {
        xCurves[3].points[0].y += change;
        zCurves[0].points[3].y += change;
    }

    void X4Z2(float change)
    {
        xCurves[3].points[1].y += change;
        zCurves[1].points[3].y += change;
    }

    void X4Z3(float change)
    {
        xCurves[3].points[2].y += change;
        zCurves[2].points[3].y += change;
    }

    void X4Z4(float change)
    {
        xCurves[3].points[3].y += change;
        zCurves[3].points[3].y += change;
    }
    */
}

using UnityEngine;
using System.Collections;

public class BendInputCurve : MonoBehaviour {

    public float bendSpeed;
    public float bendLimit;

    public BezierCurve[] xCurves;
    public BezierCurve[] zCurves;

    void Update () {
        if (Input.GetKey(KeyCode.Keypad7) && (xCurves[3].points[0].y < bendLimit)) //top-corner-bend-up (lava moves towards bottom-left)
        {
            NorthEastUp();
        }
        else if (Input.GetKey(KeyCode.Keypad9) && (xCurves[3].points[0].y > -bendLimit)) //top-corner-bend-down (lava moves towards top-right)
        {
            NorthEastDown();
        }
        else if (Input.GetKey(KeyCode.Keypad1) && (xCurves[0].points[0].y < bendLimit)) //bottom-corner-bend-up (lava moves towards top-left)
        {
            SouthEastUp();
        }
        else if (Input.GetKey(KeyCode.Keypad3) && (xCurves[0].points[0].y > -bendLimit)) //bottom-corner-bend-down (lava moves towards bottom-right)
        {
            SouthEastDown();
        }
        else if (Input.GetKey(KeyCode.Keypad4) && (xCurves[3].points[0].y < bendLimit) && (xCurves[0].points[0].y < bendLimit)) //midline-bend-up (lava moves towards left)
        {
            EastUp();
        }
        else if (Input.GetKey(KeyCode.Keypad6) && (xCurves[3].points[0].y > -bendLimit) && (xCurves[0].points[0].y > -bendLimit)) //midline-bend-down (lava moves towards right)
        {
            EastDown();
        }
    }

    void NorthEastUp()
    {

        X4Z1(0.1f);

        X3Z1(0.05f);
        X4Z2(0.05f);

        X2Z1(0.025f);
        X3Z2(0.025f);
        X4Z3(0.025f);

        X1Z1(0.0125f);
        X2Z2(0.0125f);
        X3Z3(0.0125f);
        X4Z4(0.0125f);

        X1Z2(0.00625f);
        X2Z3(0.00625f);
        X3Z4(0.00625f);

        X1Z3(0.003125f);
        X2Z4(0.003125f);

        Debug.Log("NE-U");
    }

    void NorthEastDown()
    {

        X4Z1(-0.1f);

        X3Z1(-0.05f);
        X4Z2(-0.05f);

        X2Z1(-0.025f);
        X3Z2(-0.025f);
        X4Z3(-0.025f);

        X1Z1(-0.0125f);
        X2Z2(-0.0125f);
        X3Z3(-0.0125f);
        X4Z4(-0.0125f);

        X1Z2(-0.00625f);
        X2Z3(-0.00625f);
        X3Z4(-0.00625f);

        X1Z3(-0.003125f);
        X2Z4(-0.003125f);

        Debug.Log("NE-D");
    }

    void SouthEastUp()
    {
        X1Z1(0.1f);

        X1Z2(0.05f);
        X2Z1(0.05f);

        X1Z3(0.025f);
        X2Z2(0.025f);
        X3Z1(0.025f);

        X1Z4(0.0125f);
        X2Z3(0.0125f);
        X3Z2(0.0125f);
        X4Z1(0.0125f);

        X2Z4(0.00625f);
        X3Z3(0.00625f);
        X4Z2(0.00625f);

        X3Z4(0.003125f);
        X4Z3(0.003125f);

        Debug.Log("SE-U");
    }

    void SouthEastDown()
    {
        X1Z1(-0.1f);

        X1Z2(-0.05f);
        X2Z1(-0.05f);

        X1Z3(-0.025f);
        X2Z2(-0.025f);
        X3Z1(-0.025f);

        X1Z4(-0.0125f);
        X2Z3(-0.0125f);
        X3Z2(-0.0125f);
        X4Z1(-0.0125f);

        X2Z4(-0.00625f);
        X3Z3(-0.00625f);
        X4Z2(-0.00625f);

        X3Z4(-0.003125f);
        X4Z3(-0.003125f);

        Debug.Log("SE-D");
    }

    void EastUp()
    {
        X4Z1(0.1f);
        X3Z1(0.1f);
        X2Z1(0.1f);
        X1Z1(0.1f);

        X4Z2(0.05f);    
        X3Z2(0.05f);
        X2Z2(0.05f);
        X1Z2(0.05f);

        X4Z3(0.025f);
        X3Z3(0.025f);
        X2Z3(0.025f);
        X1Z3(0.025f);

        Debug.Log("E-U");
    }

    void EastDown()
    {
        X4Z1(-0.1f);
        X3Z1(-0.1f);
        X2Z1(-0.1f);
        X1Z1(-0.1f);

        X4Z2(-0.05f);
        X3Z2(-0.05f);
        X2Z2(-0.05f);
        X1Z2(-0.05f);

        X4Z3(-0.025f);
        X3Z3(-0.025f);
        X2Z3(-0.025f);
        X1Z3(-0.025f);

        Debug.Log("E-D");
    }
    
    void X1Z1(float change)
    {
        xCurves[0].points[0].y += (change * bendSpeed);
        zCurves[0].points[0].y += (change * bendSpeed);
    }

    void X1Z2(float change)
    {
        xCurves[0].points[1].y += (change * bendSpeed);
        zCurves[1].points[0].y += (change * bendSpeed);
    }

    void X1Z3(float change)
    {
        xCurves[0].points[2].y += (change * bendSpeed);
        zCurves[2].points[0].y += (change * bendSpeed);
    }

    void X1Z4(float change)
    {
        xCurves[0].points[3].y += (change * bendSpeed);
        zCurves[3].points[0].y += (change * bendSpeed);
    }

    void X2Z1(float change)
    {
        xCurves[1].points[0].y += (change * bendSpeed);
        zCurves[0].points[1].y += (change * bendSpeed);
    }

    void X2Z2(float change)
    {
        xCurves[1].points[1].y += (change * bendSpeed);
        zCurves[1].points[1].y += (change * bendSpeed);
    }
    void X2Z3(float change)
    {
        xCurves[1].points[2].y += (change * bendSpeed);
        zCurves[2].points[1].y += (change * bendSpeed);
    }

    void X2Z4(float change)
    {
        xCurves[1].points[3].y += (change * bendSpeed);
        zCurves[3].points[1].y += (change * bendSpeed);
    }

    void X3Z1(float change)
    {
        xCurves[2].points[0].y += (change * bendSpeed);
        zCurves[0].points[2].y += (change * bendSpeed);
    }

    void X3Z2(float change)
    {
        xCurves[2].points[1].y += (change * bendSpeed);
        zCurves[1].points[2].y += (change * bendSpeed);
    }

    void X3Z3(float change)
    {
        xCurves[2].points[2].y += (change * bendSpeed);
        zCurves[2].points[2].y += (change * bendSpeed);
    }

    void X3Z4(float change)
    {
        xCurves[2].points[3].y += (change * bendSpeed);
        zCurves[3].points[2].y += (change * bendSpeed);
    }

    void X4Z1(float change)
    {
        xCurves[3].points[0].y += (change * bendSpeed);
        zCurves[0].points[3].y += (change * bendSpeed);
    }

    void X4Z2(float change)
    {
        xCurves[3].points[1].y += (change * bendSpeed);
        zCurves[1].points[3].y += (change * bendSpeed);
    }

    void X4Z3(float change)
    {
        xCurves[3].points[2].y += (change * bendSpeed);
        zCurves[2].points[3].y += (change * bendSpeed);
    }

    void X4Z4(float change)
    {
        xCurves[3].points[3].y += (change * bendSpeed);
        zCurves[3].points[3].y += (change * bendSpeed);
    }
    
}

using UnityEngine;
using System.Collections;

public class BendInput : MonoBehaviour {

    public BezierSpline[] xCurves;
    public BezierSpline[] zCurves;

    public float bendRate;

    //private int[][] bendListNE;

    void Start ()
    {
        /*
        for (int i = 0; i < xCurves.Length; i++)
        {
            for (int j = 0; j < xCurves[i].points.Length; j++)
            {
                bendListNE[j][i] = 0;
            }
        }
        */
    }

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

        float bendMultiply = 0.25f;
        float bendDivide = 1;

        X9Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.20f;
        X9Z8(bendMultiply * bendRate / bendDivide);
        X8Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.15f;
        X9Z7(bendMultiply * bendRate / bendDivide);
        X8Z8(bendMultiply * bendRate / bendDivide);
        X7Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.125f;
        X9Z6(bendMultiply * bendRate / bendDivide);
        X8Z7(bendMultiply * bendRate / bendDivide);
        X7Z8(bendMultiply * bendRate / bendDivide);
        X6Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.10f;
        X9Z5(bendMultiply * bendRate / bendDivide);
        X8Z6(bendMultiply * bendRate / bendDivide);
        X7Z7(bendMultiply * bendRate / bendDivide);
        X6Z8(bendMultiply * bendRate / bendDivide);
        X5Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.09f;
        X9Z4(bendMultiply * bendRate / bendDivide);
        X8Z5(bendMultiply * bendRate / bendDivide);
        X7Z6(bendMultiply * bendRate / bendDivide);
        X6Z7(bendMultiply * bendRate / bendDivide);
        X5Z8(bendMultiply * bendRate / bendDivide);
        X4Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.08f;
        X9Z3(bendMultiply * bendRate / bendDivide);
        X8Z4(bendMultiply * bendRate / bendDivide);
        X7Z5(bendMultiply * bendRate / bendDivide);
        X6Z6(bendMultiply * bendRate / bendDivide);
        X5Z7(bendMultiply * bendRate / bendDivide);
        X4Z8(bendMultiply * bendRate / bendDivide);
        X3Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.07f;
        X9Z2(bendMultiply * bendRate / bendDivide);
        X8Z3(bendMultiply * bendRate / bendDivide);
        X7Z4(bendMultiply * bendRate / bendDivide);
        X6Z5(bendMultiply * bendRate / bendDivide);
        X5Z6(bendMultiply * bendRate / bendDivide);
        X4Z7(bendMultiply * bendRate / bendDivide);
        X3Z8(bendMultiply * bendRate / bendDivide);
        X2Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.06f;
        X9Z1(bendMultiply * bendRate / bendDivide);
        X8Z2(bendMultiply * bendRate / bendDivide);
        X7Z3(bendMultiply * bendRate / bendDivide);
        X6Z4(bendMultiply * bendRate / bendDivide);
        X5Z5(bendMultiply * bendRate / bendDivide);
        X4Z6(bendMultiply * bendRate / bendDivide);
        X3Z7(bendMultiply * bendRate / bendDivide);
        X2Z8(bendMultiply * bendRate / bendDivide);
        X1Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.05f;
        X9Z0(bendMultiply * bendRate / bendDivide);
        X8Z1(bendMultiply * bendRate / bendDivide);
        X7Z2(bendMultiply * bendRate / bendDivide);
        X6Z3(bendMultiply * bendRate / bendDivide);
        X5Z4(bendMultiply * bendRate / bendDivide);
        X4Z5(bendMultiply * bendRate / bendDivide);
        X3Z6(bendMultiply * bendRate / bendDivide);
        X2Z7(bendMultiply * bendRate / bendDivide);
        X1Z8(bendMultiply * bendRate / bendDivide);
        X0Z9(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.04f;
        X8Z0(bendMultiply * bendRate / bendDivide);
        X7Z1(bendMultiply * bendRate / bendDivide);
        X6Z2(bendMultiply * bendRate / bendDivide);
        X5Z3(bendMultiply * bendRate / bendDivide);
        X4Z4(bendMultiply * bendRate / bendDivide);
        X3Z5(bendMultiply * bendRate / bendDivide);
        X2Z6(bendMultiply * bendRate / bendDivide);
        X1Z7(bendMultiply * bendRate / bendDivide);
        X0Z8(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.03f;
        X7Z0(bendMultiply * bendRate / bendDivide);
        X6Z1(bendMultiply * bendRate / bendDivide);
        X5Z2(bendMultiply * bendRate / bendDivide);
        X4Z3(bendMultiply * bendRate / bendDivide);
        X3Z4(bendMultiply * bendRate / bendDivide);
        X2Z5(bendMultiply * bendRate / bendDivide);
        X1Z6(bendMultiply * bendRate / bendDivide);
        X0Z7(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.02f;
        X6Z0(bendMultiply * bendRate / bendDivide);
        X5Z1(bendMultiply * bendRate / bendDivide);
        X4Z2(bendMultiply * bendRate / bendDivide);
        X3Z3(bendMultiply * bendRate / bendDivide);
        X2Z4(bendMultiply * bendRate / bendDivide);
        X1Z5(bendMultiply * bendRate / bendDivide);
        X0Z6(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.01f;
        X5Z0(bendMultiply * bendRate / bendDivide);
        X4Z1(bendMultiply * bendRate / bendDivide);
        X3Z2(bendMultiply * bendRate / bendDivide);
        X2Z3(bendMultiply * bendRate / bendDivide);
        X1Z4(bendMultiply * bendRate / bendDivide);
        X0Z5(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.008f;
        X4Z0(bendMultiply * bendRate / bendDivide);
        X3Z1(bendMultiply * bendRate / bendDivide);
        X2Z2(bendMultiply * bendRate / bendDivide);
        X1Z3(bendMultiply * bendRate / bendDivide);
        X0Z4(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.006f;
        X3Z0(bendMultiply * bendRate / bendDivide);
        X2Z1(bendMultiply * bendRate / bendDivide);
        X1Z2(bendMultiply * bendRate / bendDivide);
        X0Z3(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.004f;
        X2Z0(bendMultiply * bendRate / bendDivide);
        X1Z1(bendMultiply * bendRate / bendDivide);
        X0Z2(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.002f;
        X1Z0(bendMultiply * bendRate / bendDivide);
        X0Z1(bendMultiply * bendRate / bendDivide);
        bendMultiply = 0.001f;
        X0Z0(bendMultiply * bendRate / bendDivide);

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

        X9Z9(-0.20f * bendRate);

        X9Z8(-0.19f * bendRate);
        X8Z9(-0.19f * bendRate);

        X9Z7(-0.18f * bendRate);
        X8Z8(-0.18f * bendRate);
        X7Z9(-0.18f * bendRate);

        X9Z6(-0.17f * bendRate);
        X8Z7(-0.17f * bendRate);
        X7Z8(-0.17f * bendRate);
        X6Z9(-0.17f * bendRate);

        X9Z5(-0.16f * bendRate);
        X8Z6(-0.16f * bendRate);
        X7Z7(-0.16f * bendRate);
        X6Z8(-0.16f * bendRate);
        X5Z9(-0.16f * bendRate);

        X9Z4(-0.15f * bendRate);
        X8Z5(-0.15f * bendRate);
        X7Z6(-0.15f * bendRate);
        X6Z7(-0.15f * bendRate);
        X5Z8(-0.15f * bendRate);
        X4Z9(-0.15f * bendRate);

        X9Z3(-0.14f * bendRate);
        X8Z4(-0.14f * bendRate);
        X7Z5(-0.14f * bendRate);
        X6Z6(-0.14f * bendRate);
        X5Z7(-0.14f * bendRate);
        X4Z8(-0.14f * bendRate);
        X3Z9(-0.14f * bendRate);

        X9Z2(-0.13f * bendRate);
        X8Z3(-0.13f * bendRate);
        X7Z4(-0.13f * bendRate);
        X6Z5(-0.13f * bendRate);
        X5Z6(-0.13f * bendRate);
        X4Z7(-0.13f * bendRate);
        X3Z8(-0.13f * bendRate);
        X2Z9(-0.13f * bendRate);

        X9Z1(-0.12f * bendRate);
        X8Z2(-0.12f * bendRate);
        X7Z3(-0.12f * bendRate);
        X6Z4(-0.12f * bendRate);
        X5Z5(-0.12f * bendRate);
        X4Z6(-0.12f * bendRate);
        X3Z7(-0.12f * bendRate);
        X2Z8(-0.12f * bendRate);
        X1Z9(-0.12f * bendRate);

        X9Z0(-0.11f * bendRate);
        X8Z1(-0.11f * bendRate);
        X7Z2(-0.11f * bendRate);
        X6Z3(-0.11f * bendRate);
        X5Z4(-0.11f * bendRate);
        X4Z5(-0.11f * bendRate);
        X3Z6(-0.11f * bendRate);
        X2Z7(-0.11f * bendRate);
        X1Z8(-0.11f * bendRate);
        X0Z9(-0.11f * bendRate);

        X8Z0(-0.10f * bendRate);
        X7Z1(-0.10f * bendRate);
        X6Z2(-0.10f * bendRate);
        X5Z3(-0.10f * bendRate);
        X4Z4(-0.10f * bendRate);
        X3Z5(-0.10f * bendRate);
        X2Z6(-0.10f * bendRate);
        X1Z7(-0.10f * bendRate);
        X0Z8(-0.10f * bendRate);

        X7Z0(-0.09f * bendRate);
        X6Z1(-0.09f * bendRate);
        X5Z2(-0.09f * bendRate);
        X4Z3(-0.09f * bendRate);
        X3Z4(-0.09f * bendRate);
        X2Z5(-0.09f * bendRate);
        X1Z6(-0.09f * bendRate);
        X0Z7(-0.09f * bendRate);

        X6Z0(-0.08f * bendRate);
        X5Z1(-0.08f * bendRate);
        X4Z2(-0.08f * bendRate);
        X3Z3(-0.08f * bendRate);
        X2Z4(-0.08f * bendRate);
        X1Z5(-0.08f * bendRate);
        X0Z6(-0.08f * bendRate);

        X5Z0(-0.07f * bendRate);
        X4Z1(-0.07f * bendRate);
        X3Z2(-0.07f * bendRate);
        X2Z3(-0.07f * bendRate);
        X1Z4(-0.07f * bendRate);
        X0Z5(-0.07f * bendRate);

        X4Z0(-0.06f * bendRate);
        X3Z1(-0.06f * bendRate);
        X2Z2(-0.06f * bendRate);
        X1Z3(-0.06f * bendRate);
        X0Z4(-0.06f * bendRate);

        X3Z0(-0.05f * bendRate);
        X2Z1(-0.05f * bendRate);
        X1Z2(-0.05f * bendRate);
        X0Z3(-0.05f * bendRate);

        X2Z0(-0.04f * bendRate);
        X1Z1(-0.04f * bendRate);
        X0Z2(-0.04f * bendRate);

        X1Z0(-0.03f * bendRate);
        X0Z1(-0.03f * bendRate);

        X0Z0(-0.02f * bendRate);

        Debug.Log("NE-D");
    }

    void SouthEastUp()
    {
        X0Z9(0.05f);

        Debug.Log("SE-U");
    }

    void SouthEastDown()
    {
        X0Z9(-0.05f);

        Debug.Log("SE-D");
    }

    void EastUp()
    {
        X0Z9(0.05f);
        X1Z9(0.05f);
        X2Z9(0.05f);
        X3Z9(0.05f);
        X4Z9(0.05f);
        X5Z9(0.05f);
        X6Z9(0.05f);
        X7Z9(0.05f);
        X8Z9(0.05f);
        X9Z9(0.05f);

        Debug.Log("E-U");
    }

    void EastDown()
    {
        X0Z9(-0.05f);
        X1Z9(-0.05f);
        X2Z9(-0.05f);
        X3Z9(-0.05f);
        X4Z9(-0.05f);
        X5Z9(-0.05f);
        X6Z9(-0.05f);
        X7Z9(-0.05f);
        X8Z9(-0.05f);
        X9Z9(-0.05f);

        Debug.Log("E-D");
    }

    void X0Z0(float change)
    {
        xCurves[0].points[0].y += change;
        zCurves[0].points[0].y += change;
    }

    void X0Z1(float change)
    {
        xCurves[0].points[1].y += change;
        zCurves[1].points[0].y += change;
    }

    void X0Z2(float change)
    {
        xCurves[0].points[2].y += change;
        zCurves[2].points[0].y += change;
    }

    void X0Z3(float change)
    {
        xCurves[0].points[3].y += change;
        zCurves[3].points[0].y += change;
    }

    void X0Z4(float change)
    {
        xCurves[0].points[4].y += change;
        zCurves[4].points[0].y += change;
    }

    void X0Z5(float change)
    {
        xCurves[0].points[5].y += change;
        zCurves[5].points[0].y += change;
    }

    void X0Z6(float change)
    {
        xCurves[0].points[6].y += change;
        zCurves[6].points[0].y += change;
    }

    void X0Z7(float change)
    {
        xCurves[0].points[7].y += change;
        zCurves[7].points[0].y += change;
    }

    void X0Z8(float change)
    {
        xCurves[0].points[8].y += change;
        zCurves[8].points[0].y += change;
    }

    void X0Z9(float change)
    {
        xCurves[0].points[9].y += change;
        zCurves[9].points[0].y += change;
    }

    void X1Z0(float change)
    {
        xCurves[1].points[0].y += change;
        zCurves[0].points[1].y += change;
    }

    void X1Z1(float change)
    {
        xCurves[1].points[1].y += change;
        zCurves[1].points[1].y += change;
    }

    void X1Z2(float change)
    {
        xCurves[1].points[2].y += change;
        zCurves[2].points[1].y += change;
    }

    void X1Z3(float change)
    {
        xCurves[1].points[3].y += change;
        zCurves[3].points[1].y += change;
    }

    void X1Z4(float change)
    {
        xCurves[1].points[4].y += change;
        zCurves[4].points[1].y += change;
    }

    void X1Z5(float change)
    {
        xCurves[1].points[5].y += change;
        zCurves[5].points[1].y += change;
    }

    void X1Z6(float change)
    {
        xCurves[1].points[6].y += change;
        zCurves[6].points[1].y += change;
    }

    void X1Z7(float change)
    {
        xCurves[1].points[7].y += change;
        zCurves[7].points[1].y += change;
    }

    void X1Z8(float change)
    {
        xCurves[1].points[8].y += change;
        zCurves[8].points[1].y += change;
    }

    void X1Z9(float change)
    {
        xCurves[1].points[9].y += change;
        zCurves[9].points[1].y += change;
    }

    void X2Z0(float change)
    {
        xCurves[2].points[0].y += change;
        zCurves[0].points[2].y += change;
    }

    void X2Z1(float change)
    {
        xCurves[2].points[1].y += change;
        zCurves[1].points[2].y += change;
    }

    void X2Z2(float change)
    {
        xCurves[2].points[2].y += change;
        zCurves[2].points[2].y += change;
    }

    void X2Z3(float change)
    {
        xCurves[2].points[3].y += change;
        zCurves[3].points[2].y += change;
    }

    void X2Z4(float change)
    {
        xCurves[2].points[4].y += change;
        zCurves[4].points[2].y += change;
    }

    void X2Z5(float change)
    {
        xCurves[2].points[5].y += change;
        zCurves[5].points[2].y += change;
    }

    void X2Z6(float change)
    {
        xCurves[2].points[6].y += change;
        zCurves[6].points[2].y += change;
    }

    void X2Z7(float change)
    {
        xCurves[2].points[7].y += change;
        zCurves[7].points[2].y += change;
    }

    void X2Z8(float change)
    {
        xCurves[2].points[8].y += change;
        zCurves[8].points[2].y += change;
    }

    void X2Z9(float change)
    {
        xCurves[2].points[9].y += change;
        zCurves[9].points[2].y += change;
    }

    void X3Z0(float change)
    {
        xCurves[3].points[0].y += change;
        zCurves[0].points[3].y += change;
    }

    void X3Z1(float change)
    {
        xCurves[3].points[1].y += change;
        zCurves[1].points[3].y += change;
    }

    void X3Z2(float change)
    {
        xCurves[3].points[2].y += change;
        zCurves[2].points[3].y += change;
    }

    void X3Z3(float change)
    {
        xCurves[3].points[3].y += change;
        zCurves[3].points[3].y += change;
    }

    void X3Z4(float change)
    {
        xCurves[3].points[4].y += change;
        zCurves[4].points[3].y += change;
    }

    void X3Z5(float change)
    {
        xCurves[3].points[5].y += change;
        zCurves[5].points[3].y += change;
    }

    void X3Z6(float change)
    {
        xCurves[3].points[6].y += change;
        zCurves[6].points[3].y += change;
    }

    void X3Z7(float change)
    {
        xCurves[3].points[7].y += change;
        zCurves[7].points[3].y += change;
    }

    void X3Z8(float change)
    {
        xCurves[3].points[8].y += change;
        zCurves[8].points[3].y += change;
    }

    void X3Z9(float change)
    {
        xCurves[3].points[9].y += change;
        zCurves[9].points[3].y += change;
    }

    void X4Z0(float change)
    {
        xCurves[4].points[0].y += change;
        zCurves[0].points[4].y += change;
    }

    void X4Z1(float change)
    {
        xCurves[4].points[1].y += change;
        zCurves[1].points[4].y += change;
    }

    void X4Z2(float change)
    {
        xCurves[4].points[2].y += change;
        zCurves[2].points[4].y += change;
    }

    void X4Z3(float change)
    {
        xCurves[4].points[3].y += change;
        zCurves[3].points[4].y += change;
    }

    void X4Z4(float change)
    {
        xCurves[4].points[4].y += change;
        zCurves[4].points[4].y += change;
    }

    void X4Z5(float change)
    {
        xCurves[4].points[5].y += change;
        zCurves[5].points[4].y += change;
    }

    void X4Z6(float change)
    {
        xCurves[4].points[6].y += change;
        zCurves[6].points[4].y += change;
    }

    void X4Z7(float change)
    {
        xCurves[4].points[7].y += change;
        zCurves[7].points[4].y += change;
    }

    void X4Z8(float change)
    {
        xCurves[4].points[8].y += change;
        zCurves[8].points[4].y += change;
    }

    void X4Z9(float change)
    {
        xCurves[4].points[9].y += change;
        zCurves[9].points[4].y += change;
    }

    void X5Z0(float change)
    {
        xCurves[5].points[0].y += change;
        zCurves[0].points[5].y += change;
    }

    void X5Z1(float change)
    {
        xCurves[5].points[1].y += change;
        zCurves[1].points[5].y += change;
    }

    void X5Z2(float change)
    {
        xCurves[5].points[2].y += change;
        zCurves[2].points[5].y += change;
    }

    void X5Z3(float change)
    {
        xCurves[5].points[3].y += change;
        zCurves[3].points[5].y += change;
    }

    void X5Z4(float change)
    {
        xCurves[5].points[4].y += change;
        zCurves[4].points[5].y += change;
    }

    void X5Z5(float change)
    {
        xCurves[5].points[5].y += change;
        zCurves[5].points[5].y += change;
    }

    void X5Z6(float change)
    {
        xCurves[5].points[6].y += change;
        zCurves[6].points[5].y += change;
    }

    void X5Z7(float change)
    {
        xCurves[5].points[7].y += change;
        zCurves[7].points[5].y += change;
    }

    void X5Z8(float change)
    {
        xCurves[5].points[8].y += change;
        zCurves[8].points[5].y += change;
    }

    void X5Z9(float change)
    {
        xCurves[5].points[9].y += change;
        zCurves[9].points[5].y += change;
    }

    void X6Z0(float change)
    {
        xCurves[6].points[0].y += change;
        zCurves[0].points[6].y += change;
    }

    void X6Z1(float change)
    {
        xCurves[6].points[1].y += change;
        zCurves[1].points[6].y += change;
    }

    void X6Z2(float change)
    {
        xCurves[6].points[2].y += change;
        zCurves[2].points[6].y += change;
    }

    void X6Z3(float change)
    {
        xCurves[6].points[3].y += change;
        zCurves[3].points[6].y += change;
    }

    void X6Z4(float change)
    {
        xCurves[6].points[4].y += change;
        zCurves[4].points[6].y += change;
    }

    void X6Z5(float change)
    {
        xCurves[6].points[5].y += change;
        zCurves[5].points[6].y += change;
    }

    void X6Z6(float change)
    {
        xCurves[6].points[6].y += change;
        zCurves[6].points[6].y += change;
    }

    void X6Z7(float change)
    {
        xCurves[6].points[7].y += change;
        zCurves[7].points[6].y += change;
    }

    void X6Z8(float change)
    {
        xCurves[6].points[8].y += change;
        zCurves[8].points[6].y += change;
    }

    void X6Z9(float change)
    {
        xCurves[6].points[9].y += change;
        zCurves[9].points[6].y += change;
    }

    void X7Z0(float change)
    {
        xCurves[7].points[0].y += change;
        zCurves[0].points[7].y += change;
    }

    void X7Z1(float change)
    {
        xCurves[7].points[1].y += change;
        zCurves[1].points[7].y += change;
    }

    void X7Z2(float change)
    {
        xCurves[7].points[2].y += change;
        zCurves[2].points[7].y += change;
    }

    void X7Z3(float change)
    {
        xCurves[7].points[3].y += change;
        zCurves[3].points[7].y += change;
    }

    void X7Z4(float change)
    {
        xCurves[7].points[4].y += change;
        zCurves[4].points[7].y += change;
    }

    void X7Z5(float change)
    {
        xCurves[7].points[5].y += change;
        zCurves[5].points[7].y += change;
    }

    void X7Z6(float change)
    {
        xCurves[7].points[6].y += change;
        zCurves[6].points[7].y += change;
    }

    void X7Z7(float change)
    {
        xCurves[7].points[7].y += change;
        zCurves[7].points[7].y += change;
    }

    void X7Z8(float change)
    {
        xCurves[7].points[8].y += change;
        zCurves[8].points[7].y += change;
    }

    void X7Z9(float change)
    {
        xCurves[7].points[9].y += change;
        zCurves[9].points[7].y += change;
    }

    void X8Z0(float change)
    {
        xCurves[8].points[0].y += change;
        zCurves[0].points[8].y += change;
    }

    void X8Z1(float change)
    {
        xCurves[8].points[1].y += change;
        zCurves[1].points[8].y += change;
    }

    void X8Z2(float change)
    {
        xCurves[8].points[2].y += change;
        zCurves[2].points[8].y += change;
    }

    void X8Z3(float change)
    {
        xCurves[8].points[3].y += change;
        zCurves[3].points[8].y += change;
    }

    void X8Z4(float change)
    {
        xCurves[8].points[4].y += change;
        zCurves[4].points[8].y += change;
    }

    void X8Z5(float change)
    {
        xCurves[8].points[5].y += change;
        zCurves[5].points[8].y += change;
    }

    void X8Z6(float change)
    {
        xCurves[8].points[6].y += change;
        zCurves[6].points[8].y += change;
    }

    void X8Z7(float change)
    {
        xCurves[8].points[7].y += change;
        zCurves[7].points[8].y += change;
    }

    void X8Z8(float change)
    {
        xCurves[8].points[8].y += change;
        zCurves[8].points[8].y += change;
    }

    void X8Z9(float change)
    {
        xCurves[8].points[9].y += change;
        zCurves[9].points[8].y += change;
    }

    void X9Z0(float change)
    {
        xCurves[9].points[0].y += change;
        zCurves[0].points[9].y += change;
    }

    void X9Z1(float change)
    {
        xCurves[9].points[1].y += change;
        zCurves[1].points[9].y += change;
    }

    void X9Z2(float change)
    {
        xCurves[9].points[2].y += change;
        zCurves[2].points[9].y += change;
    }

    void X9Z3(float change)
    {
        xCurves[9].points[3].y += change;
        zCurves[3].points[9].y += change;
    }

    void X9Z4(float change)
    {
        xCurves[9].points[4].y += change;
        zCurves[4].points[9].y += change;
    }

    void X9Z5(float change)
    {
        xCurves[9].points[5].y += change;
        zCurves[5].points[9].y += change;
    }

    void X9Z6(float change)
    {
        xCurves[9].points[6].y += change;
        zCurves[6].points[9].y += change;
    }

    void X9Z7(float change)
    {
        xCurves[9].points[7].y += change;
        zCurves[7].points[9].y += change;
    }

    void X9Z8(float change)
    {
        xCurves[9].points[8].y += change;
        zCurves[8].points[9].y += change;
    }

    void X9Z9(float change)
    {
        xCurves[9].points[9].y += change;
        zCurves[9].points[9].y += change;
    }
}

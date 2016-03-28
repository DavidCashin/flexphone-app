using UnityEngine;
using System.Collections;

public class BendScript : MonoBehaviour {

    public BezierCurve curve;

    private int currentPoint;

    void Start ()
    {
        currentPoint = 0;
        Debug.Log(currentPoint);
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentPoint > 0)
            {
                currentPoint -= 1;
                Debug.Log(currentPoint);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPoint < 3)
            {
                currentPoint += 1;
                Debug.Log(currentPoint);
            }

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            curve.points[currentPoint].y += 0.1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            curve.points[currentPoint].y -= 0.1f;
        }
    }
}

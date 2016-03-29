using UnityEngine;
using System.Collections;

public class SplineBender : MonoBehaviour
{

    public BezierSpline spline;

    private int currentPoint;
    private int pointsLength;

    void Start()
    {
        currentPoint = 0;
        pointsLength = spline.points.Length;
        Debug.Log("Points: " + pointsLength);
        Debug.Log(currentPoint);
    }

    void Update()
    {

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
            if (currentPoint < (pointsLength-1))
            {
                currentPoint += 1;
                Debug.Log(currentPoint);
            }

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (currentPoint == 0 || currentPoint == (pointsLength - 1))
            {
                spline.points[0].y += 0.1f;
                spline.points[pointsLength-1].y += 0.1f;
            }
            else
            {
                spline.points[currentPoint].y += 0.1f;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentPoint == 0 || currentPoint == (pointsLength - 1))
            {
                spline.points[0].y -= 0.1f;
                spline.points[pointsLength - 1].y -= 0.1f;
            }
            else
            {
                spline.points[currentPoint].y -= 0.1f;
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplineDecorator : MonoBehaviour
{

    public BezierSpline spline;

    public int frequency;

    public bool lookForward;

    public Transform[] items;

    private void Awake()
    {
        Decorate();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Keypad7))
        {
            Redecorate();
        }

        if (Input.GetKey(KeyCode.Keypad9))
        {
            Redecorate();
        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            Redecorate();
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            Redecorate();
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            Redecorate();
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            Redecorate();
        }
    }

    private void Decorate()
    {

        if (frequency <= 0 || items == null || items.Length == 0)
        {
            return;
        }
        float stepSize = frequency * items.Length;
        if (stepSize == 1)
        {
            stepSize = 1f / stepSize;
        }
        else {
            stepSize = 1f / (stepSize - 1);
        }
        int cubeNumber = 0;
        for (int p = 0, f = 0; f < frequency; f++)
        {
            for (int i = 0; i < items.Length; i++, p++)
            {
                Transform item = Instantiate(items[i]) as Transform;
                item.name = spline.name + "Cube" + cubeNumber;
                cubeNumber++;
                Vector3 position = spline.GetPoint(p * stepSize);
                item.transform.localPosition = position;
                if (lookForward)
                {
                    item.transform.LookAt(position + spline.GetDirection(p * stepSize));
                }
                item.transform.parent = transform;
            }
        }
    }

    private void Redecorate()
    {
        //var children = new List<GameObject>();
        //foreach (Transform child in transform) children.Add(child.gameObject);
        //children.ForEach(child => Destroy(child));

        float stepSize = frequency * items.Length;
        if (stepSize == 1)
        {
            stepSize = 1f / stepSize;
        }
        else {
            stepSize = 1f / (stepSize - 1);
        }
        int cubeNumber = 0;
        for (int p = 0, f = 0; f < frequency; f++)
        {
            for (int i = 0; i < items.Length; i++, p++)
            {
                GameObject cube = GameObject.Find(spline.name + "Cube" + cubeNumber);
                cubeNumber++;
                Vector3 position = spline.GetPoint(p * stepSize);
                cube.transform.localPosition = position;
                if (lookForward)
                {
                    cube.transform.LookAt(position + spline.GetDirection(p * stepSize));
                }
            }
        }
    }
}
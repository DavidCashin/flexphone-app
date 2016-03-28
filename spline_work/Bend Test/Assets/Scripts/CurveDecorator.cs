using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurveDecorator : MonoBehaviour
{

    public BezierCurve curve;

    public int frequency;

    public bool lookForward;

    public Transform[] items;

    private void Awake()
    {
        Decorate();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Decorate();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Decorate();
        }
    }

    private void Decorate()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

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
        for (int p = 0, f = 0; f < frequency; f++)
        {
            for (int i = 0; i < items.Length; i++, p++)
            {
                Transform item = Instantiate(items[i]) as Transform;
                Vector3 position = curve.GetPoint(p * stepSize);
                item.transform.localPosition = position;
                if (lookForward)
                {
                    item.transform.LookAt(position + curve.GetDirection(p * stepSize));
                }
                item.transform.parent = transform;
            }
        }
    }
}
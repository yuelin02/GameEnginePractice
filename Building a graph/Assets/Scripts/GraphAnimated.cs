﻿using UnityEngine;

public class GraphAnimated : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 50)]
    public int resolution = 50;

    [Range(0, 1)]
    public int function;

    Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;

        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.y = 0f;
        position.z = 0f;

        points = new Transform[resolution];

        for (int i = 0; i < points.Length; i++)
        {

            //instantiate the cube
            Transform point = Instantiate(pointPrefab);

            //set the cubes' position from -1 to 1 along x axis
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;

            //set the cubes' scale
            point.localScale = scale;
            point.SetParent(transform, false);

            points[i] = point;
        }
    }

    private void Update()
    {
        float t = Time.time;
        GraphFunction f;

        if (function == 0)
        {
            f = SineFunction;
        }
        else
        {
            f = MultiSineFunction;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;

            position.y = f(position.x, t);

            point.localPosition = position;
        }
    }

    static float SineFunction(float x, float t) {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    static float MultiSineFunction (float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }
}
﻿using UnityEngine;

public class GraphAnimated : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 50)]
    public int resolution = 50;

    public GraphFunctionName function;

    Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;

        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.y = 0f;
        position.z = 0f;

        points = new Transform[resolution * resolution];

        for (int i = 0, z = 0; z < resolution; z++)
        {
            position.z = (z + 0.5f) * step - 1f;

            for (int x = 0; x < resolution; x++, i++)
            {
                //instantiate the cube
                Transform point = Instantiate(pointPrefab);

                //set the cubes' position from -1 to 1 along x axis
                position.x = (x + 0.5f) * step - 1f;
                point.localPosition = position;

                //set the cubes' scale
                point.localScale = scale;
                point.SetParent(transform, false);

                points[i] = point;
            }
        }
    }

    private void Update()
    {
        float t = Time.time;
        GraphFunction f = functions[(int)function];

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;

            position.y = f(position.x, position.z, t);

            point.localPosition = position;
        }
    }
    const float pi = Mathf.PI;

    static float SineFunction(float x, float z, float t) {
        return Mathf.Sin(pi * (x + t));
    }

    static float MultiSineFunction (float x, float z, float t)
    {
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(2f * pi * (x + 2f * t)) * 0.5f;
        y *= 2f / 3f;
        return y;
    }

    static float Sine2DFunction(float x, float z, float t)
    {
        //return Mathf.Sin(pi * (x + z + t));
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(pi * (z + t));
        y *= 0.5f;
        return y;
    }

    static GraphFunction[] functions =
    {
        SineFunction, Sine2DFunction, MultiSineFunction
    };

}
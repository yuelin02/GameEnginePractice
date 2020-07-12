﻿using UnityEngine;
using System.Collections;
using System;

public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public int maxDepth;
    private int depth;

    public float childScale;

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if(depth < maxDepth)
        {
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.up);
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.right);
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.left);
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.down);

            StartCoroutine(CreateChildren());
        }
    }

    private IEnumerator CreateChildren()
    {
        yield return new WaitForSeconds(0.1f);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.up);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.down);

        yield return new WaitForSeconds(0.1f);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.forward);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.back);

        yield return new WaitForSeconds(0.1f);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.right);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.left);
        
    }

    private void Initialize(Fractal parent, Vector3 direction)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;

        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = direction * (0.5f + 0.5f * childScale);
    }
}
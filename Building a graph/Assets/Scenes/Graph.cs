using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 50)]
    public int resolution = 50;
    Transform[] points;

    private void Awake()
    {
        float step = 2f/resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        points = new Transform[resolution];

        for (int i = 0; i < points.Length; i++) {

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
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}
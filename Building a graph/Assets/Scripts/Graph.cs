using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 50)]
    public int resolution = 50;



    private void Awake()
    {
        float step = 2f / resolution;

        Vector3 scale = Vector3.one * step;
        Vector3 position;


        position.z = 0f;



        for (int i = 0; i < resolution; i++) {

            //instantiate the cube
            Transform point = Instantiate(pointPrefab);

            //set the cubes' position from -1 to 1 along x axis
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x;
            point.localPosition = position;

            //set the cubes' scale
            point.localScale = scale;
            point.SetParent(transform, false);


        }
    }

}
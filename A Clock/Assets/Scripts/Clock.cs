using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hrsTransform, minsTransform, secsTransform;
    public bool continuous;

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;


    private void Update()
    {
        if (continuous)
        {
            UpdateContinours();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    private void UpdateContinours()
    {
        System.TimeSpan time = System.DateTime.Now.TimeOfDay;

        Debug.Log(time);

        hrsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }

    private void UpdateDiscrete()
    {
        System.DateTime time = System.DateTime.Now;

        Debug.Log(time);

        hrsTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minsTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public int FPS { get; private set; }

    void Upate()
    {
        /* use unscaledDeltaTime because the Time.deltaTime is not the actual time it took to process the last frame,
         * it is influenced by the current time scale.
         */
        FPS = (int)(1f / Time.unscaledDeltaTime);
    }
}

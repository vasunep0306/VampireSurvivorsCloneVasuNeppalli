using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    public Transform bar;

    /// <summary>
    /// This method sets the state of the bar by scaling it according to the ratio of current to max value.
    /// </summary>
    /// <param name="current">The current value of the status.</param>
    /// <param name="max">The maximum value of the status.</param>
    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if(state < 0f) { state = 0f; }
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}

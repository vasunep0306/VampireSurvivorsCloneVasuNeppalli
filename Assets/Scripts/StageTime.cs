using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimeUI timerUI;

    private void Awake()
    {
        timerUI = FindObjectOfType<TimeUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timerUI.UpdateTime(time);
    }

}

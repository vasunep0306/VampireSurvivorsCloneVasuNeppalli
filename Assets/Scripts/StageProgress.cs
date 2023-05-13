using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProgress : MonoBehaviour
{
    public StageTime stageTime;
    public float progressTimeRate = 30f;
    public float progressPerSplit = 0.2f;

    public float Progress
    {
        get
        {
            return 1f + stageTime.time / progressTimeRate * progressPerSplit;
        }
    }

    private void Awake()
    {
        if(stageTime == null) { stageTime = GetComponent<StageTime>(); }
    }
}

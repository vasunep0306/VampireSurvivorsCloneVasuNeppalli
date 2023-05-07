using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Awake()
    {
        if(text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        text.text = $"{minutes}:{seconds.ToString("00")}";
    }
}

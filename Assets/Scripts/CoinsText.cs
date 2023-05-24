using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinsText : MonoBehaviour
{
    public DataContainer dataContainer;
    public TMPro.TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = $"Coins: {dataContainer.coins}";
    }
}

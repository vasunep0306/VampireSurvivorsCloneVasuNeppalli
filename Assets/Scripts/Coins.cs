using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired;
    public TMPro.TextMeshProUGUI coinText;

    public void Add(int count)
    {
        coinAcquired += count;
        coinText.text = $"COINS: {coinAcquired}";
    }
}

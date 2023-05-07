using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public DataContainer data;
    public TMPro.TextMeshProUGUI coinText;


    /// <summary>
    /// Adds the specified count to the current coin count and updates the coin count text display.
    /// </summary>
    /// <param name="count">The number of coins to be added to the current coin count.</param>
    public void Add(int count)
    {
        data.coins += count;
        coinText.text = $"COINS: {data.coins}";
    }
}

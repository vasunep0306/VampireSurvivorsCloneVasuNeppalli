using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that contains some utility methods for common tasks
/// </summary>
public class UtilityTools
{
    /// <summary>
    /// Generates a random position within a square area
    /// </summary>
    /// <param name="spawnArea">The size of the square area in x and y dimensions</param>
    /// <returns>A vector3 representing the random position</returns>
    public static Vector3 GenerateRandomPositionSquarePattern(Vector2 spawnArea)
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f; // A random factor to determine the sign of the position
        if (UnityEngine.Random.value > 0.5f) // A random condition to decide whether to use the x or y axis
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x); // A random value between the negative and positive bounds of the x axis
            position.y = spawnArea.y * f; // The maximum or minimum value of the y axis depending on the sign factor
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y); // A random value between the negative and positive bounds of the y axis
            position.x = spawnArea.x * f; // The maximum or minimum value of the x axis depending on the sign factor
        }
        position.z = 0f; // The z value is always zero
        return position; // Returns the generated position
    }
}



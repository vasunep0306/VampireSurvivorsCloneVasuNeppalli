using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;
    public GameObject damageMessage;
    List<TMPro.TextMeshPro> messagesPool;
    int objectCount = 10;
    int count = 0;


    /// <summary>
    /// Instantiates a damage message game object and adds it to the messages pool.
    /// </summary>
    public void Populate()
    {
        GameObject go = Instantiate(damageMessage, transform);
        messagesPool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        messagesPool = new List<TMPro.TextMeshPro>();
        for (int i = 0; i < objectCount; i++)
        {
            Populate();
        }
    }

    /// <summary>
    /// Displays a text message at a given world position and cycles through the messages pool.
    /// </summary>
    /// <param name="text">The text to be displayed.</param>
    /// <param name="worldPosition">The world position of the message.</param>
    public void PostMessage(string text, Vector3 worldPosition)
    {
        messagesPool[count].gameObject.SetActive(true);
        messagesPool[count].transform.position = worldPosition;
        messagesPool[count].text = text;
        count += 1;
        if (count >= objectCount)
        {
            count = 0;
        }
    }
}

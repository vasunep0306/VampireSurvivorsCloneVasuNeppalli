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

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class NameInput : MonoBehaviour
{

    public TMP_InputField input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input.onEndEdit.AddListener(SendName);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SendName(string name)
    {
        NameHandler.Instance.InitName(name);
    }
}

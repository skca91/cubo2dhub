using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeDebug : MonoBehaviour {

    [SerializeField]
    Text DebugText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDebugText(string text) {
        DebugText.text = text;
    }

    public void SetDebugTextLog(string text)
    {
        DebugText.text = text+"\n";
    }
}

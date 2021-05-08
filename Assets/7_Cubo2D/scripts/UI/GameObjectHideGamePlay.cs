using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectHideGamePlay : MonoBehaviour {

    [SerializeField]
    bool OcultarPlayEditor = false;
    [SerializeField]
    bool OcultarAndroid = true;
    [SerializeField]
    bool OcultarIos = true;
    [SerializeField]
    bool OcultarWebGL = true;
    [SerializeField]
    bool OcultarWindows = true;
    [SerializeField]
    bool OcultarOSX = true;
    [SerializeField]
    bool OcultarLinux = true;
    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        this.gameObject.SetActive(!OcultarPlayEditor);
#endif

#if UNITY_WEBGL
        this.gameObject.SetActive(!OcultarWebGL);
#elif UNITY_ANDROID
        this.gameObject.SetActive(!OcultarAndroid);
#elif UNITY_IPHONE
         this.gameObject.SetActive(!OcultarIos);
#elif UNITY_STANDALONE_OSX
         this.gameObject.SetActive(!OcultarOSX);
#elif UNITY_STANDALONE_WIN
         this.gameObject.SetActive(!OcultarWindows);
#elif UNITY_STANDALONE_LINUX
         this.gameObject.SetActive(!OcultarLinux);
#else
#endif



    }

    // Update is called once per frame
    void Update () {
		
	}
}

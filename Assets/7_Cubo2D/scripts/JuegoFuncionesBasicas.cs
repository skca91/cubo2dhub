using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoFuncionesBasicas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCerrarJuegoQuit()
    {

        Application.Quit();
    }

    public void OnClickCerrarJuegoYCalificar()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Application.identifier);
#elif UNITY_IPHONE
        //Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
#endif
        Invoke("OnClickCerrarJuegoQuit", 0.5f);
    }
}

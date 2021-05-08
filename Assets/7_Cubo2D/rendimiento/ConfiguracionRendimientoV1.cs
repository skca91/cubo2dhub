using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracionRendimientoV1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Text fps;
    int cont,cont2;

    void Start()
    {
       Application.targetFrameRate = 60;
        Invoke("MinFPS",1);
        // InvokeRepeating("ActualizarFPSText", 0,0.3f);
        InvokeRepeating("fpsUpdate",1,1);
    }

    public void fpsUpdate()
    {
        /*if (fps != null)
            fps.text = cont.ToString("##");*/
        cont2= cont;
        cont = 0;
    }

    public void Update()
    {
        if (fps != null)
            fps.text = (1.0f / Time.deltaTime).ToString("##") + "|"+ cont2.ToString("##");
        cont++;
    }

    /*public void ActualizarFPSText() {
        if (fps != null)
            fps.text = (1.0f / Time.deltaTime).ToString("##");
    }*/

    public void MinFPS() {
        Application.targetFrameRate = 14;
//        Debug.Log("MinFPS");
    }

    public void MaxFPS() {
        Application.targetFrameRate = 60;
        CancelInvoke("MinFPS");
        Invoke("MinFPS", 2);
    //   Debug.Log("MaxFPS");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCarga : MonoBehaviour
{
    [SerializeField]
    Image CargandoImage;
    [SerializeField]
    float duracion = 1.2f;
    [SerializeField]
    Text PorcentajeText;
    [SerializeField]
    Button ContinuarButton;
    float frecuencia = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        MostrarCarga();
    }

    public void cargando() {
        if(CargandoImage.fillAmount > 0.99f)
        {
            CancelInvoke("cargando");
            ContinuarButton.interactable = true;
        }
        else {
            CargandoImage.fillAmount += frecuencia;
            PorcentajeText.text = (CargandoImage.fillAmount*100).ToString("#00'%'");
        }
    }

    public void MostrarCarga() {
        frecuencia = duracion / 30;
        CargandoImage.fillAmount = 0;
        ContinuarButton.interactable = false;
        CancelInvoke("cargando");
        InvokeRepeating("cargando", 0, frecuencia);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickContinuar() {
        SendMessage("hideMenu");
        CancelInvoke("cargando");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiNivelIconoDescripcion : MonoBehaviour
{

    public GameObject duenio;
    public string Id;
    /*Se usa para remplazar el mensaje*/
    public string EtiquetaMensaje;
    public Image IconoImage;
    public Text TituloText;
    public Text DescripicionText;
    public Button IniciarButton;

    public string Titulo
    {
        get
        {
            return TituloText.text;
        }

        set
        {
            TituloText.text = value;
        }
    }

    public string Descripicion
    {
        get
        {
            return DescripicionText.text;
        }

        set
        {
            DescripicionText.text = value;
        }
    }

    // Use this for initialization
    void Start()
    { 
        if(IniciarButton!=null)
        IniciarButton.onClick.AddListener(OnClickIniciarNivel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClickIniciarNivel()
    {
        if (duenio != null)
        {
            if (string.IsNullOrEmpty(EtiquetaMensaje))
            {
                duenio.SendMessage("OnClickIniciarNivel", Id);
            }
            else
            {
                duenio.SendMessage(EtiquetaMensaje, Id);
            }

        }
    }


}

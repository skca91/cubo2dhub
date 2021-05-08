using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBotonIconoID : MonoBehaviour {

    public GameObject Duenio;
    public string Id;
    public string EtiquetaMensaje;
    [SerializeField]
    private Image IconoImage;
    [SerializeField]
    private Button IniciarButton;
	// Use this for initialization
	void Start () {
        IniciarButton.onClick.AddListener(OnClickIniciarNivel);
    }

    void OnClickIniciarNivel()
    {
        if (Duenio != null)
        {
            if (string.IsNullOrEmpty(EtiquetaMensaje))
            {
                Duenio.SendMessage("OnClickIniciarNivel", Id);
            }
            else
            {
                Duenio.SendMessage(EtiquetaMensaje, Id);
            }

        }
    }

    public Sprite Icono
    {
        set { IconoImage.sprite = value; }
        get { return IconoImage.sprite; }
    }

    public Color ColorIcono {
        set { IconoImage.color = value; }
        get { return IconoImage.color; }
    }
}

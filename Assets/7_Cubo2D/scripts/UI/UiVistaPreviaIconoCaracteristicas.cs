using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiVistaPreviaIconoCaracteristicas : MonoBehaviour
{

    [SerializeField]
    private Image VistaPreviaIcono;
    [SerializeField]
    private Text[] CampoGenerico;

    public Sprite VistaPreviaIcono1
    {
        get
        {
            return VistaPreviaIcono.sprite;
        }

        set
        {
            VistaPreviaIcono.sprite = value;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool ActualizarCampo(string nombre,string value) {

        foreach (Text Campo in CampoGenerico)
        {
            if (Campo.name.Equals(nombre)) {
                Campo.text = value;
                return true;
            }
        }

        return false;
    }
}

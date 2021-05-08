using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviarMensajeOnStart : MonoBehaviour {

	public enum modoMensaje{
		hermano,
		padre,
		hijo
	}

	public string mensaje;
	public bool usarID = false;
	public string id;
	public modoMensaje modo = modoMensaje.padre;
	// Use this for initialization
	void Start () {
        Invoke("MensajeConRetraso",0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MensajeConRetraso() {
        if (modo == modoMensaje.padre)
        {
            if (usarID)
            {
                SendMessageUpwards(mensaje, id);
            }
            else
            {
                SendMessageUpwards(mensaje);
            }
        }
        else if (modo == modoMensaje.hermano)
        {
            if (usarID)
            {
                SendMessage(mensaje, id);
            }
            else
            {
                SendMessage(mensaje);
            }
        }
    }
}

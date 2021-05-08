using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleClick2D : MonoBehaviour {

	public enum modoMensaje
	{
		hermano,
		padre,
		hijos
	}


	public string metedo = "ninguno";
	public bool usarID = false;
	public string id;
	public modoMensaje modo = modoMensaje.hermano;
    public float CooldDownBloqueo = 0;

    bool activo = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivarBotonDespuesCoolDown() {
        activo = true;
    }

    public void ninguno(){
	
	}

	public void OnMouseDown(){

        if (!activo)
            return;

        activo = false;
        Invoke("ActivarBotonDespuesCoolDown", CooldDownBloqueo);
		if (modo == modoMensaje.padre) {
			if (usarID) {
				SendMessageUpwards (metedo,id);
			} else {
				SendMessageUpwards (metedo);
			}
		}else if(modo == modoMensaje.hermano){
			if (usarID) {
				SendMessage (metedo,id);
			} else {
				SendMessage (metedo);
			}
		}
        else if (modo == modoMensaje.hijos)
        {
            if (usarID)
            {
                BroadcastMessage(metedo, id);
            }
            else
            {
                BroadcastMessage(metedo);
            }
        }
    }
}

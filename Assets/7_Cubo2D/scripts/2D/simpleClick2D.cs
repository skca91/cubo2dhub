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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ninguno(){
	
	}

	public void OnMouseDown(){
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
	}
}

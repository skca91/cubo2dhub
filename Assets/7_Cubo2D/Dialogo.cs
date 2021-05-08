using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour {

	public UiDialogo dialogoMenu;
	public GameObject duenio;
	public bool ocultarAutomatico = true;

	// Use this for initialization
	void Start () {
		dialogoMenu.onClickNoButton (respuestaDialogoNo);
		dialogoMenu.onClickSiButton (respuestaDialogoSi);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void mostrarDialogo(){
		mostrarDialogo (null,"Prueba dialogo","Esta seguro","Si","No");
	}

	public void mostrarDialogo(string _titulo, string _descripcion){
		mostrarDialogo (null,_titulo,_descripcion,"Si","No");
	}

	public void mostrarDialogo(GameObject _duenio,string _titulo, string _descripcion, string _textoSi, string _textoNo){
		if (dialogoMenu != null) {
			duenio = _duenio;
			dialogoMenu.titulo = _titulo;
			dialogoMenu.descripcion = _descripcion;
			dialogoMenu.textoSiButton = _textoSi;
			dialogoMenu.textoNoButton = _textoNo;
			dialogoMenu.SendMessage ("showMenu");
		} else {
			Debug.Log ("dialogoMenu No encontrado -Arrastre UiDialogo en el editor");
		}

	}

	void respuestaDialogoSi(){
		if (duenio != null) {
			duenio.SendMessage ("respuestaDialogo",true);
		} else {
			SendMessage ("RespuestaDialogo",true);
		}
		dialogoMenu.SendMessage ("hideMenu");
	}

	void respuestaDialogoNo(){
		if (duenio != null) {
			duenio.SendMessage ("respuestaDialogo",false);
		} else {
			SendMessage ("RespuestaDialogo", false);
		}
		dialogoMenu.SendMessage ("hideMenu");
	}
}

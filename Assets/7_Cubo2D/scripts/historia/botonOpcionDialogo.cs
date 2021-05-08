using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class botonOpcionDialogo : MonoBehaviour {

	controladorDeDialogo controladorPadre;
	Button boton;
	textoIdiomaV2 texto;
	public string nodo;
	public string accion;
	public int id;
	// Use this for initialization
	void Start () {
		boton = GetComponent<Button> ();
		controladorPadre = GetComponentInParent<controladorDeDialogo> ();
		texto = GetComponentInChildren<textoIdiomaV2> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(string _idTexto){
		texto.setTextoID (_idTexto);
		texto.actualizarTexto ();
	}

	public void click(){
		controladorPadre.ejecutarAccion (accion);
		controladorPadre.nuevoNodo (nodo);
	}

	public void activar(){
		gameObject.SetActive (true);
	}

	public void desActivar(){
		gameObject.SetActive (false);
	}
}

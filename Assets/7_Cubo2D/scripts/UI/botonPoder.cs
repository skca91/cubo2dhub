using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class botonPoder : MonoBehaviour {

	Button boton;
	Image imagen;
	// Use this for initialization
	void Start () {
	 	boton =	GetComponent<Button> ();
		imagen = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (juego.poder < variablesGlobales.activarPoder) {
			imagen.enabled = false;
			boton.interactable = false;
		} else {
			
			imagen.enabled = true;
			boton.interactable = true;
		}*/
	}
}

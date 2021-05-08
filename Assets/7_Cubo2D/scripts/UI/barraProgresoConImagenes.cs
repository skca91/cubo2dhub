using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraProgresoConImagenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/** 
	 * muestra las imagen con los id menores o iguales al _progresoActal
	*/
	public void actualizarBarra(int _progresoActual){
		foreach(controladorImagenConId c in GetComponentsInChildren<controladorImagenConId>()){
			if(c.id <= _progresoActual){
				c.mostrarImagen();
			}else{
				c.ocultarImagen();
			}
		}
	}
}

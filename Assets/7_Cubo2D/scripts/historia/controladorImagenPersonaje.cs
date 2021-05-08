using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controladorImagenPersonaje : MonoBehaviour {

	public personajeIcono[] personajes;
	Image imagen;
	// Use this for initialization
	void Start () {
		imagen = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cargarPersonaje(string nombre, string expresion){
		foreach(personajeIcono p in personajes){
			if(p.nombre.Equals(nombre)){
				imagen.sprite = p.getIcono (expresion);
			}
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cambiarIdioma : MonoBehaviour {

	public Sprite[] imagenesIdioma;
	Image imagen;
	void Start () {
		/*imagen = gameObject.GetComponentInChildren<Image>();
		imagen.sprite = imagenesIdioma[PerfilJugador.miIdioma];*/
	}
	
	void Update () {
		//imagen.sprite = imagenesIdioma[PerfilJugador.miIdioma];
	}

	public void proximoIdioma(){
		/*PerfilJugador.miIdioma++;
		if (PerfilJugador.miIdioma >= variablesGlobales.limiteIdiomas) {
			PerfilJugador.miIdioma = 0;
		}
		idioma tmp = new idioma ();
		tmp.cambiarIdioma ();
		imagen.sprite = imagenesIdioma[PerfilJugador.miIdioma];*/

	}
}

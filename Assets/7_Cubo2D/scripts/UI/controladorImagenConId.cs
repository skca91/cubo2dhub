using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorImagenConId : MonoBehaviour {


	public Image imagen;
	public int id;
	public Color v_colorVisible = new Color(1,1,1,1.0f);
	public Color v_colorOculta = new Color(1,1,1,0.0f);

	void Awake(){
		imagen = GetComponent<Image> ();

	}
	// Use this for initialization
	void Start () {
		//imagen.fillAmount = 0;
	}

	// Update is called once per frame
	void Update () {
	}

	public void mostrarImagen(){
		if (imagen != null) {
			//	imagen.enabled = true;
			imagen.color = v_colorVisible;
		}
	}

	public void ocultarImagen(){
		if (imagen != null) {
			//imagen.enabled = false;
			imagen.color =v_colorOculta;
		}
	}

	/**Actualiza el rellenado de la imagen con id*/
	public void actualizarPorsionVisibleDeLaImagen(float proporcion){
		imagen.fillAmount = proporcion;
		//Debug.Log ("filllll l l ll " + proporcion);
	}
}

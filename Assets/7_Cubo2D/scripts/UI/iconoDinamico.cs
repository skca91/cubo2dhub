using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class iconoDinamico : MonoBehaviour {

	public Sprite[] iconos;
	Image imagen;
	// Use this for initialization
	void Start () {
		
		imagen = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cambiarIcono(string icono){
		if (icono.Equals ("monedas")) {
			imagen.sprite = iconos[0];
		}else if (icono.Equals ("malos")) {
			imagen.sprite = iconos[1];
		}else if (icono.Equals ("jefes")) {
			imagen.sprite = iconos[2];
		}
	}
}

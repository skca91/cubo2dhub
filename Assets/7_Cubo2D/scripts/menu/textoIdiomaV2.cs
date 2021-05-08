using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textoIdiomaV2 : MonoBehaviour {

	public enum modoMuestraTexto{sinCambios,todoMayusculas,primeraLetraMayuscula}

	Text texto;
	Text[] textoInChildren;
	public string tipoTexto;
	public bool actualizarEnTiempoReal = false;
	public bool noTraducir = false;
	public bool modificarTextoInChildren = false;
	public modoMuestraTexto modoTexto = modoMuestraTexto.sinCambios;

	void Start () {

		texto = GetComponent<Text> ();
		textoInChildren = GetComponentsInChildren<Text> ();
		actualizarTexto ();
	}

	// Update is called once per frame
	void Update () {
		if (actualizarEnTiempoReal) {
			actualizarTexto ();
		}
	}

	public void actualizarTexto(){

		if (texto == null)
			return;
		if (noTraducir) {
			texto.text = tipoTexto;
		} else {

			if (modoTexto.Equals (modoMuestraTexto.sinCambios)) {
				texto.text = idiomaV2.textoTraducido (tipoTexto);
			}else if(modoTexto.Equals (modoMuestraTexto.todoMayusculas)){
				texto.text = idiomaV2.textoTraducido (tipoTexto).ToUpper();
			}else if(modoTexto.Equals (modoMuestraTexto.primeraLetraMayuscula)){
				texto.text = idiomaV2.textoTraducido (tipoTexto);
			}else{
				texto.text = idiomaV2.textoTraducido (tipoTexto);
			}



		}


		if (modificarTextoInChildren) {
			foreach(Text t in textoInChildren){
				t.text = texto.text;
			}
		}
	}

	public void setTextoID(string _idTexto){
		tipoTexto = _idTexto;
		actualizarTexto ();
	}


	public void setTextoLiteral(string mensaje){
		
		if (texto == null) {
			texto = GetComponent<Text> ();
			if (modificarTextoInChildren) {
				textoInChildren = GetComponentsInChildren<Text> ();
			}
		}

		tipoTexto = mensaje;

		actualizarTexto ();
	}
}

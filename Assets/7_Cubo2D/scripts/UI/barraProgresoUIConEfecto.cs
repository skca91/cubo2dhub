using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraProgresoUIConEfecto : MonoBehaviour {

	public Image v_ImageBarraProgresoPrincipal;
	public Image v_ImageBarraProgresoSegundaria;
	public float duracion = 1.0f;
	/**Invierte la barra si llega a 1*/
	//public bool reinicioAutomatico = false;

	float progresoActual;
	float progresoAnterior;
	float progresoInterpolado = 0;
	bool efectoActivo = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void actualizarBarraProgreso(float _progresoAnterior, float _progresoActual){

		//Debug.Log ("p anterior" + _progresoAnterior + " p actual " + _progresoActual);

		progresoInterpolado = (_progresoActual - _progresoAnterior)/(30);

		///Debug.Log ("interpolo " + progresoInterpolado);
		progresoActual = _progresoActual; 
		v_ImageBarraProgresoPrincipal.fillAmount = _progresoAnterior;
		if (v_ImageBarraProgresoSegundaria != null) {
			v_ImageBarraProgresoSegundaria.fillAmount = _progresoActual;
		}


		InvokeRepeating ("actualizar",0,(duracion/30));
	}


	public void actualizar(){
//		Debug.Log ("actualizo " + v_ImageBarraProgresoPrincipal.fillAmount);
		v_ImageBarraProgresoPrincipal.fillAmount += progresoInterpolado;
		if (v_ImageBarraProgresoPrincipal.fillAmount >= progresoActual) {
			CancelInvoke ("actualizar");
			/*if (reinicioAutomatico && progresoActual == 1) {
				v_ImageBarraProgresoPrincipal.fillAmount = 0;
			}*/
		}
	}

}


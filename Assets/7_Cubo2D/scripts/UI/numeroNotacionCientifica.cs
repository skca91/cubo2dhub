using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numeroNotacionCientifica : MonoBehaviour {

	public Text v_base;
	public Text v_notacion;
	public Text v_exponente;
	UnidadesIDLE v_unidad;
	bool actualizaEnTiempoReal = false;
	// Use this for initialization

	void Awake(){
		v_unidad = new UnidadesIDLE ();

		v_base.text = "";
		v_exponente.text = "xxx";
		v_notacion.text = "xxx";

	}

	void Start () {
		//Debug.Log ("strat");

	}
	
	// Update is called once per frame
	void Update () {

		/*if(actualizaEnTiempoReal){
			if(v_base.text.Equals("") && v_unidad.v_base > 0){
				setUnidad( v_unidad);
			}
		}*/

	}

	public void setUnidadString(string _u){

//		Debug.Log (" setUnidadString: " + _u);

		setUnidad (UnidadesIDLE.fromStringText(_u));
	}


	public void setUnidad(UnidadesIDLE _unidad){

		/*if (v_unidad == null) {
			v_unidad = new unidadesIDLE ();
		}*/

		v_unidad.setUnidad (_unidad);

	//	Debug.Log ("setUnidad: base:  " + _unidad.v_base + " exp: " +_unidad.v_exponente);

		v_base.text = v_unidad.v_base.ToString ("##,###") ;
		v_exponente.text = "";
		v_notacion.text = "";


		if(v_unidad.v_exponente == 1){
			v_notacion.text = "K";
		}else if(v_unidad.v_exponente == 2){
			v_notacion.text = "M";
		}else if(v_unidad.v_exponente == 3){
			v_notacion.text = "B";
		}else if(v_unidad.v_exponente == 4){
			v_notacion.text = "T";
		}else if(v_unidad.v_exponente == 5){
			v_notacion.text = "q";
		}else if(v_unidad.v_exponente == 6){
			v_notacion.text = "Q";
		}else if(v_unidad.v_exponente > 6){
			v_notacion.text = "x10";
			v_exponente.text = v_unidad.v_exponente.ToString();
		}
	
	}


}

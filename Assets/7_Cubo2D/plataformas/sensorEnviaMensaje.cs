using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorEnviaMensaje : MonoBehaviour {

	public enum modo
	{
		envia_a_hermano,
		envia_a_padre,
		envia_a_hijo
	}

	public modo v_modo = modo.envia_a_hermano;
	public string mensajeEnter= "nada";
	public string mensajeExit = "nada";
	/**Si la espera es mayor a 0 espera*/
	public float v_espera = 0;
	public float v_frecuenciaMinima = 0;
	float v_inicioEsperaEnter = 0;
	bool v_estaEsperandoEnter = false;
	float v_inicioEsperaExit = 0;
	bool v_estaEsperandoExit = false;
	float v_inicioFrecuenciaMinima = 0;
	public string filtroPorTag = "Player";
	//public tag

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(activarConEsperaEnter ()){

			if (mensajeEnter.Length < 1)
				return;

			if(v_modo == modo.envia_a_hermano){
				SendMessage (mensajeEnter);
			}else if(v_modo == modo.envia_a_padre){
				SendMessageUpwards (mensajeEnter);
			}else if(v_modo == modo.envia_a_hijo){
				BroadcastMessage (mensajeEnter);
			}

		}

		if(activarConEsperaExit ()){

			if (mensajeExit.Length < 1)
				return;

			if(v_modo == modo.envia_a_hermano){
				SendMessage (mensajeExit);
			}else if(v_modo == modo.envia_a_padre){
				SendMessageUpwards (mensajeExit);
			}else if(v_modo == modo.envia_a_hijo){
				BroadcastMessage (mensajeExit);
			}
		}
	}

	public void nada(){
	
	}

	public bool activarConEsperaEnter(){
		if (v_estaEsperandoEnter && Time.time > v_inicioEsperaEnter + v_espera) {
			v_estaEsperandoEnter = false;
			return true;
		}
		return false;
	}

	/*public void reset(){
		v_estaEsperandoEnter = false;
		v_estaEsperandoExit = false;
	}*/

	public bool activarConEsperaExit(){
		if (v_estaEsperandoExit && Time.time > v_inicioEsperaExit + v_espera) {
			v_estaEsperandoExit = false;
			return true;
		}
		return false;
	}

	public void OnTriggerEnter(Collider other){

//		Debug.Log ("Enter: " +other.name);

		if(other.gameObject.tag.Equals(filtroPorTag)){
			Debug.Log ("OnTriggerEnter: " +other.name);
			if (!v_estaEsperandoEnter && Time.time > v_inicioFrecuenciaMinima + v_frecuenciaMinima) {
				v_inicioEsperaEnter = Time.time;
				v_inicioFrecuenciaMinima = Time.time;
				v_estaEsperandoEnter = true;
			}
		}
	}

	public void OnTriggerExit(Collider other){
		if(other.gameObject.tag.Equals(filtroPorTag)){
			if (!v_estaEsperandoExit && Time.time > v_inicioFrecuenciaMinima + v_frecuenciaMinima) {
				v_inicioEsperaExit = Time.time;
				v_inicioFrecuenciaMinima = Time.time;
				v_estaEsperandoExit = true;
			}
		}
	}


}

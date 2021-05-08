using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeConNiveles : MonoBehaviour {

	/**Experiencia necesaria para alcanzar el nivel 1*/
	public float v_experienciaBase;

	public float v_progresoNivelActual=0;
	public int v_nivelActual=0;
	public int v_nivelMaximo=10;

	/**Experiencia actual del personaje*/
	public float v_experienciaActual=0;
	public float v_experienciaRequeridaParaNivelActual = 0;
	public float v_experienciaRequeridaParaProximoNivel = 0;
	bool modoSilencioso = false;

	// Use this for initialization
	void Start () {
		v_nivelActual = 0;
		actualizarDatos ();
		calcularPregreso ();
		//calcularExperienciaEnBaseANivel (10);
		//verificarExperienciaMaxima ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

/*	public void setNivel(){
	
	}*/

	/*public int calcularNivelEnBaseAExperiencia(float _experienciaActual){

		
	}*/

	public void calcularPregreso(){
		if(v_experienciaActual > 0){
			v_progresoNivelActual = (v_experienciaActual - v_experienciaRequeridaParaNivelActual) / (v_experienciaRequeridaParaProximoNivel - v_experienciaRequeridaParaNivelActual);
		}
		if (v_progresoNivelActual < 0) {
			v_progresoNivelActual = 0;
		}else if (v_progresoNivelActual >= 1) {
			v_nivelActual++;
			actualizarDatos ();
			if (!modoSilencioso) {
				if (v_nivelActual < v_nivelMaximo) {
				SendMessage ("nuevoNivel");
				Invoke ("calcularPregreso", 1);
				}
			} else {
				Invoke ("calcularPregreso", 0);
			}
		}
		SendMessage ("actualizarInterfaz");
	}

	public void reiniciar(){
		v_nivelActual = 0;
		v_experienciaActual = 0;
		actualizarDatos ();
		calcularPregreso ();
	}

	public void actualizarInterfaz(){
		
	}

	public void nuevoNivel(){
	
	}

	public void actualizarDatos(){

		v_experienciaRequeridaParaNivelActual = (float)(int)calcularExperienciaEnBaseANivel (v_nivelActual);

		v_experienciaRequeridaParaProximoNivel =(float)(int)calcularExperienciaEnBaseANivel (v_nivelActual+1);

		//Debug.Log (" v_expMiNivel " + v_experienciaRequeridaParaNivelActual);
		//Debug.Log (" v_expProxNivel " + v_experienciaRequeridaParaProximoNivel);
	}



	public void agregarExperiencia(float _experiencia){
	
		Debug.Log ("agrego " + _experiencia + " a " + v_experienciaActual + " y es menor que " + calcularExperienciaEnBaseANivel (v_nivelMaximo));

		if (v_experienciaActual + _experiencia < calcularExperienciaEnBaseANivel (v_nivelMaximo)) {
			v_experienciaActual += _experiencia;
			modoSilencioso = false;

		} else {
			tieneExperienciaMaxima ();
		}

		
		//Debug.Log (" experiencia Actual " + v_experienciaRequeridaParaProximoNivel);
		calcularPregreso ();
	}
	
	public void tieneExperienciaMaxima(){
		
		v_experienciaActual = calcularExperienciaEnBaseANivel (v_nivelMaximo);
		SendMessage ("experienciaMaxima");


		
	}

	public void setExperiencia(float _experiencia){
		v_experienciaActual += _experiencia;
		modoSilencioso = true;
		//Debug.Log (" experiencia Actual " + v_experienciaRequeridaParaProximoNivel);
		calcularPregreso ();
	}

	public float calcularExperienciaEnBaseANivel(int _nivel){

		float _experienciaAcumulada = 0;
		float _nuevaExperiencia = 0;
//		Debug.Log ("calculo exp para " +_nivel);

		for(int i = 0; i < _nivel; i++){
			_nuevaExperiencia=v_experienciaBase + Mathf.Pow((v_experienciaBase ) ,( i*0.3765f));
//			Debug.Log ("nivel : "+i+" -actual: " +_experienciaAcumulada+" -nueva: "+_nuevaExperiencia +" -total: "+(_experienciaAcumulada +_nuevaExperiencia));
			_experienciaAcumulada += _nuevaExperiencia;
		}

		return _experienciaAcumulada;
	}
}

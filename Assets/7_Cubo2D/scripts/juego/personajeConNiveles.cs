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
        calcularExperienciaEnBaseANivel (100);
        //verificarExperienciaMaxima ();
        SendMessage("actualizarInterfaz");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

/*	public void setNivel(){
	
	}*/

	/*public int calcularNivelEnBaseAExperiencia(float _experienciaActual){

		
	}*/

	public void calcularPregreso(){

       // if (v_experienciaActual > 0){
			v_progresoNivelActual = (v_experienciaActual - v_experienciaRequeridaParaNivelActual) / (v_experienciaRequeridaParaProximoNivel - v_experienciaRequeridaParaNivelActual);
		//}
//        Debug.Log(this.gameObject.name+": calcularPregreso :\n exp actual: \t" + v_experienciaActual + "\nnivel actual:\t" + v_nivelActual + "progreso actual:\t"+ v_progresoNivelActual);
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
                calcularPregreso();
			}
		}
		SendMessage ("actualizarInterfaz");
	}

	public void reiniciar(){
        Debug.Log("personajesConNiveles reiniciar");

		v_nivelActual = 0;
		v_experienciaActual = 0;
		modoSilencioso = false;
		actualizarDatos ();
        SendMessage("actualizarInterfaz");
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
	
		//Debug.Log ("agrego " + _experiencia + " a " + v_experienciaActual + " y es menor que " + calcularExperienciaEnBaseANivel (v_nivelMaximo));

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
		Debug.Log (this.gameObject.name +": experiencia Actual " + v_experienciaActual);
		calcularPregreso ();
        Debug.Log(this.gameObject.name + ": nivel actual" + v_nivelActual);
    }

	public float calcularExperienciaEnBaseANivel(int _nivel){

        return calcularExperienciaEnBaseANivel(_nivel,v_experienciaBase);

    }

    public float calcularExperienciaEnBaseANivel(int _nivel,float _experienciaBase)
    {

        float _experienciaAcumulada = 0;
        float _nuevaExperiencia = 0;
        //Debug.Log ("calculo exp para " +_nivel);
        string todo = "";

        for (int i = 0; i < _nivel; i++)
        {
            //_nuevaExperiencia=v_experienciaBase + Mathf.Pow((v_experienciaBase ) ,( i*0.3735));
            //_nuevaExperiencia=v_experienciaBase + Mathf.Pow((v_experienciaBase ) ,( i*0.1765f));
            _nuevaExperiencia = _experienciaBase + Mathf.Pow((_experienciaBase + _experienciaBase * i * 0.19f), 0.23f + i * 0.137f);
            todo += "nivel : " + i + "\t -actual: " + _experienciaAcumulada + "\t\t\t -nueva: " + _nuevaExperiencia + "\t\t\t -total: " + (_experienciaAcumulada + _nuevaExperiencia) + "\n";

            // Debug.Log ("nivel : "+i+" -actual: " +_experienciaAcumulada+" -nueva: "+_nuevaExperiencia +" -total: "+(_experienciaAcumulada +_nuevaExperiencia));
            _experienciaAcumulada += _nuevaExperiencia;
        }
//        Debug.Log("Experiencia para nivel " + _nivel + "\n base: " + _experienciaBase + " \n" + todo);
        return _experienciaAcumulada;
    }
}

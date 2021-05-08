using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poderIDLE {

	public enum mecanica{
		toqueBase,
		toqueDanioExtra,/* mas de 1 uso*/
		toqueDanioExtraConSeleccion, /*mas de 1 uso*/
		multiplicadorDanioDuracion,
		pasivoContinuoBase,
		multiplicadorPasivoContinuoBase,
		/*pasivoDuracion,*/
		multiplicadorOroDuracion

	}

	public string v_id;
	public int v_nivel;
	public bool v_bloqueado;
	/**puntos de daño o curacion o multiplicador de dinero base*/
	public UnidadesIDLE v_efectoBase; 
	/**Poder en el nivel actual, depende de las reglas de juego. Nota: Esta variable no es necesaria pero la uso para ahorrarme calculos*/
	public UnidadesIDLE v_efectoActual; 
	/**duracion o numero de usos*/
	public float v_duracion;
	public float v_inicioDuracion;
	public mecanica v_mecanica;
	public List<poderIDLE> v_actualizaciones;

	public poderIDLE (string _id, UnidadesIDLE _efecto,mecanica _mecanica){
		v_id = _id;
		v_efectoBase = _efecto;
		v_mecanica = _mecanica;
	}

	/**Recomendado para actualizaciones*/
	public poderIDLE (string _id, UnidadesIDLE _efecto,mecanica _mecanica,int _nivel): this (_id, _efecto, _mecanica){
		v_nivel = _nivel;
	}

	/**Duracion se puede usar para definir el numero de pasos antes de activar en mecanica toqueDanioExtra*/
	public poderIDLE (string _id, UnidadesIDLE _efecto,mecanica _mecanica,float _duracion): this (_id, _efecto, _mecanica){
		v_duracion = _duracion;
	}

	public poderIDLE (string _id, UnidadesIDLE _efecto,mecanica _mecanica,List<poderIDLE> _actualizaciones): this (_id, _efecto, _mecanica){
		//v_duracion = _duracion;
		v_actualizaciones = _actualizaciones;

		foreach(var a in v_actualizaciones){
			Debug.Log (v_id+" nombre actualizacion "+a.v_id);
		}
	}

	public poderIDLE (string _id, UnidadesIDLE _efecto,mecanica _mecanica,float _duracion,List<poderIDLE> _actualizaciones): this (_id, _efecto, _mecanica, _duracion){
		//v_duracion = _duracion;
		v_actualizaciones = _actualizaciones;

		foreach(var a in v_actualizaciones){
			Debug.Log (v_id+" nombre actualizacion "+a.v_id);
		}
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

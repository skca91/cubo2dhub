using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilidadesOfflineV5 : MonoBehaviour {

	public string idVersionJuego;
	public bool cargarOnStart = false;
	public Dictionary<string,int> v_habilidadesDesbloqueadas;
	public Dictionary<string,int> v_habilidadesEquipadas;

	void Awake(){
		v_habilidadesDesbloqueadas = new Dictionary<string,int> ();
		v_habilidadesEquipadas = new Dictionary<string,int> ();
	}
	// Use this for initialization
	void Start () {
		if(cargarOnStart){
			cargar ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void desbloquearHabilidad(string _id){
		if (!v_habilidadesDesbloqueadas.ContainsKey (_id)) {
			v_habilidadesDesbloqueadas.Add (_id, 1);
			guardar ();
		}
	}
	/**-1 no encontrada*/
	public int getNivelHabilidad(string _id){
		if (v_habilidadesDesbloqueadas.ContainsKey (_id)) {
			return v_habilidadesDesbloqueadas[_id];
		}
		return 0;
	}

	/**-1 no encontrada*/
	public int getNivelHabilidadEquipada(string _id){
		if (v_habilidadesEquipadas.ContainsKey (_id)) {
			return v_habilidadesEquipadas[_id];
		}
		return 0;
	}

	public bool estaDesbloquearHabilidad(string _id){
		return v_habilidadesDesbloqueadas.ContainsKey (_id);
	}

	/**El incremento de nivel puede ser mayor a 1
		- retorna true si la mejora ya existe*/
	public bool mejorarHabilidad(string _id, int _incrementoDeNivel){
		if (v_habilidadesDesbloqueadas.ContainsKey (_id)) {
			v_habilidadesDesbloqueadas [_id] += _incrementoDeNivel;
			guardar ();
			return true;
		} else {
			v_habilidadesDesbloqueadas.Add (_id,1);
			guardar ();
			return false;
		}
	}

	public void remplazarHabilidad(string _habilidadActual, string _habilidadNueva){

	}

	public void equiparHabilidad( string _habilidadActual){

	}

	public void desequiparHabilidad(string _habilidadActual){

	}

	public void guardar(){
		if (idVersionJuego.Equals ("")) {
			Debug.Log ("se recomienda usar un identificador de habilidades para el juego");
		} else {
			PlayerPrefs.SetString ("habilidadesOfflineV5" + idVersionJuego, toStringDatos ());
		}
		Debug.Log ("guardo habilidadesOfflineV5"+idVersionJuego);
	}

	public void cargar(){
		if (idVersionJuego.Equals ("")) {
			Debug.Log ("se recomienda usar un identificador de habilidades para el juego");
		} else {
			fromStringDatos( PlayerPrefs.GetString ("habilidadesOfflineV5" + idVersionJuego, toStringDatos ()));
		}
		if(cargarOnStart){
			SendMessage ("actualizarHabilidades");
			SendMessage ("actualizarEfectos");
		}
	//	Debug.Log ("cargo habilidadesOfflineV5"+idVersionJuego);
	}

	public string toStringDatos(){
		string datos = "";
		foreach(KeyValuePair<string,int> item in v_habilidadesDesbloqueadas){
			datos += item.Key+"-"+item.Value+"|";
		}
		datos +=";";
		foreach(KeyValuePair<string,int> item in v_habilidadesEquipadas){
			datos += item.Key+"-"+item.Value+"|";
		}
		return datos;
	}

	public void fromStringDatos(string _datos){
		string[] _datosLista;
		string[] _datosSplit1 = _datos.Split (';');/*
		int.TryParse (_datosSplit1 [0], out v_dinero);
		int.TryParse (_datosSplit1 [1], out v_dineroEspecial);*/

		_datosLista = _datosSplit1 [0].Split ('|');
		v_habilidadesDesbloqueadas.Clear ();

		foreach(string item in _datosLista){
			if (item.Length > 0) {
				string[] datosItem = item.Split ('-');
				v_habilidadesDesbloqueadas.Add (datosItem[0],int.Parse(datosItem[1]));
			}

		}

		_datosLista = _datosSplit1 [1].Split ('|');
		v_habilidadesEquipadas.Clear ();

		foreach(string item in _datosLista){
			if (item.Length > 0) {
				string[] datosItem = item.Split ('-');
				v_habilidadesEquipadas.Add (datosItem[0],int.Parse(datosItem[1]));
			}

		}

	}
}

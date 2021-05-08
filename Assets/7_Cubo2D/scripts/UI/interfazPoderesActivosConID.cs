using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(puntoDeMontaje))]

public class interfazPoderesActivosConID : MonoBehaviour {

	Dictionary<string,int> v_listaIconoPoder;
	Dictionary<string,GameObject> v_listaPoderesActivos;
	//puntoDeMontaje v_puntoDeMontaje;
	public  contenedorDeObjetos v_contenedorIconos;

	void Awake(){
		v_listaIconoPoder = new Dictionary<string, int> ();
		v_listaPoderesActivos = new Dictionary<string, GameObject> ();

	}
	// Use this for initialization
	void Start () {
		v_listaIconoPoder.Add ("defaul", 100);
		v_listaIconoPoder.Add ("toque Extra", 101);
		v_listaIconoPoder.Add ("mxs", 102);
		//v_puntoDeMontaje = GetComponent<puntoDeMontaje> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void agregarPoderActivo (string _id){
		GameObject nuevoPoder;
		if (v_listaIconoPoder.ContainsKey (_id)) {
			nuevoPoder = Instantiate(v_contenedorIconos.buscarPorID(v_listaIconoPoder[_id]),transform);
		} else {
		//	v_puntoDeMontaje.montar (v_listaIconoPoder["defaul"]);	
			nuevoPoder = Instantiate(v_contenedorIconos.buscarPorID(v_listaIconoPoder["defaul"]),transform);
		}


		v_listaPoderesActivos.Add (_id,nuevoPoder);
		//actualizarProgresoPoderActivo (_id, 0);
		//v_puntoDeMontaje.objetoEquipable.SendMessage ("");
	}

	public void actualizarProgresoPoderActivo(string _id, float _progreso){
		
		foreach(var pa in v_listaPoderesActivos){
			if (pa.Key.Equals (_id)) {
				pa.Value.BroadcastMessage ("actualizarPorsionVisibleDeLaImagen",_progreso);
			}
		}
	}

	public void eliminarPoderActivo(string _id){
		
		Debug.Log("trato de eliminar " + _id);
		Destroy (v_listaPoderesActivos [_id].gameObject);
		v_listaPoderesActivos.Remove (_id);
	}
}

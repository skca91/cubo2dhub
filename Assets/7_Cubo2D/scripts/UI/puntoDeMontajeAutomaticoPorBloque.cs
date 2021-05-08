using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**monta automaticamente los id en su lista*/
public class puntoDeMontajeAutomaticoPorBloque : MonoBehaviour {

	public int[] v_listaID;
	public bool v_usarRango = false;
	public int v_min,v_max;
	public bool v_sobrescribirContenedorDeDatos = true;
	public contenedorDeObjetos v_contenedorDatos;
	// Use this for initialization
	void Start () {
		if(v_usarRango){
			v_listaID = new int[v_max - v_min];
			for (int i = 0; i < v_listaID.Length; i++) {
				v_listaID [i] = v_min + i;
			}
		}

		foreach(puntoDeMontaje pm in GetComponentsInChildren<puntoDeMontaje>()){
			pm.datos = v_contenedorDatos;
		}

		foreach(int i in v_listaID){
			BroadcastMessage ("montar", i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

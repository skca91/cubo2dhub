using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjetoCapturableEfectoMasSonido : MonoBehaviour {

	efectoParticulas particulas;
	efectoSonidoV1 sonidos;

	// Use this for initialization
	void Start () {
		buscarEfectos ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buscarEfectos(){
		if (particulas == null) {
			particulas = GetComponentInChildren<efectoParticulas> ();
		}
		if(sonidos==null){
			sonidos = GetComponentInChildren<efectoSonidoV1> ();
		}

	}

	public void activarEfectos(){
		buscarEfectos ();
		particulas.activarEfecto ();
		sonidos.activarEfecto ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contenedorObjetosConTag : MonoBehaviour {

	public enum tagCubo2D
	{
		monedas,
		checkpoint,
		enemigosTipo1,
		enemigosTipo2,
		cofre,
		desafiosMapa
	}

	public tagCubo2D tag;

	public GameObject contenedor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

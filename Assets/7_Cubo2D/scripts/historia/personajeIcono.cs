using UnityEngine;
using System.Collections;

public class personajeIcono : MonoBehaviour {

	public string nombre;
	public Sprite expresionNormal;
	public Sprite expresionFeliz;
	public Sprite expresionTriste;
	public Sprite expresionMolesto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Sprite getIcono(string expresion){

		switch(expresion){
		case "normal":
			return expresionNormal;

		case "feliz":
			return expresionFeliz;

		case "triste":
			return expresionTriste;

		case "molesto":
			return expresionMolesto;
		default:
			return expresionNormal;

		}

	}
}

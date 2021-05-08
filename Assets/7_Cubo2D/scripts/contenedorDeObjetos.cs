using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contenedorDeObjetos : MonoBehaviour {

	public itemSpawn[] objetos;
	// Use this for initialization
	void Start () {
	//	objetos = GetComponentsInChildren<itemSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject buscarPorID(int id){

		//Debug.Log ("busco por id");


		//objetos = GetComponentsInChildren<itemSpawn> ();

		foreach (itemSpawn obj in objetos) {
			if (obj.v_id == id) {
				return obj.gameObject;
			}
		}
		return null;
	}

	public Sprite buscarIconoPorID(string id){
		int _id = int.Parse(id);
		return buscarIconoPorID (_id);

	}

	public Sprite buscarIconoPorID(int id){

		//Debug.Log ("busco por id");


		//objetos = GetComponentsInChildren<itemSpawn> ();

		foreach (itemSpawn obj in objetos) {
			if (obj.v_id == id) {
				return obj.gameObject.GetComponent<iconoSpamCubo2D>().v_iconoSprite;
			}
		}
		return null;
	}
}

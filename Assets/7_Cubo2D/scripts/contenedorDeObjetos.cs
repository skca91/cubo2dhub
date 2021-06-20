using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Obsolete("Remplazado por ContenedorObjetosV2, se actualizo para funcionar como adapter, se eliminara en el futuro")]
public class contenedorDeObjetos : ContenedorObjetosV2, ContenedorObjetosI {

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

    public override GameObject BuscarID(string _Id)
    {
		int Id = 0;
		if (int.TryParse(_Id, out Id))
		{
			return buscarPorID(Id);
		}
		else {
			return null;
		}

    }
}

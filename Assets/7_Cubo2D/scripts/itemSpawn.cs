using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Obsolete("Remplazado por ItemSpawnV2")]
public class itemSpawn : ItemSpawnV2, ItemSpawnI {


	public int v_id=-1;
	public Material[] v_material;
	// Use this for initialization
	void Start () {
		if (v_id > 0) {
			Id = v_id.ToString();
		}
	}
	// Update is called once per frame
	void Update () {

	}

	public int materialLength(){
		return v_material.Length;
	}

	public Material materialId(int _id){
		if (_id < v_material.Length) {
			return v_material[_id];
		}
		Debug.LogError ("Material Fuera de rango");
		return null;
	}
}

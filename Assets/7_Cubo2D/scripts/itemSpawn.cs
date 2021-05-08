using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour {

	public int v_id=-1;
	public Material[] v_material;
	// Use this for initialization
	void Start () {

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

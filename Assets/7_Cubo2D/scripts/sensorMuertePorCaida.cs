using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorMuertePorCaida : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Other){

		Other.SendMessage ("tomarDanio",9999999);
	}
}

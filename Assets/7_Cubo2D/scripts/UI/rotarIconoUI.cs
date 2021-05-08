using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarIconoUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InvokeRepeating ("rotar",0,0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rotar(){
		transform.Rotate (new Vector3(0,0,5));
	}
}

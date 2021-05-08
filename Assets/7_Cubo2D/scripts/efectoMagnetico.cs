using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efectoMagnetico : MonoBehaviour {

	public Transform objetoBase;
	public bool bloquearMovimientoEnY = true;
	bool activo;
	GameObject duenno;
	Vector3 escala;
//	objetosCapturables capturable;
	// Use this for initialization
	void Start () {
		activo = false;
		duenno = GameObject.FindWithTag ("Player");
		escala = transform.localScale;
		//capturable = GetComponent<objetosCapturables> ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate(){
		if (activo) {

			if(bloquearMovimientoEnY)
				objetoBase.LookAt (new Vector3(duenno.transform.position.x,duenno.transform.position.y+0.5f,duenno.transform.position.z));

			objetoBase.Translate (0.0f,0.0f,0.1f);
			//objetoBase.Translate(duenno.transform.position.x,duenno.transform.position.y,duenno.transform.position.z);
			escala = escala * 0.94f;
			objetoBase.localScale = escala;
		}
	}



	void OnTriggerEnter(Collider other){
		if (other.tag.Equals ("Player")) {
			activo = true;
			if(duenno == null){
				duenno = other.gameObject;
			}
			//Debug.Log ("magnetico !!");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntoDeMontaje : MonoBehaviour {

	/**El lugar donde se va a montar*/
	public int id =1;
	/***/
	public bool usarPuntoDeMontajeExterno = false;
	/**Se usa para la busqueda automatica en Awake*/
	public string nombrePuntoMontajeExterno;
	/***/
	public Transform puntoDeMontajeExterno;
	/***/
	public bool usarObjetosValidosManual = false;
	/**los objetos que se pueden montar*/
	public int[] objetosValidos;
	/**Referencia al objeto equipado*/
	public GameObject objetoEquipable;
	/**Todos los objetos equipables*/
	public contenedorDeObjetos datos;
	/**Conserva el objeto montado actual. Advertencia puede crear duplicados*/
	public bool v_DestruirAlMontar = true;
	// Use this for initialization
	void Awake(){
		/*if (datos == null) {
			datos = GameObject.Find ("data").GetComponent<contenedorDeObjetos>();
		}*/

		if(!usarObjetosValidosManual){
			objetosValidos = listaObjetosValidos (id);
		}

		if(usarPuntoDeMontajeExterno && puntoDeMontajeExterno == null){
			GameObject puntoExterno = GameObject.Find (nombrePuntoMontajeExterno);
			if (puntoExterno != null) {
				puntoDeMontajeExterno = puntoExterno.transform;
			}
		}
	}

	void Start () {
		//desmontar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setNuevoPuntoDeMontaje(Transform _t){
		
		puntoDeMontajeExterno = _t;

		//Debug.Log ("nuevo pm: " +puntoDeMontajeExterno.position.x);
	}


	public void montar(int idObjMontable){

		//Debug.Log ("montar " + idObjMontable +" en "+id + " validos " +objetosValidos.Length);

		//objetosValidos = listaObjetosValidos (id);

		bool valido = false;

		foreach(int v in objetosValidos){
			if(v == idObjMontable){
				valido = true;
				break;
			}
		}

		if(!valido)
			return;

		//Debug.Log ("montar " + idObjMontable +" en "+id + " validos si " +objetosValidos.Length);

		GameObject objMontable = datos.buscarPorID (idObjMontable);

		//Debug.Log ("montar " + idObjMontable +" en "+id + " validos " +objetosValidos.Length);

		if(objetoEquipable != null && v_DestruirAlMontar)
			Destroy (objetoEquipable);
		
		objetoEquipable = (GameObject)Instantiate (objMontable);

		if (usarPuntoDeMontajeExterno) {
			if (puntoDeMontajeExterno != null) {
				objetoEquipable.transform.position = puntoDeMontajeExterno.position;
				objetoEquipable.transform.rotation = puntoDeMontajeExterno.rotation;
				//accesorioObj.transform.localScale = transform.localScale;
				objetoEquipable.transform.parent = puntoDeMontajeExterno;
				SendMessage ("montajeCompletado");
			} else {
				objetoEquipable.transform.position = new Vector3 (0,-100,0);
				objetoEquipable.transform.rotation = Quaternion.identity;
				//accesorioObj.transform.localScale = transform.localScale;
				//objetoEquipable.transform.parent = puntoDeMontajeExterno;
				//Debug.Log ("No tengo punto de montaje cree en un 0,-100,0");
				SendMessage ("montajeCompletado");
			}
		} else {
			objetoEquipable.transform.position = transform.position;
			objetoEquipable.transform.rotation = transform.rotation;
			//accesorioObj.transform.localScale = transform.localScale;
			objetoEquipable.transform.parent = transform;
			SendMessage ("montajeCompletado");
		}


//		Debug.Log ("montado " + idObjMontable);
	}


	public void montajeCompletado(){
	
	}

	public void desmontar(){
		if(objetoEquipable != null )
			Destroy (objetoEquipable);
	}

	/**Esto deberia buscarse en un xml*/
	public static int[] listaObjetosValidos(int id){
		int[] validos;
		switch (id) {
		case 0:
			validos = new int[] {1001,1002,1003,1004,1005,1006,1007};
			return validos;
		case 8:
			validos = new int[] {1601,1602,1603,1604};
			return validos;

		case 9:
			validos = new int[] {1501,1502,1503,1504};
			return validos;
		default:
			validos = new int[] {-1};
			return validos;
		}
	}
}

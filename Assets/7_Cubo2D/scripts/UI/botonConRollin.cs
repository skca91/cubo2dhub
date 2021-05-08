using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonConRollin : MonoBehaviour {

	[SerializeField]
	Button boton;
	[SerializeField]
	Text texto;
	//[SerializeField]
	SelectRotatorio rollin;
	[SerializeField]
	GameObject rollinObj;
	[SerializeField]
	Text etiquetaText;

	public string textoEtiqueta;
	private bool activo;
	/** tiempo = 0 es apagado*/
	public float tiempoOcultarAutomatico= 0;
	float ultimaIteracion;

	public bool configurarRollinManual;
	public string[] listaOpcionesRoller;

 	// Use this for initialization
	void Start () {
		activo = false;
		//texto.text = rollin.Value;
		//rollinObj.gameObject.SetActive (false);
		rollinObj.gameObject.SendMessage("hideMenu");
		rollin = rollinObj.GetComponentInChildren<SelectRotatorio> ();
		rollin.seleccion = SelectRotatorio.modoSeleccion.lista;
		actualizarRollin ();

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void actualizarRollin(){
		rollin.duenio = this.gameObject;
		rollin.opciones = listaOpcionesRoller;
		//rollin.
		rollin.reiniciar ();
		rollin.actualizarLista ();
		//rollin.Value = this.Value;
	}

	public void onClickBotonRollin(){
		activo= !activo;
		actualizarRollin ();
		if (activo) {
			//rollinObj.gameObject.SetActive (true);
			rollinObj.gameObject.SendMessage("showMenu");
			if (tiempoOcultarAutomatico > 0) {
				ultimaIteracion = Time.time;
				InvokeRepeating ("ocultarAutomarico",0,0.5f);
			}
			if (etiquetaText != null) {
				etiquetaText.text = textoEtiqueta;
			}
			rollin.duenio = this.gameObject;
		} else {
			//rollinObj.gameObject.SetActive (false);
			rollinObj.gameObject.SendMessage("hideMenu");
		}
	}

	public string Value{
		get { 
			if(rollin!=null)
				return rollin.Value;
			Debug.Log ("get rolling es null "+gameObject.name);
			return "";
		}

		set{ 
			if (rollin != null) {
				rollin.Value = value;
				SendMessageUpwards ("nuevoValorRotador");
				Debug.Log ("boton rollin " +this.name);
			}
			Debug.Log ("set rolling es null "+gameObject.name);
		}
	}
		
	public void reiniciar(){
		if (rollin != null) {
			rollin.reiniciar();
		}
		texto.text = Value;
	}

	public void nuevoValorRotador(){
		texto.text = Value;
		ultimaIteracion = Time.time;
		//SendMessageUpwards ("nuevoValorRotador");
	}

	public void ocultarAutomarico(){
		if (Time.time > ultimaIteracion + tiempoOcultarAutomatico) {
			CancelInvoke ("ocultarAutomarico");
			//rollinObj.gameObject.SetActive (false);
			rollinObj.gameObject.SendMessage("hideMenu");
			activo = false;
		}
	}

	public void ocultarManual(){
		rollinObj.gameObject.SendMessage("hideMenu");
		activo = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/**Daniel Pernia*/

[RequireComponent(typeof(AudioSource))]

public class SelectRotatorio : MonoBehaviour {

	public GameObject duenio;
	public RectTransform _transform;
	Vector3 posInicial;
	Vector3 posicionInicialTransform;
	public string valorVacio;
	public string[] opciones;
	int index = -2;
	public int limiteInferior;
	public int limiteSuperior;
	public bool rotarEnCirculo;
	public float velocidadDesplazamiento = Screen.height/12;
	public string formatoTexto="";
	public float unidad;
	public bool movimientoActivo = false;
	AudioSource sonido;
	GridLayoutGroup layout;

	//int cont = 0;

	public enum modoSeleccion{
		lista,
		contadorInfinito,
		contadorEnRango,
		dias,
		meses,
		anios
	}

	enum Direccion{
		nada,
		sube,
		baja
	}

	public modoSeleccion seleccion = modoSeleccion.lista;

	Direccion direccion = Direccion.nada;
	// Use this for initialization
	void Start () {
		//layout = _transform.GetComponent<GridLayoutGroup> ();

		posicionInicialTransform = _transform.position;
		//unidad = GetComponent<RectTransform>().sizeDelta.y*0.35f;
		//_transform.sizeDelta = new Vector2 (GetComponent<RectTransform>().sizeDelta.x,unidad*5);
		//layout.cellSize = new Vector2 (GetComponent<RectTransform>().sizeDelta.x,unidad);
		//velocidadDesplazamiento = 0.008f;
		InvokeRepeating ("mover", 0, 0.05f);

		Debug.Log ("posicion inicial rollin ---------------" + posicionInicialTransform);
		reiniciar ();
		sonido = GetComponent<AudioSource> ();
		actualizarLista ();


	}

	public void reiniciar(){
		

		switch (seleccion) {
		case modoSeleccion.lista:
			limiteInferior = -1;
			limiteSuperior = opciones.Length - 3;
			index = 0;
			break;
		case modoSeleccion.contadorInfinito:
			limiteInferior = int.MinValue;
			limiteSuperior = int.MaxValue;
			index = 0;
			break;
		case modoSeleccion.contadorEnRango:
			limiteInferior = 0;
			limiteSuperior = 31;
			index = System.DateTime.Today.Day;
			index = 0;
			break;
		case modoSeleccion.dias:
			index = System.DateTime.Today.Day;
			break;
		case modoSeleccion.meses:
			limiteInferior = 0;
			limiteSuperior = 12;
			index = System.DateTime.Today.Month;
			break;
		case modoSeleccion.anios:
			limiteInferior = 1900;
			limiteSuperior = 2100;
			index = System.DateTime.Today.Year;
			break;
		}


	}

	public string Value{

		get{ 
			string _value = "";

			switch (seleccion) {
			case modoSeleccion.lista:
				if(index>0)
				_value = opcion (index-1);
				return _value;
			case modoSeleccion.contadorInfinito:
				return (index).ToString(formatoTexto);
			case modoSeleccion.contadorEnRango:
				return (index).ToString(formatoTexto);
			case modoSeleccion.dias:
				return (index).ToString(formatoTexto);
			case modoSeleccion.meses:
				return (index).ToString(formatoTexto);
			case modoSeleccion.anios:
				return (index).ToString(formatoTexto);
			}
			return _value;
		}

		set{ 
			index = 0;
			switch (seleccion) {
			case modoSeleccion.lista:
				Debug.Log ("set lista no esta definido");
				break;
			case modoSeleccion.contadorInfinito:
				//return (index).ToString();
				int.TryParse (value,out index);
				actualizarLista ();
				break;
			case modoSeleccion.contadorEnRango:
				Debug.Log ("falta validar rango");
				int.TryParse (value,out index);
				actualizarLista ();
				break;
			case modoSeleccion.dias:
				int.TryParse (value,out index);
				actualizarLista ();
				break;
			case modoSeleccion.meses:
				int.TryParse (value,out index);
				actualizarLista ();
				break;
			case modoSeleccion.anios:
				int.TryParse (value,out index);
				actualizarLista ();
				break;
			}
		}

	}

	public void EndDrag(PointerEventData eventData)
	{
		//Debug.Log("OnEndDrag"+et.pointerev.delta);
	}

	public void BeginDrag(PointerEventData eventData)
	{
		//Debug.Log("OnBeginDrag"+eventData.delta);
	}

	public void Drag(PointerEventData eventData)
	{
		//Debug.Log("Drag"+eventData.delta);
	}

	/**Se usa en el padre*/
	public void nuevoValorRotador(){
		
	}

	public void mover(){

		//return;

		float y = (_transform.position.y-posicionInicialTransform.y);
		float limiteMovimiento =(_transform.sizeDelta.y)/5.5f;
		//Debug.Log (" limite moviemento" +limiteMovimiento + " y " +y);
		if (direccion.Equals (Direccion.nada)) {
			
		} else if (direccion.Equals (Direccion.sube)) {
			if (y < limiteMovimiento) {
				_transform.position = new Vector3 (_transform.position.x,_transform.position.y+velocidadDesplazamiento,_transform.position.z);
			} else {
				if (movimientoActivo) {
					index++;
					actualizarLista ();
					sonido.Play ();
				}
			}
		}else if (direccion.Equals (Direccion.baja) ) {
			if (y > -limiteMovimiento) {
				_transform.position = new Vector3 (_transform.position.x, _transform.position.y - velocidadDesplazamiento, _transform.position.z);
			} else {
				if (movimientoActivo) {
					index--;
					actualizarLista ();
					sonido.Play ();
				}
			}
		}
	}

	public void actualizarLista(){

		movimientoActivo = false;
		//_transform.localPosition = posicionInicialTransform;
		//_transform.position = posicionInicialTransform;
		_transform.localPosition = new Vector3(0,0,0);
//		Debug.Log ("actualizarLista --- ------- ---    "+posicionInicialTransform);
		direccion = Direccion.nada;

		int i = index-2;
		//Debug.Log ("index " + i + " value " +Value);
		//limpiar
		foreach(Text t in _transform.GetComponentsInChildren<Text>()){
			t.text= opcion (i);
			i++;
		}


		if (duenio != null) {
			Debug.Log ("con duenio ");
			duenio.SendMessageUpwards ("nuevoValorRotador");
		} else {
			SendMessageUpwards ("nuevoValorRotador");
		}
	}

	public string opcion(int i){

		//Debug.Log ("i "+i);

		string label = "";

		switch (seleccion) {
		case modoSeleccion.lista:
			if (i < opciones.Length && i > -1) {
				label = opciones [i];
			} else {
				label = valorVacio;
			}
			return label;
		case modoSeleccion.contadorInfinito:
			return i.ToString ();
		case modoSeleccion.contadorEnRango:
			if (i <= limiteSuperior && i >= limiteInferior) {
				label = i.ToString("D2");
			} else {
				label = valorVacio;
			}
			return label;
		case modoSeleccion.dias:
			if (i < limiteSuperior && i > limiteInferior) {
				label = i.ToString ();
			} else if (rotarEnCirculo) {
				/*if (i > limiteSuperior) {
					label = (limiteInferior-1).ToString();
				} else {
					label = limiteSuperior.ToString();
				}*/
			} else {
				label = valorVacio;
			}
			return label;
		case modoSeleccion.meses:
			if (i < limiteSuperior && i > limiteInferior) {
				label = i.ToString ();
			} else if (rotarEnCirculo) {
				/*if (i > limiteSuperior) {
					label = (limiteInferior-1).ToString();
				} else {
					label = limiteSuperior.ToString();
				}*/
			} else {
				label = valorVacio;
			}
			return label;
		case modoSeleccion.anios:
			if (i < limiteSuperior && i > limiteInferior) {
				label = i.ToString ();
			} else if (rotarEnCirculo) {
				/*if (i > limiteSuperior) {
					label = (limiteInferior-1).ToString();
				} else {
					label = limiteSuperior.ToString();
				}*/
			} else {
				label = valorVacio;
			}
			return label;
		}

		return label;
	}


	public void EndDragV2()
	{

		Debug.Log ("End "+Input.mousePosition.ToString ());
		//Debug.Log("OnEndDrag"+et.pointerev.delta);
		direccion = Direccion.nada;
	}

	public void BeginDragV2()
	{
//		Debug.Log("OnBeginDrag"+eventData.delta);
		Debug.Log ("Begin "+Input.mousePosition.ToString ());

		posInicial = Input.mousePosition;
	}

	public void DragV2()
	{
		movimientoActivo = true;
		//Debug.Log("Drag"+eventData.delta);


		if (Input.mousePosition.y > posInicial.y) {
			if (index < limiteSuperior) {
				direccion = Direccion.sube;
			} else if(rotarEnCirculo){
				index = limiteInferior;
			}
		} else if(Input.mousePosition.y < posInicial.y){
			if (index > limiteInferior) {
				direccion = Direccion.baja;
			} else if(rotarEnCirculo){
				index = limiteSuperior;
			}
		}

		Debug.Log ("Drag  "+Input.mousePosition.ToString () +"direccion "+direccion.ToString()+" "+_transform.position.y);
	}

}

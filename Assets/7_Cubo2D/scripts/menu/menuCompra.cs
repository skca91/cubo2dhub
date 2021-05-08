using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(menu))]

public class menuCompra : MonoBehaviour {


	public Sprite v_icono;
	public textoIdiomaV2 v_titulo;
	public textoIdiomaV2 v_descripcion;
	public Text v_costoMoneda1;
	public Text v_costoMoneda2;
	public Text v_totalMoneda1Texto;
	public Text v_totalMoneda2Texto;
	public Transform v_contenedorDeRequerimientos;
	public GameObject v_requerimientoPrefab;
	public List<GameObject> v_listaRequetimientos;


	//estadisticas

	//public GameObject restricciones;
	Item v_itemActual;
	menu v_menu;
	Button v_botonComprar;

	int v_totalMoneda1 = 0;
	int v_totalMoneda2 = 0;

	void Awake(){
		v_menu = GetComponent<menu> ();

		if(v_icono==null){
			//GameObject go = GameObject.Find ("menuCompra_titulo_texto");
			//v_titulo = go.GetComponent<Sprite> ();
		}

		if(v_titulo==null){
			GameObject go = GameObject.Find ("menuCompra_titulo_texto");
			v_titulo = go.GetComponent<textoIdiomaV2> ();
		}

		if(v_descripcion==null){
			GameObject go = GameObject.Find ("menuCompra_descripcion_texto");
			v_descripcion = go.GetComponent<textoIdiomaV2> ();
		}

		if(v_costoMoneda1==null){
			GameObject go = GameObject.Find ("menuCompra_costo_moneda1_texto");
			v_costoMoneda1 = go.GetComponent<Text> ();
		}

		if(v_costoMoneda2==null){
			GameObject go = GameObject.Find ("menuCompra_costo_moneda2_texto");
			v_costoMoneda2 = go.GetComponent<Text> ();
		}

		if(v_totalMoneda1Texto==null){
			GameObject go = GameObject.Find ("menuCompra_total_moneda1_texto");
			v_totalMoneda1Texto = go.GetComponent<Text> ();
		}

		if(v_totalMoneda2Texto==null){
			GameObject go = GameObject.Find ("menuCompra_total_moneda2_texto");
			v_totalMoneda2Texto = go.GetComponent<Text> ();
		}

		if(v_botonComprar==null){
			GameObject go = GameObject.Find ("menuCompra_buttonComprar");
			v_botonComprar = go.GetComponent<Button> ();
		}
	}
	// Use this for initialization
	void Start () {
		if(v_botonComprar!=null){
			v_botonComprar.onClick.AddListener (OnClickBottonComprar);
		}
	}

	public void setItem(Item _item){
		v_itemActual = _item;
		// idioma necesito 
		v_titulo.setTextoID(_item.v_nombreID);
		v_descripcion.setTextoID(_item.v_descripcionID);
		v_costoMoneda1.text =""+ _item.v_costoMoneda1;
		//aqui se puede cambiar el color del texto
		v_costoMoneda2.text =""+ _item.v_costoMoneda2;
		//Debug.Log("cont requerimirntos " +_item.v_requerimientos.Count);
		foreach(GameObject go in v_listaRequetimientos){
			Destroy (go.gameObject);
		}

		foreach(KeyValuePair<string,int> r in _item.v_requerimientos){
			GameObject _requerimientoActualObj = (GameObject) Instantiate (v_requerimientoPrefab,new Vector3(0,0,0),Quaternion.identity);
			_requerimientoActualObj.transform.parent = v_contenedorDeRequerimientos;
			_requerimientoActualObj.transform.localScale = new Vector3 (1,1,1);
			Text texto = _requerimientoActualObj.GetComponentInChildren<Text>();
			texto.text = "" + r.Key + " " + r.Value;
			v_listaRequetimientos.Add (_requerimientoActualObj);
		}



		//aqui se puede cambiar el color del texto
	}

	public void OnClickBottonComprar(){
		SendMessageUpwards ("comprar",v_itemActual.v_id);
	}

	public void setTotalMonedas(int _totalMoneda1, int _totalMoneda2){
		v_totalMoneda1 = _totalMoneda1;
		v_totalMoneda2 = _totalMoneda2;
		v_totalMoneda1Texto.text = "" + v_totalMoneda1;
		v_totalMoneda2Texto.text = "" + v_totalMoneda2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showMenu(){
		v_menu.showMenu ();
	}

	public void hideMenu(){
		v_menu.hideMenu ();
	}

	/*public void show(){
		//isOpen = true;
		//actualizarTexto ();
	}

	public void hide(){
		//isOpen = false;
	}*/
}

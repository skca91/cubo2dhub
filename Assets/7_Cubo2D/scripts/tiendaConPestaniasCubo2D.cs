using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tiendaConPestaniasCubo2D : MonoBehaviour {


	public GameObject v_botonDeCompra;
	public GameObject menuConfirmarCompra;
	public GameObject v_contenedorBotonesDeCompra;
	public int dinero;
	public int dineroEspecial;
    public Text TituloPestaniaText;

	/*requieren un controlador especifico que las inicialice*/
	private Dictionary<string, contenedorDeObjetos> v_todosLosObjetos;
	private GameObject v_duenio;
	private Dictionary<string,string[]> v_listaDePestaniasConIds;
	private Dictionary<string,string[]> v_listaDeDatos;
	private string pestaniaActual = "";

	List<GameObject> botonesActivos;

	// Use this for initialization
	void Start () {
		botonesActivos = new List<GameObject> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void actualizarTodosLosDatos(Dictionary<string,string[]> _datos){
		v_listaDeDatos = _datos;
	}
		

	public void mostrarPestania(string _id){
        if(TituloPestaniaText!=null)
            TituloPestaniaText.text = idiomaV2.textoTraducido(_id);


        SendMessage ("actualizarDatosPestanias");

		if (v_listaDePestaniasConIds [_id] != null) {
			pestaniaActual = _id;
			foreach(GameObject go in botonesActivos){
				Destroy (go.gameObject);
			}
			botonesActivos.Clear ();
			foreach( string idBoton in v_listaDePestaniasConIds[_id]){
				//Destroy (go.gameObject);
				GameObject botonActual = (GameObject)Instantiate(v_botonDeCompra,v_contenedorBotonesDeCompra.transform);
				botonComprarYMejorarItemV1 bciv1 = botonActual.GetComponent<botonComprarYMejorarItemV1> ();

					
				bciv1.configurarBoton (
					idBoton,
					/*Nombre*/ v_listaDeDatos[idBoton.ToString()][0],
					v_todosLosObjetos [_id].buscarIconoPorID (idBoton),
					/*costo*/v_listaDeDatos[idBoton.ToString()][1],
					/*nivel*/v_listaDeDatos[idBoton.ToString()][3],
					/*efecto*/v_listaDeDatos[idBoton.ToString()][2],
					/*upgrades*/v_listaDeDatos[idBoton.ToString()][5],
					/*desbloqueado*/bool.Parse(v_listaDeDatos[idBoton.ToString()][6]),
					/*disponible para comprar*/bool.Parse(v_listaDeDatos[idBoton.ToString()][7]));
				
				botonesActivos.Add (botonActual);
			}
			//foreach
		}
	}

	public void botonComprarMejorar(string _id){
//		Debug.Log ("trato de comprar mejorar " + _id +"dinero "+ dinero + "costo " +v_listaDeDatos [_id] [1] );
		
		int costo = (int) float.Parse (v_listaDeDatos [_id] [1]);
		if (dinero >= costo) {
			v_duenio.SendMessage ("agregarDinero", -costo);//se envia directo al inventario
		//	Debug.Log ("agrego dinero "+ (-costo));
			v_duenio.SendMessage ("comprarMejorar", _id);
			SendMessage ("actualizarDatosPestanias");
			mostrarPestania (pestaniaActual);
		} else {
			//sonido
		}
	}

	public void actualizarDatosPestanias(){
	
	}

	public int calcularCostoEnBaseANivel(){
		return 0;
	}

	public Dictionary<string, contenedorDeObjetos>  todosLosObjetos{
		get { return v_todosLosObjetos;}
		set { v_todosLosObjetos = value;}
	}

	public GameObject duenio{
		get { return v_duenio;}
		set { v_duenio = value;}
	}

	public Dictionary<string,string[]> listaDePestaniasConIds{
		get { return v_listaDePestaniasConIds;}
		set { v_listaDePestaniasConIds = value;}
	}

}

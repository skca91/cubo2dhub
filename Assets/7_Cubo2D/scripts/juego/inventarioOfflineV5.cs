using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventarioOfflineV5 : MonoBehaviour {

	public string idVersionJuego;
	public bool cargaOnStart = false;
	int v_dinero = 0;
	int v_dineroEspecial = 0;
	public Dictionary<string,int> v_itemInventario;
	public Dictionary<string,string> v_itemEquipados;

	void Awake(){
		v_itemInventario = new Dictionary<string,int> ();
		v_itemEquipados = new Dictionary<string,string> ();
	}
	// Use this for initialization
	void Start () {
		if (cargaOnStart) {
			cargar ();
		}

		//Debug.Log ("cargo.....");
	}

	// Update is called once per frame
	void Update () {

	}
	/**Se puede agregar numeros negativos*/
	public void agregarDinero(int _dineroExtra){
		v_dinero += _dineroExtra;
//		Debug.Log ("guardo " + toStringDatos());
		guardar ();
		SendMessage ("actualizarInterfaz");
	}

	public int getDinero(){
		return v_dinero;
	}

    /**Se puede agregar numeros negativos*/
    public void agregarDineroEspecial(int _dineroExtra)
    {
        v_dineroEspecial += _dineroExtra;
        //      Debug.Log ("guardo " + toStringDatos());
        guardar();
        SendMessage("actualizarInterfaz");
    }

    public int getDineroEspecial()
    {
        return v_dineroEspecial;
    }

    public void agregarItem(string _id,int _cantidadUnidades){
		if (!v_itemInventario.ContainsKey (_id)) {
			v_itemInventario.Add (_id, _cantidadUnidades);
		}
        guardar();
    }

	public void agregarItem(string _id){
		if (!v_itemInventario.ContainsKey (_id)) {
			v_itemInventario.Add (_id, 1);
		} else {
			v_itemInventario [_id]++;
		}
        guardar();
    }
	/**-1 no encontrada*/
	public int getCantidadItem(string _id)
    {
        Debug.Log("getCantidadItem " + _id);
        if (v_itemInventario.ContainsKey (_id)) {
            Debug.Log("Cantida: "+ v_itemInventario[_id]);
            return v_itemInventario[_id];
		}
		return -1;
	}

	/**"lugarSinRegistro" no encontrada*/
	public string getItemEquipado(string idLugar){
		if (v_itemEquipados.ContainsKey (idLugar)) {
			return v_itemEquipados[idLugar];
		}
		return "lugarSinRegistro";
	}

	/**"noEquipado" no encontrada*/
	public string equiparItem(string idLugar,string idItem){
		if (v_itemEquipados.ContainsKey (idLugar)) {
			if (v_itemEquipados [idLugar].Equals ("vacio")) {
				v_itemEquipados [idLugar] = idItem;
				guardar ();
				return "equipadoEnVacio";
			} else {
				v_itemEquipados [idLugar] = idItem;
				guardar ();
				return "remplazado";
			}
		} else {
			v_itemEquipados.Add (idLugar, idItem);
			guardar ();
			return "agregadoEnNuevoLugar";
		}
	}

	public bool siTieneElItem(string _id){
		return v_itemInventario.ContainsKey (_id);
	}

	/*Se ejecuta en los hermanos*/
	public void actualizarInterfaz(){
	
	}

	public void inventarioOfflineV5Cargado(){
	
	}

	public void guardar(){
		if (idVersionJuego.Equals ("")) {
			Debug.Log ("se recomienda usar un identificador de inventario para el juego");
		} else {
			PlayerPrefs.SetString ("inventarioOfflineV5" + idVersionJuego, toStringDatos ());
		}
//		Debug.Log (" inventario guarda " + toStringDatos ());
	}

	public void cargar(){
		if (idVersionJuego.Equals ("")) {
			Debug.Log ("se recomienda usar un identificador de inventario para el juego");
		} else {
			fromStringDatos( PlayerPrefs.GetString ("inventarioOfflineV5" + idVersionJuego, toStringDatos ()));
		}

//		Debug.Log (" inventario carga " + toStringDatos ());
		SendMessage ("inventarioOfflineV5Cargado");
	}

	public string toStringDatos(){
		string datos = "";
		datos += v_dinero+";";
		datos += v_dineroEspecial+";";
		foreach(KeyValuePair<string,int> item in v_itemInventario){
			datos += item.Key+"-"+item.Value+"|";
		}
		datos +=";";
		foreach(KeyValuePair<string,string> item in v_itemEquipados){
			datos += item.Key+"-"+item.Value+"|";
		}
		return datos;
	}

	public void fromStringDatos(string _datos){
		string[] _datosLista;
		string[] _datosSplit1 = _datos.Split (';');
		int.TryParse (_datosSplit1 [0], out v_dinero);
		int.TryParse (_datosSplit1 [1], out v_dineroEspecial);

		_datosLista = _datosSplit1 [2].Split ('|');
		v_itemInventario.Clear ();

		foreach(string item in _datosLista){
			if (item.Length > 0) {
				string[] datosItem = item.Split ('-');
				v_itemInventario.Add (datosItem[0],int.Parse(datosItem[1]));
			}

		}

		_datosLista = _datosSplit1 [3].Split ('|');
		v_itemEquipados.Clear ();

		foreach(string item in _datosLista){
			if (item.Length > 0) {
				string[] datosItem = item.Split ('-');
				v_itemEquipados.Add (datosItem[0],datosItem[1]);
			}

		}

	}
}

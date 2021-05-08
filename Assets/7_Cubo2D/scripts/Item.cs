using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	public int v_id;
	//public int v_bloqueado; (es un estado) los item en el inventario estan desbloqueados
	public string v_nombreID;
	public string v_descripcionID;
	public int v_costoMoneda1;
	public int v_costoMoneda2;
	public Dictionary<string, int> v_requerimientos;




	public Item(int _id, string _nombre, string _descripcion, int _costoMoneda1, int _costoMoneda2, Dictionary<string, int> _requeriminetos){
		v_id = _id;
		v_nombreID = _nombre;
		v_descripcionID = _descripcion;
		v_costoMoneda1 = _costoMoneda1;
		v_costoMoneda2 = _costoMoneda2;
		v_requerimientos = _requeriminetos;
	}

	public Item(int _id, string _nombre, string _descripcion, int _costoMoneda1, int _costoMoneda2){
		v_id = _id;
		v_nombreID = _nombre;
		v_descripcionID = _descripcion;
		v_costoMoneda1 = _costoMoneda1;
		v_costoMoneda2 = _costoMoneda2;
		v_requerimientos = new Dictionary<string, int>(0);
	}

	public Item(int _id, string _nombre, string _descripcion, int _costoMoneda1){
		v_id = _id;
		v_nombreID = _nombre;
		v_descripcionID = _descripcion;
		v_costoMoneda1 = _costoMoneda1;
		v_costoMoneda2 = 0;
		v_requerimientos = new Dictionary<string, int>(0);
	}

	public Item(int _id, string _nombre, int _costoMoneda1){
		v_id = _id;
		v_nombreID = _nombre;
		v_descripcionID = "";
		v_costoMoneda1 = _costoMoneda1;
		v_costoMoneda2 = 0;
		v_requerimientos = new Dictionary<string, int>(0);
	}
}

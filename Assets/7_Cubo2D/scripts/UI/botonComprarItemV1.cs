using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ahora es V2 usa identificadores string
/// </summary>
public class botonComprarItemV1 : MonoBehaviour {

	public string v_id;
	public bool permiteConfiguracionExterna = true;

	public Button v_botonClick;
	public Button v_botonComprar;
	public Image v_iconoItem;
	public Image v_iconoBloqueo;
	public Image v_iconoEquipado;

	private Item v_item;
	private bool v_bloqueado = false;
    private tieneDuenio duenio;
	//public equipamentoV1 v_equipamento;
	//inventario v_inventario;

	void Awake(){

		if (v_botonClick == null) {
			v_botonClick = GetComponent<Button> ();
		}

		if (v_botonComprar == null) { // si no lo referencian busca si lo contiene en el gameobject
			v_botonComprar = GetComponentInChildren<Button> ();
			if (v_botonComprar == null) { //si no lo contiene lo busca en la scena con este nombre: "botonComprarItem"
				GameObject go = GameObject.Find("botonComprarItem");
				v_botonComprar = GetComponent<Button> ();
			}

		}

        duenio = GetComponent<tieneDuenio>();
	}

	public void OnClickBotonComprar(){
        if (v_botonComprar == null)
        {
            return;
        }
      // SendMessageUpwards ("mostrarMenuCompra",v_id);
	}

	public void OnClickBotonEquipamento(){

		//		Debug.Log ("botom equipo " + v_id);

		//v_equipamento.Equipar (v_id);
		if (v_bloqueado) {
			//v_equipamento.equiparVistaPrevia (v_id);
		} else {
            if (duenio != null && duenio.v_duenio != null)
            {
                duenio.v_duenio.SendMessage("equiparStore", v_id);
            }
            else
            {
                SendMessageUpwards("equiparStore", v_id);
            }
        }

       

	}

	public void setItem(string Id){
		//v_item = _item;
        v_id = Id;

	}

    public void DesbloquearId(string Id) {
        //Debug.Log(" id " + Id);

        if (Id.Equals(v_id))
        {
            desBloquear();
        }
        else
        {
            //bloquear();
        }
    }

    public void bloquear(){
		if (v_iconoBloqueo != null) {
			//	imagen.enabled = true;
			v_bloqueado = true;
			v_iconoBloqueo.color = new Color(v_iconoBloqueo.color.r,v_iconoBloqueo.color.g,v_iconoBloqueo.color.b,1.0f);
			/*if(v_botonComprar!=null)
                v_botonComprar.gameObject.SetActive (true);*/
		}
	}

	public void desBloquear(){
		if (v_iconoBloqueo != null) {
			//	imagen.enabled = true;
			v_bloqueado = false;
			v_iconoBloqueo.color = new Color(v_iconoBloqueo.color.r,v_iconoBloqueo.color.g,v_iconoBloqueo.color.b,0.0f);
            /*if (v_botonComprar != null)
                v_botonComprar.gameObject.SetActive (false);*/
		}
	}

    public void EquiparId(string Id)
    {
        if (Id.Equals(v_id)) {
            equipar();
        }
        else {
            desEquipar();
        }
    }

    public void equipar(){
		if (v_iconoEquipado != null) {
			//	imagen.enabled = true;
			v_iconoEquipado.color = new Color(v_iconoEquipado.color.r,v_iconoEquipado.color.g,v_iconoEquipado.color.b,1.0f);
		}
	}

	public void desEquipar(){
		if (v_iconoEquipado != null) {
			//	imagen.enabled = true;
			v_iconoEquipado.color = new Color(v_iconoEquipado.color.r,v_iconoEquipado.color.g,v_iconoEquipado.color.b,0.0f);
		}
	}

	public void setIcono(Sprite _icono){
		v_iconoItem.sprite = _icono;
	}

	// Use this for initialization
	void Start () {

		if(v_botonClick != null){
			v_botonClick.onClick.AddListener (OnClickBotonEquipamento);
		}

		if (v_botonComprar != null) {
			v_botonComprar.onClick.AddListener (OnClickBotonComprar);
		} else {

		}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (" v_mi_ item " + v_item.v_id);
	}
}

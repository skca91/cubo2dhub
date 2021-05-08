using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDeMontajeV2 : MonoBehaviour {

    public ContenedorObjetosV2 contenedor;
    public GameObject objeto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void montar(string id)
    {

        if (objeto != null) {
            Destroy(objeto.gameObject);
        }
        GameObject prefab = contenedor.BuscarID(id);
        if(prefab!=null)
            objeto = (GameObject)Instantiate(prefab,this.transform);

    }

    public void desmontar() {
        if (objeto != null)
        {
            Destroy(objeto.gameObject);
        }
    }
}

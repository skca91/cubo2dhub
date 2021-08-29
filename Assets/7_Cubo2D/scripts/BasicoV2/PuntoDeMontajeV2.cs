using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuntoDeMontajeV2 : MonoBehaviour , IPuntoDeMontaje
{

    public ContenedorObjetosV2 contenedor;
    public GameObject objeto;
    public ContenedorObjetosI contenedorObjetosCompatible;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void montar(string id)
    {
        contenedorObjetosCompatible = contenedor;
        if (objeto != null) {
            Destroy(objeto.gameObject);
        }
        GameObject prefab = contenedor?.BuscarID(id);
        if (prefab != null) {
            objeto = (GameObject)Instantiate(prefab, this.transform);
            objeto.transform.localScale = prefab.transform.localScale;
        }
            

    }

    public void desmontar() {
        if (objeto != null)
        {
            Destroy(objeto.gameObject);
        }
    }

    public void montar(int id) {
        montar(id.ToString());
    }
}

public interface IPuntoDeMontaje {

    void montar(string id);

    /// <summary>
    /// Se mantiene por retrocompatibilidad
    /// </summary>
    /// <param name="id"></param>
    /// 
    [Obsolete("Se recomienda usar montar(string)")]
    void montar(int id);

    void desmontar();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEfectoParticulasSonidoV2 : MonoBehaviour {
    
    public GameObject[] Efectos;
    /**Se envia un numero*/
    public bool Version1 = false;
    public string id;
	// Use this for initialization
	void Start () {
		
	}

    public void OnMouseDown()
    {
        if (Version1)
        {
            foreach (GameObject GO in Efectos) {
                GO.SendMessage("activarEfecto",int.Parse(id));
            }
        }
        else { 
            // no se ha implementado el id debe ser string
        }
    }
}

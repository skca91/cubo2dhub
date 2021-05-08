using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedorObjetosV2 : MonoBehaviour {

    public ItemSpawnV2[] Objetos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject BuscarID(string _Id) {
        Debug.Log("Busco: (" + _Id + ")" );

        foreach (ItemSpawnV2 GO in Objetos)
        {
            Debug.Log("Id: "+ GO.Id);
            if (GO.Id.Equals(_Id)) {
                return GO.gameObject;
            }
        }

        return null;
    }


}

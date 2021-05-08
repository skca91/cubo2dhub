using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(PostProcessingBehaviour))]

public class PostProcecingStackCamaraConfigCubo2D : MonoBehaviour {

    PostProcecingStackConfigCubo2D ContenedorPerfiles;
    PostProcessingBehaviour PPBehaviour;
    // Use this for initialization
    void Start() {
        GameObject GO = GameObject.Find("game");
        //  Debug.Log("Go " + GO.name);
        if (GO != null) {
            ContenedorPerfiles = GO.GetComponent<PostProcecingStackConfigCubo2D>();
            PPBehaviour = GetComponent<PostProcessingBehaviour>();
            if (PPBehaviour != null && ContenedorPerfiles.PerfilActual != null)
            {
                PPBehaviour.profile = ContenedorPerfiles.PerfilActual;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

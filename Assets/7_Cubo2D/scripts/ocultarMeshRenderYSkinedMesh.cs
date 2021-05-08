using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocultarMeshRenderYSkinedMesh : MonoBehaviour {

	public bool v_esVisible = true;
	MeshRenderer[] v_meshRenderes;
	SkinnedMeshRenderer[] v_skinnedMeshRenderes;
	// Use this for initialization
	void Start () {


		v_meshRenderes = GetComponentsInChildren<MeshRenderer> ();
		v_skinnedMeshRenderes = GetComponentsInChildren<SkinnedMeshRenderer> ();

		if (v_esVisible) {
			mostrar ();
		} else {
			ocultar ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ocultar(){


		foreach(MeshRenderer m in v_meshRenderes ){
			m.gameObject.SetActive (false);
		}

		foreach(SkinnedMeshRenderer m in v_skinnedMeshRenderes ){
			m.enabled = false;
		}
		v_esVisible = false;
	}

	public void mostrar(){


		v_meshRenderes = GetComponentsInChildren<MeshRenderer> ();
		v_skinnedMeshRenderes = GetComponentsInChildren<SkinnedMeshRenderer> ();

		foreach(MeshRenderer m in v_meshRenderes ){
			m.enabled = true;
		}

		foreach(SkinnedMeshRenderer m in v_skinnedMeshRenderes ){
			m.enabled = true;
		}
		v_esVisible = true;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonBasico : MonoBehaviour {

	//SceneManager manejadorScenas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cargarScena(string scena){
//		Application.LoadLevel (scena);
		SceneManager.LoadScene(scena);
	}

	public void cerrarJuego(){
	/*	PerfilJugador p = new PerfilJugador ();
		p.guardarPerfil ();
		Application.Quit ();*/
	}
}

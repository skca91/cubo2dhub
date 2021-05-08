using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class botonVideoRecomensa : MonoBehaviour {

	Button boton;
	// Use this for initialization
	void Start () {
		boton = GetComponent<Button> ();
		boton.onClick.AddListener(ShowAd);
	}
	
	// Update is called once per frame
	void Update () {
//		boton.interactable = (publicidad.tieneVideo());
	}

	void ShowAd () {
//		publicidad.showVideo ();
	}
}

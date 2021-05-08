using UnityEngine;
using System.Collections;

public class calificanos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void abrirCalificameTienda(){

		#if UNITY_EDITOR
		//
		#elif UNITY_ANDROID
			Application.OpenURL ("https://play.google.com/store/apps/details?id=com.cubo2d.casco");
		#elif UNITY_IPHONE
		Application.OpenURL ("https://itunes.apple.com/us/app/box-warrior/id1090696334");
		#else
		//
		#endif


	}
}

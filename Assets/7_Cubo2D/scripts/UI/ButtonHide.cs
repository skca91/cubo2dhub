using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHide : MonoBehaviour {

	public bool hideWebgl = false;
	public bool hideAndroid = false;
	public bool hideIos = false;

	Button button;
	Image image;
	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		image = GetComponent<Image> ();

		#if UNITY_WEBGL
		if (hideWebgl) {
				button.interactable = false;
				image.color = new Color (1,1,1,0);		
			}
		#elif UNITY_ANDROID
		if (hideAndroid) {
				button.interactable = false;
				image.color = new Color (1,1,1,0);		
			}
		#elif UNITY_IPHONE
		if (hideIos) {
				button.interactable = false;
				image.color = new Color (1,1,1,0);		
			}
		#else
		#endif

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

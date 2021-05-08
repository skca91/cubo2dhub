using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(simpleClick2D))]

public class cambiarImagenEnClick : MonoBehaviour {

	public Sprite[] sprite;

	SpriteRenderer spriteRender;
	int index;
	// Use this for initialization
	void Start () {
		spriteRender = GetComponent<SpriteRenderer> ();
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		index++;
		if (index == sprite.Length) {
			index = 0;
		}
		spriteRender.sprite = sprite[index];
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class animatorInicioRandom : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.Play("default",0,Random.Range(0,1.0f));
		//Animator.Play(state, layer, normalizedTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**CAmbia la velocidad general del animator, no se recomienda para animator complejos*/
public class velocidadAnimatorPersonalizadaCubo2D : MonoBehaviour {

	public float v_velocidadAnimator = 1.0f;

	private Animator v_animator;
	// Use this for initialization
	void Start () {

		v_animator = GetComponent<Animator> ();
		if(v_animator == null){
			v_animator = GetComponentInChildren<Animator> ();
		}
			
	}
	
	// Update is called once per frame
	void Update () {

		if(v_velocidadAnimator != v_animator.speed){
			v_animator.speed = v_velocidadAnimator;
		}
		
	}

	public void setNuevaVelocidadAnimator(float _nuevaVelocidad){
		v_velocidadAnimator = _nuevaVelocidad;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(simpleClick2D))]

public class botonNivelTorneoSprite : MonoBehaviour {

	public string v_id;
	public bool v_bloqueado;
	public SpriteRenderer v_SpriteRendererCompletado;
	public SpriteRenderer v_SpriteRendererBloqueado;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void desBloquearConEfectoConDemora(float _demora){
		Invoke ("desBloquearConEfecto",_demora);
	}

	public void desBloquearConEfecto(){
		v_SpriteRendererCompletado.color = new Color (1,1,1,1);
		v_SpriteRendererBloqueado.color = new Color (1,1,1,0);
		BroadcastMessage ("activarEfecto", 25);
	}


	public void bloquear(){
		v_SpriteRendererCompletado.color = new Color (1,1,1,0);
		v_SpriteRendererBloqueado.color = new Color (1,1,1,1);
	}

	public void desBloqueado(){
		v_SpriteRendererCompletado.color = new Color (1,1,1,0);
		v_SpriteRendererBloqueado.color = new Color (1,1,1,0);

	}

	public void desBloqueadoSinEfecto(){
		v_SpriteRendererCompletado.color = new Color (1,1,1,1);
		v_SpriteRendererBloqueado.color = new Color (1,1,1,0);

	}

	public void OnMouseDown(){
		if (v_bloqueado) {
			//aqui puede ir un sonido
		}else {
			//aqui puede ir un sonido
		}
	}

}

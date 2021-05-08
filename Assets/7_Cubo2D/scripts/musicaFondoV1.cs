using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(efectoSonidoV1))]

public class musicaFondoV1 : MonoBehaviour {

	public bool repoducirAlInicio = true;
	efectoSonidoV1 v_efectoAudio;
	contenedorDeAudio v_audio;
	// Use this for initialization
	void Start () {
		
		v_efectoAudio = GetComponentInChildren<efectoSonidoV1> ();
		//v_efectoAudio.v_ID = 7;
		setMusica(0);
		v_efectoAudio.activarEfecto ();
	}


	public void setMusica(int _id){
		v_audio = v_efectoAudio.getContendedorDeAudio ();
		if (_id < v_audio.clipMusicaFondo.Length) {
			v_efectoAudio.setAudioClip (v_audio.clipMusicaFondo [_id],v_audio.audioGroupMusicaFondo);
		} else {
			v_efectoAudio.setAudioClip (v_audio.clipMusicaFondo [0],v_audio.audioGroupMusicaFondo);
		}
		v_efectoAudio.activarEfecto ();

	}
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class efectoSonidoV1 : MonoBehaviour {


	public bool buscaSonidoAutomatico = false;
	public bool buscaAudioMixerAutomatico = true;
	public bool sePuedeIntrrumpir = true;
	public bool loop = false;

	public int v_ID;

	AudioMixerGroup v_audioMixerGroup;
	AudioClip v_audioClip;
	AudioSource v_audioSource;
	contenedorDeAudio v_audio;

	void Awake(){

		v_audio = (GameObject.Find ("datosAudio")).GetComponentInChildren<contenedorDeAudio>();

		if(buscaSonidoAutomatico){
		//	contenedorDeAudio _audio = (GameObject.Find ("datosAudio")).GetComponentInChildren<contenedorDeAudio>();
			if (v_audio == null) {
				Debug.Log ("no encuentro aduio");
			} else {
				v_audioClip = v_audio.clipBoton [0];
				if(buscaAudioMixerAutomatico){
					v_audioMixerGroup = v_audio.audioGroupSfxEfectos;
				}
			}
		}

		if(buscaAudioMixerAutomatico){
			
			if (v_audio == null) {
				Debug.Log ("no encuentro adudio");
			} else {
				v_audioMixerGroup = v_audio.audioGroupSfxEfectos;
			}
		}

		if(v_audioSource == null){
			v_audioSource = GetComponent<AudioSource> ();
			v_audioSource.playOnAwake  = false;
			v_audioSource.loop = loop;
			v_audioSource.outputAudioMixerGroup = v_audioMixerGroup;

			if (v_audioClip != null) {
				v_audioSource.clip = v_audioClip;
			}
		}

	}

	public contenedorDeAudio getContendedorDeAudio(){
		return v_audio;
	}

	public AudioMixerGroup getAudioMixerGroup(){
		return v_audioMixerGroup;
	}

	public void setAudioClip(AudioClip _clip , AudioMixerGroup _audioMixerGroup ){
		v_audioClip = _clip;
		v_audioSource.clip = v_audioClip;
		v_audioSource.outputAudioMixerGroup = _audioMixerGroup;
	}

	// Use this for initialization
	void Start () {
		//v_boton.onClick.AddListener (onButtonClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void activarEfecto(int _id){

		if (v_ID != _id) {
			return;
		}

		if (!v_audioSource.isPlaying ) {
			v_audioSource.Play ();
		} else if(sePuedeIntrrumpir){
			v_audioSource.Play ();
		}
	}

	public void activarEfecto(){
		if (!v_audioSource.isPlaying ) {
			v_audioSource.Play ();
		} else if(sePuedeIntrrumpir){
			v_audioSource.Play ();
		}
	}

	public void desActivarEfecto(){
		if (sePuedeIntrrumpir) {
			v_audioSource.Stop ();
		}
	}
}

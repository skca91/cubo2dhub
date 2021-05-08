using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]

public class botonConSonidoV1 : MonoBehaviour {

	public bool buscaSonidoAutomatico = true;
	public bool buscaAudioMixerAutomatico = true;
    public bool usarCoolDown = true;

	AudioMixerGroup v_audioMixerGroup;
	AudioClip v_audioClip;
	AudioSource v_audioSource;
	Button v_boton;


	void Awake(){
		if(buscaSonidoAutomatico){
			contenedorDeAudio _audio = (GameObject.Find ("datosAudio")).GetComponentInChildren<contenedorDeAudio>();
			if (_audio == null) {
				Debug.Log ("no encuentro adudio");
			} else {
				v_audioClip = _audio.clipBoton [0];
				if(buscaAudioMixerAutomatico){
					v_audioMixerGroup = _audio.audioGroupSfxButton;
				}
			}
		}

		if(v_audioSource ==null){
			v_audioSource = GetComponent<AudioSource> ();
			v_audioSource.clip = v_audioClip;
			v_audioSource.playOnAwake  = false;
			v_audioSource.outputAudioMixerGroup = v_audioMixerGroup;
		}

		if(v_boton == null){
			v_boton = GetComponent<Button> ();

		}
	}

	// Use this for initialization
	void Start () {
		v_boton.onClick.AddListener (onButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onButtonClick(){
		v_audioSource.Play ();
        if (usarCoolDown) {
            v_boton.interactable = false;
            Invoke("DesbloquearBotonConSonido",0.5f);
        }
    }

    public void DesbloquearBotonConSonido() {
        v_boton.interactable = true;
    }
}

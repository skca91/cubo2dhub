using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class manejadorAudioMixer : MonoBehaviour {

	public enum estadoAudioMixer
	{
		pausa,
		juegoNormal,
		juegoJefe
	}

	public enum modoAudioMixer
	{
		todo,
		sinMusica,
		sinSFX,
		nada
	}

	public AudioMixer v_audioMixer;
	public Scrollbar v_SliderVolumen;
	public Toggle v_toggleMusica;
	public Toggle v_toggleSFX;
	estadoAudioMixer v_estado = estadoAudioMixer.juegoNormal;
	modoAudioMixer v_modo = modoAudioMixer.todo;

	float v_volumen;

	// Use this for initialization
	void Start () {
		v_SliderVolumen.onValueChanged.AddListener (volumenCheckValue );
		v_toggleMusica.onValueChanged.AddListener (clickToggleMusica );
		v_toggleSFX.onValueChanged.AddListener (clickToggleSFX );


        string v_ConfiguracionAudioTmp = PlayerPrefs.GetString("audioConf");
        if (string.IsNullOrEmpty(v_ConfiguracionAudioTmp)){
            setConfiguracion(0.8f, modoAudioMixer.todo);
        }
        else{
            fromString(v_ConfiguracionAudioTmp);
            actualizarAudioMixer();
        }




	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void actualizarAudioMixer(){
		//v_audioMixer.
//		Debug.Log("volumen " + v_volumen + " modo " + v_modo);
		

		v_audioMixer.SetFloat("volumenMaster",((v_volumen*50)-40));
		//Audio

		if (v_modo == modoAudioMixer.nada) {
			v_audioMixer.SetFloat("volumenMusica",-80);
			v_audioMixer.SetFloat("volumenSFX",-80);
		} else if (v_modo == modoAudioMixer.sinMusica) {
			v_audioMixer.SetFloat("volumenMusica",-80);
			v_audioMixer.SetFloat("volumenSFX",0);
		}else if (v_modo == modoAudioMixer.sinSFX) {
			v_audioMixer.SetFloat("volumenMusica",0);
			v_audioMixer.SetFloat("volumenSFX",-80);
		}else if (v_modo == modoAudioMixer.todo) {
			v_audioMixer.SetFloat("volumenMusica",0);
			v_audioMixer.SetFloat("volumenSFX",0);
		}

	}

	public void volumenCheckValue(float _value){
		if (v_estado == estadoAudioMixer.juegoNormal)
		{
		}

		v_volumen = _value;
		//v_volumen = v_SliderVolumen.value;
		actualizarAudioMixer ();
	}

	public string toString(){
		return "" + v_volumen + "|" + (int)v_modo;
	}

	public void fromString(string _string){
		string[] _datos = _string.Split('|');
		v_volumen = float.Parse(_datos [0]);
		v_modo =(modoAudioMixer) int.Parse (_datos[1]);

	}

	public void setConfiguracion(float _volumen, modoAudioMixer _modo){
		v_volumen = _volumen;
		v_SliderVolumen.value = v_volumen;

		if (v_modo == modoAudioMixer.nada) {
			v_toggleMusica.isOn = false;
			v_toggleSFX.isOn = false;
		} else if (v_modo == modoAudioMixer.sinMusica) {
			v_toggleMusica.isOn = false;
			v_toggleSFX.isOn = true;
		}else if (v_modo == modoAudioMixer.sinSFX) {
			v_toggleMusica.isOn = true;
			v_toggleSFX.isOn = false;
		}else if (v_modo == modoAudioMixer.todo) {
			v_toggleMusica.isOn = true;
			v_toggleSFX.isOn = true;
		}
	}

	public void clickToggleMusica(bool _value){
		
		if (_value) {
			if (v_modo == modoAudioMixer.nada) {
				v_modo = modoAudioMixer.sinSFX;
			} else if (v_modo == modoAudioMixer.sinMusica) {
				v_modo = modoAudioMixer.todo;
			}
		} else {
			if (v_modo == modoAudioMixer.todo) {
				v_modo = modoAudioMixer.sinMusica;
			} else if (v_modo == modoAudioMixer.sinSFX) {
				v_modo = modoAudioMixer.nada;
			}
		}

		actualizarAudioMixer ();
	}

	public void clickToggleSFX(bool _value){
		if (_value) {
			if (v_modo == modoAudioMixer.nada) {
				v_modo = modoAudioMixer.sinMusica;
			} else if (v_modo == modoAudioMixer.sinSFX) {
				v_modo = modoAudioMixer.todo;
			}
		} else {
			if (v_modo == modoAudioMixer.todo) {
				v_modo = modoAudioMixer.sinSFX;
			} else if (v_modo == modoAudioMixer.sinMusica) {
				v_modo = modoAudioMixer.nada;
			}
		}
		actualizarAudioMixer ();
	}
		
}

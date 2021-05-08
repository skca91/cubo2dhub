using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juegoConEnergia : MonoBehaviour {

	public string idVersionJuego;
	public string idEnergia;
	public float tiempoRecargaEnSegundos;
	public float limiteDeEnergia;
	public UnityEngine.UI.Text textoEspera;
	public UnityEngine.UI.Text textoContadorEnergiaActual;


	int energiaActual;
	//System.DateTime ultimoUsoEnergia;
	System.DateTime recarga;
	float esperaParaRecargaEnSegundos;
	// Use this for initialization
	void Start () {
		energiaActual = 0;
		setEnergia (3);
		cargar ();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public void calcularEnergia(){
		if (energiaActual < limiteDeEnergia) {
			if ((recarga - System.DateTime.UtcNow ).TotalSeconds <= 0) {
				energiaActual++;
				SendMessage ("recargaEnergiaCompleta");
				recarga =System.DateTime.UtcNow.AddSeconds(tiempoRecargaEnSegundos);
				//Debug.Log ("ENERGIA ++ " +energiaActual);
			} else {
				esperaParaRecargaEnSegundos = (float)(recarga - System.DateTime.UtcNow ).TotalSeconds;
				//Debug.Log ("espera: " + esperaParaRecargaEnSegundos.ToString ()+" en time "+System.TimeSpan.FromSeconds ((int)esperaParaRecargaEnSegundos).ToString());
				if(textoEspera!=null){
					
					//textoEspera.text = esperaParaRecargaEnSegundos.ToString ();
					textoEspera.text = System.TimeSpan.FromSeconds ((int)esperaParaRecargaEnSegundos).ToString();
				}
			}

            if (textoContadorEnergiaActual != null)
            {
                textoContadorEnergiaActual.text = energiaActual.ToString();
            }
        } else {
			CancelInvoke ("calcularEnergia");
		}
	}
	/**Suma energia extra, tambien valida el limite maximo*/
	public void setEnergia(int _energiaExtra){
		Debug.Log ("set energia " + energiaActual + " nueva " +_energiaExtra);
		energiaActual += _energiaExtra;
		if(energiaActual > limiteDeEnergia){
			energiaActual =(int)limiteDeEnergia;
		}
		SendMessage ("recargaEnergiaCompleta");
	}

	/*Se Implementa en los hermanos*/
	public void recargaEnergiaCompleta(){
		if (textoContadorEnergiaActual != null) {
			textoContadorEnergiaActual.text = energiaActual.ToString ();
		}
	}

	public void guardar(){
		if (idVersionJuego.Equals ("")) {
			Debug.Log ("se recomienda usar un identificador de juego con energia "+idEnergia.ToUpper()+" para el juego");
		} else {
			PlayerPrefs.SetString ("juegoEnergia" + idVersionJuego+idEnergia, toStringDatos ());
		}

		//Debug.Log ("guarda energia " +toStringDatos());
	}

	public void cargar(){

		if (idVersionJuego.Equals ("")) {
			Debug.Log ("se recomienda usar un identificador de juego con energia "+idEnergia.ToUpper()+" para el juego");
		} else {
			fromStringDatos( PlayerPrefs.GetString ("juegoEnergia" + idVersionJuego+idEnergia, toStringDatos ()));
		}

		if ((recarga - System.DateTime.UtcNow ).TotalSeconds <= 0) {
			
			energiaActual = 1 + (int)((System.DateTime.UtcNow - recarga ).TotalSeconds % tiempoRecargaEnSegundos);

			if (energiaActual > (int)limiteDeEnergia) {
				energiaActual = (int)limiteDeEnergia;
			}

			SendMessage ("recargaEnergiaCompleta");
			recarga =System.DateTime.UtcNow.AddSeconds(tiempoRecargaEnSegundos);
        }
        else {
            if (!IsInvoking("calcularEnergia"))
            {
                recarga = System.DateTime.UtcNow.AddSeconds(tiempoRecargaEnSegundos);
                InvokeRepeating("calcularEnergia", 1, 1);
            }
        }

        if (textoContadorEnergiaActual != null)
        {
            textoContadorEnergiaActual.text = energiaActual.ToString();
        }

    }

	public string toStringDatos(){
		string _datos = "";
		_datos += energiaActual.ToString ()+";";
		_datos += recarga.ToString ();

		Debug.Log ("to " +_datos);
		return _datos;
	}

	public void fromStringDatos(string _datos){

		Debug.Log (idEnergia+" from " +_datos);

		string[] datosString = _datos.Split (';');
		int.TryParse (datosString [0], out energiaActual);
		System.DateTime.TryParse (datosString [1],out recarga);
        Debug.Log("energia actual "+ energiaActual);
	}

	public void consumirEnergiaDev(){
		consumirEnergia ();
	}

	public bool consumirEnergia(){
		if (energiaActual > 0) {
			energiaActual--;
			//ultimoUsoEnergia = System.DateTime.UtcNow;


			//System.DateTime.

			//Debug.Log ("Ultimo uso: "+ultimoUsoEnergia.ToString("T"));

			if(!IsInvoking("calcularEnergia")){
				recarga =System.DateTime.UtcNow.AddSeconds(tiempoRecargaEnSegundos);
				InvokeRepeating ("calcularEnergia", 1, 1);
			}
			guardar ();
            if (textoContadorEnergiaActual != null)
            {
                textoContadorEnergiaActual.text = energiaActual.ToString();
            }
            return true;
		} else {
			return false;
		}
	}

	public int getEnergiaActual(){
		return energiaActual;
	}
}

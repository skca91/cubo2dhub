using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(participanteTorneo))]

public class torneoCubo2D : MonoBehaviour {

	public enum tipoTorneo
	{
		pierdeElProgreso,
		mantieneElProgreso
	}

	public List<string> participantesTorneo;
	public string nombre;
	public int nivelMinimo;
	public Dictionary<string, string> premios;
	public int progresoActual = 0;
	public int mejorResultado = 0;
    float ContTiempoLigaActual;


    public void Awake(){
		premios = new Dictionary<string, string> ();
		participantesTorneo = new List<string> ();
	}

	// Use this for initialization
	void Start () {

        ContTiempoLigaActual = PlayerPrefs.GetFloat("TextContadorTiempoJugadoTorneo", ContTiempoLigaActual);


        InvokeRepeating("ActualizarDuracionTorneo", 0,1.0f);

		/*nombre = "Super Torneo Definitivo Master";
		nivelMinimo = 3;

		premios = new Dictionary<string, string> ();

		premios.Add ("ganador", "mucha_exp;trofeo;oro");
		premios.Add ("segundo", "mucha_exp;oro");
		premios.Add ("tercero", "exp;oro");
		premios.Add ("participantes", "exp");

		participantesTorneo = new List<string> ();

		/*idPersonaje;poder;rango;nombre*/
		/*participantesTorneo.Add("1001;100;0;pepe");
		participantesTorneo.Add("1004;200;0;maria");
		participantesTorneo.Add("1007;300;0;julia");
		participantesTorneo.Add("1001;400;0;jose");
		participantesTorneo.Add("1007;500;0;stephanie");
		participantesTorneo.Add("1005;600;0;pedro");*/

		//mejorResultado = 0;
		//progresoActual = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string DuracionTorneoString() { 
    
        return System.TimeSpan.FromSeconds(ContTiempoLigaActual).ToString();
    
    }

    public void ReiniciarContadorTiempo() {
        ContTiempoLigaActual = 0;
        PlayerPrefs.SetFloat("TextContadorTiempoJugadoTorneo", ContTiempoLigaActual);
    }

    public void ActualizarDuracionTorneo() {

        ContTiempoLigaActual += 1;
        PlayerPrefs.SetFloat("TextContadorTiempoJugadoTorneo", ContTiempoLigaActual);
    }

    public string toString(){
		string _datos = "";
		_datos += nombre+"+";
		_datos += nivelMinimo.ToString()+"+";
		foreach(KeyValuePair<string,string> p in premios){
			_datos+=p.Key+"-"+p.Value+"*";
		}
		_datos+="+";
		foreach(string p in participantesTorneo){
			_datos+=p+"-";
		}

		return _datos;
	}

	public void fromString(string _datos){
		string[] _todosDatos = _datos.Split ('+');
		nombre = _todosDatos [0];
		nivelMinimo = int.Parse (_todosDatos[1]);

		string[] _datosLista = _todosDatos [2].Split ('*');

		premios.Clear ();

		foreach(string datoUnido in _datosLista){
			if (datoUnido.Length > 0) {
				string[] _datoSeparado = datoUnido.Split ('-');
				premios.Add (_datoSeparado [0], _datoSeparado [1]);
			}
		}
		_datosLista = _todosDatos [3].Split ('-');
		participantesTorneo.Clear ();

		foreach(string datoUnido in _datosLista){
			if (datoUnido.Length > 0) {
				participantesTorneo.Add (datoUnido);
			}
		}
	}



}

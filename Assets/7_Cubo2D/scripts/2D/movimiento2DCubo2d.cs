using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento2DCubo2d : MonoBehaviour {

	public enum modoReporte{
		ninguno,
		hermanos,
		padres,
		hijos
	}

	public modoReporte reporte;
	public float velocidad = 1.0F;
//	public float 
	private float tiempoInicioMovimiento;
	private float distancia;

	Vector3 inicioMovimiento;
	Vector3 destinoMovimiento;
	bool movimientoActivo = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(movimientoActivo){
			float distCovered = (Time.time - tiempoInicioMovimiento) * velocidad;
			float fracJourney = distCovered / distancia;
			transform.position = Vector3.Lerp(inicioMovimiento, destinoMovimiento, fracJourney);
			if (Vector3.Distance (transform.position, destinoMovimiento) < 0.01f) {
				movimientoActivo = false;
				reportar ();
			}
		}
	}

	public void mover2D(Vector3 posInicial,Vector3 posFinal, float tiempo){
		tiempoInicioMovimiento = Time.time;
		inicioMovimiento = posInicial;
		destinoMovimiento = posFinal;
		distancia = Vector3.Distance(inicioMovimiento, destinoMovimiento);
		movimientoActivo = true;
	}

	public void reportar(){
		if (reporte == modoReporte.ninguno) {
		
		} else if (reporte == modoReporte.padres) {
			SendMessageUpwards ("movimientoCompleto");
		}
	}

	public void movimientoCompleto(){
		
	}
}

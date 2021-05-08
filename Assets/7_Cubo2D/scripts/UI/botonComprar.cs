using UnityEngine;
using System.Collections;

public class botonComprar : MonoBehaviour {

	public int id;
	public string tipo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void actualizarCostoArma( int _id){
		id = _id;
		/*if (id < 10) {
			tipo = "arma";
			variablesGlobales.costoMonedas = costos.costoArmaMonedas[id];
			variablesGlobales.costoRubis = costos.costoArmaRubies[id];
			variablesGlobales.costoJefes = costos.costoArmaJefes[id];
			variablesGlobales.descripCompra = idioma.descripcionArma;
		}else if(id > 9) {
			tipo = "mascota";
			id = id -10;
			variablesGlobales.costoMonedas = costos.costoMascotaMonedas[id];
			variablesGlobales.costoRubis = costos.costoMascotaRubies[id];
			variablesGlobales.costoJefes = costos.costoMascotaJefes[id];
			variablesGlobales.descripCompra = idioma.descripcionMini;
		}else if(id > 19) {
			tipo = "casa";
			id = id -20;
			variablesGlobales.costoMonedas = costos.costoArmaMonedas[id];
			variablesGlobales.costoRubis = costos.costoArmaRubies[id];
			variablesGlobales.costoJefes = costos.costoArmaJefes[id];
			variablesGlobales.descripCompra = idioma.descripcionCasa;
			
		}*/
	}

	public void comprar(){

	/*	Debug.Log ("TRAto de comptar");
		if (PerfilJugador.totalMonedas >= variablesGlobales.costoMonedas && 
			PerfilJugador.totalRubis >= variablesGlobales.costoRubis &&
			PerfilJugador.totalJefes >= variablesGlobales.costoJefes) {
			
			Debug.Log ("tiene dinero ");
			if(tipo.Equals("arma")){
				if(PerfilJugador.arma[id].bloqueado == 1){
					
					PerfilJugador.totalMonedas-=variablesGlobales.costoMonedas;
					PerfilJugador.totalRubis-=variablesGlobales.costoRubis;
					PerfilJugador.arma[id].bloqueado = 0;
					
					Debug.Log("Se compro el arma "+id);
				}
			}else if(tipo.Equals("mascota")){
				if(PerfilJugador.mascota[id].bloqueado == 1){
					
					PerfilJugador.totalMonedas-=variablesGlobales.costoMonedas;
					PerfilJugador.totalRubis-=variablesGlobales.costoRubis;
					PerfilJugador.mascota[id].bloqueado = 0;
					
					Debug.Log("Se compro el mascota "+id);
				}
			}else if(tipo.Equals("casa")){
				if(PerfilJugador.casa[id].bloqueado == 1){
					
					PerfilJugador.totalMonedas-=variablesGlobales.costoMonedas;
					PerfilJugador.totalRubis-=variablesGlobales.costoRubis;
					PerfilJugador.casa[id].bloqueado = 0;
					
					//Debug.Log("Se compro el item "+id);
				}
			}



			PerfilJugador p = new PerfilJugador();
			p.guardarPerfil();
		}*/
	}
}

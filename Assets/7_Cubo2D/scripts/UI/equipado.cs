using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class equipado : MonoBehaviour {

	public int id;
	public bool arma,mascota,casa;
	Image imagen;
	// Use this for initialization
	void Start () {
		imagen = gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void actuaizar(){
		/*if (arma) {
			if(id == PerfilJugador.idArmaEquipada){
				mostrar();
			}else{
				ocultar();
			}
		}else if(mascota){
			if(id == PerfilJugador.idMascotaEquipada){
				mostrar();
			}else{
				ocultar();
			}
		}else if(casa){
			if(id == PerfilJugador.idCasaActual){
				mostrar();
			}else{
				ocultar();
			}
		}*/
	}
	void mostrar(){
		if (imagen != null) {
			//	imagen.enabled = true;
			imagen.color = new Color(imagen.color.r,imagen.color.g,imagen.color.b,1.0f);
		}
	}
	
	void ocultar(){
		if (imagen != null) {
			//	imagen.enabled = false;
			imagen.color = new Color(imagen.color.r,imagen.color.g,imagen.color.b,0.0f);
		}
	}
}

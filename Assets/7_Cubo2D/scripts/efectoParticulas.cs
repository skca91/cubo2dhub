using UnityEngine;
using System.Collections;

public class efectoParticulas : MonoBehaviour {

	public enum modo{
		activar,
		desactivar,
		pingpong
	}

	ParticleSystem v_particulas;
	public bool sePuedeInterrumpir = false;
	/**Se usa para diferenciar diferentes efectos*/
	public int v_id = -1;
	public modo v_modo = modo.activar;
	// Use this for initialization
	void Start () {
		v_particulas = GetComponent<ParticleSystem> ();
	}
	


	public void sensorImpulso(){
		sensorImpulsoID(-1);
	}

	public void sensorImpulsoID(int _id){
		if (v_id != -1) {
			if(v_id == _id){
				activarEfectoEnModo (v_modo);
			}
		} else {
			activarEfectoEnModo (v_modo);
		}
		
	}

	public void activarEfectoEnModo( modo _modo){
		if(_modo == modo.activar){
			activarEfecto ();
		}else if(_modo == modo.desactivar){
			desactivarEfecto ();
		}else if(_modo == modo.pingpong){
			if (v_particulas.isPlaying) {
				desactivarEfecto ();
			} else {
				activarEfecto ();
			}
		}
	}

	public void activarEfecto(int _id){
		if (_id == v_id) {
			if (!v_particulas.isPlaying || sePuedeInterrumpir) {
				v_particulas.Play();
			}
		}
	}

	public void desactivarEfecto(int _id){
		if (_id == v_id) {
			if (!v_particulas.isPlaying || sePuedeInterrumpir) {
				v_particulas.Stop();
			}
		}
	}

	public void activarEfecto(){
		if (!v_particulas.isPlaying) {
			v_particulas.Play();
		}
	}

	public void desactivarEfecto(){
		if (v_particulas.isPlaying) {
			v_particulas.Stop();
		}
	}
}

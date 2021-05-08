using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skin_sync : MonoBehaviour {

	public GameObject[] v_enemigoSkin;
	//public Material[] v_material;
	bool autoSkinSync = false;
	public int v_idEnemigoSkin;
	public int v_idTextura;
	public float v_escalaEnemigo;

	GameObject v_enemigoSkinActual;
	SkinnedMeshRenderer _skinneMesh;
	MeshRenderer _mesh;

	string v_datosSkinSync;
	// Use this for initialization
	void Start () {
		v_datosSkinSync = getConfiguracionSkinString ();
	}


	// Update is called once per frame
	void Update () {

	}

	public void serverAutoSkinSync(){
		if (autoSkinSync) {
			setConfiguracionSkin (v_idEnemigoSkin,v_idTextura,v_escalaEnemigo);
		}
	}

	private void OnActualizarDatosSkinSync(string _datosSkinSync){
		//Debug.Log (" datos sync: " +_datosSkinSync);
		fromSkinString (_datosSkinSync);
		crear (v_idEnemigoSkin,v_idTextura,v_escalaEnemigo);
	}

	/**Inicializa las variable y actualiza los datos en el servidor pero no crea el skin de manera directa*/
	public void setConfiguracionSkin(int _idEnemigoSkin, int _idTextura, float _escalaEnemigo){

		v_idEnemigoSkin = _idEnemigoSkin;
		v_idTextura = _idTextura;
		v_escalaEnemigo = _escalaEnemigo;

		v_datosSkinSync = getConfiguracionSkinString ();

	}

	public void fromSkinString(string _skinString){

		if (_skinString.Length < 1)
			return;

		string[] datos = _skinString.Split ('|');

		v_idEnemigoSkin = int.Parse (datos [0]);
		v_idTextura = int.Parse (datos [1]);
		v_escalaEnemigo = float.Parse (datos [2]);

	}

	public string getConfiguracionSkinString(){
		return v_idEnemigoSkin + "|" + v_idTextura + "|" + v_escalaEnemigo;
	}

	public void RpcMostrar(){
		mostrar ();
	}

	public void RpcOcultar(){
		ocultar ();
	}

	public void mostrar(){
		if(_mesh!=null){
			_mesh.enabled =true;
		}

		if(_skinneMesh!=null){
			_skinneMesh.enabled = true;
		}
	}

	public void ocultar(){
		if(_mesh!=null){
			_mesh.enabled = false;
		}

		if(_skinneMesh!=null){
			_skinneMesh.enabled = false;
		}
	}

	/**Crea el skin y inicializa las variables*/
	public void crear(int _idEnemigoSkin, int _idTextura, float _escalaEnemigo){

		if (v_enemigoSkinActual != null) {
			Destroy (v_enemigoSkinActual.gameObject);
		}

		v_idEnemigoSkin = _idEnemigoSkin;
		v_idTextura = _idTextura;
		v_escalaEnemigo = _escalaEnemigo;

		GameObject obj;

		if (v_idEnemigoSkin > v_enemigoSkin.Length) {
			obj = v_enemigoSkin[0];
			foreach(GameObject go in v_enemigoSkin){
				//				Debug.Log ("skin id: " +go.GetComponent<enemigo_materiales_posibles>().v_id  );
				if(go.GetComponent<enemigo_materiales_posibles>().v_id == v_idEnemigoSkin){

					obj = go;
					break;
				}
			}
		} else {
			obj = v_enemigoSkin[v_idEnemigoSkin];
		}

		_skinneMesh = obj.GetComponentInChildren<SkinnedMeshRenderer> ();
		_mesh = obj.GetComponentInChildren<MeshRenderer> ();
		Animator _animator = obj.GetComponentInChildren<Animator> ();
		enemigo_materiales_posibles _materiales = obj.GetComponentInChildren<enemigo_materiales_posibles> ();

		if (v_idTextura == -1) {
			v_idTextura = Random.Range (0,_materiales.materialLength());

		}
		if (_skinneMesh != null) {
			_skinneMesh.material = _materiales.materialId (v_idTextura);
		} else if (_mesh != null) {
			_mesh.material = _materiales.materialId (v_idTextura);
		} else {
			Debug.Log ("No hay mesh Render ni skinne Mesh Render ");
		}

		_animator.gameObject.transform.localScale = new Vector3 (v_escalaEnemigo,v_escalaEnemigo,v_escalaEnemigo);

		ajustar_altura_barra_vida barraVida = GetComponentInChildren<ajustar_altura_barra_vida> ();
		if(barraVida!=null){
			barraVida.setAltura (v_escalaEnemigo);
		}

		v_enemigoSkinActual = (GameObject) Instantiate(obj, transform.position, transform.rotation,this.transform);

		//mostrar ();

	}
}

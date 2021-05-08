using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonComprarYMejorarItemV1 : MonoBehaviour {


	[SerializeField]
	private Image v_icono;
	[SerializeField]
	private Button v_botonComprarYMejorar;
	[SerializeField]
	private Image v_imagenBarraProgresoMejora;
	[SerializeField]
	private Text v_textNombre;
	[SerializeField]
	private Text v_textRequerimientosOInfoMejora;
	[SerializeField]
	private Text v_textCostoMejora;
	[SerializeField]
	private Text v_textNivelMejoraActual;
	[SerializeField]
	private Image v_iconoBloqueado;

	private string v_id;
	private int v_nivelMejoraActual;
	private int v_nivelMejoraMaximo;
	private int[] v_frecuenciaUpgrade;
	float progresoMejora = 0;
	// Use this for initialization
	void Start () {
		if (v_botonComprarYMejorar != null) {
			v_botonComprarYMejorar.onClick.AddListener (comprarMejorar);
		}

		if (v_imagenBarraProgresoMejora != null) {
			v_imagenBarraProgresoMejora.type = Image.Type.Filled;
			v_imagenBarraProgresoMejora.fillMethod = Image.FillMethod.Horizontal;

		}
	}

	public int[] calcularUpgrades(string _datosUpgrade){




		string[] _datos = _datosUpgrade.Split (';');
		int[] upgrades =null;
		upgrades= new int[_datos.Length];
		for(int i = 0; i < _datos.Length; i++){
			upgrades [i] = int.Parse (_datos [i].ToString());
		}

		return upgrades;
	}

	public void configurarBoton(string _id,string _nombre, Sprite _icono , string _costo1, string _nivel, string _requerimientoOInfo, string _frecuenciaUpgrade, bool _bloqueado, bool _disponibleParaComprar){

		Debug.Log ("boton " +_id + " " +_disponibleParaComprar);

		v_id = _id;
		v_icono.sprite = _icono;
		v_textNombre.text = _nombre;
		v_textCostoMejora.text = _costo1 ;
		v_nivelMejoraActual = int.Parse( _nivel);
		v_textNivelMejoraActual.text = "Nivel "+v_nivelMejoraActual+".";
		v_textRequerimientosOInfoMejora.text = _requerimientoOInfo;
		//v_nivelMejoraMaximo = int.Parse(_mejoraMaxima);
		v_frecuenciaUpgrade = calcularUpgrades(_frecuenciaUpgrade);
		v_botonComprarYMejorar.interactable = _disponibleParaComprar;

		//calculo progreso
		int upgradeActual = 0;
		int upgradeAnterior = 0;

		foreach( int upgrade in v_frecuenciaUpgrade){
			//upgradeActual = upgrade;
			if (v_nivelMejoraActual < upgrade) {
				upgradeActual = upgrade;
				break;
			} else {
				upgradeAnterior = upgrade;
			}

		}

		v_imagenBarraProgresoMejora.fillAmount = (float)(v_nivelMejoraActual - upgradeAnterior) / (float)(upgradeActual - upgradeAnterior);

//		Debug.Log ("upgrade actual " +upgradeActual+ " nivel actual " +v_nivelMejoraActual + " upgrade anterior " +upgradeAnterior);
	}

	public string id{
		get { return v_id;}
		set { v_id = value;}
	}

	public void comprarMejorar(){
		SendMessageUpwards ("botonComprarMejorar",v_id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

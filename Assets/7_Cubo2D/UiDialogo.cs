using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(menu))]

public class UiDialogo : MonoBehaviour {

	[SerializeField]
	private Text tituloText;
	[SerializeField]
	private Text tituloDescripcion;
	[SerializeField]
	private Button SiButton;
	[SerializeField]
	private Button NoButton;

	public string titulo{
		set{ 
			tituloText.text = value;
		}
	}

	public string descripcion{
		set{ 
			tituloDescripcion.text = value;
		}
	}

	public string textoSiButton{
		set{ 
			SiButton.GetComponentInChildren<Text>().text = value;
		}
	}

	public string textoNoButton{
		set{ 
			NoButton.GetComponentInChildren<Text>().text = value;
		}
	}

	public void onClickSiButton( UnityEngine.Events.UnityAction action ){
		SiButton.onClick.AddListener (action);
	}

	public void onClickNoButton( UnityEngine.Events.UnityAction action ){
		NoButton.onClick.AddListener (action);
	}


}

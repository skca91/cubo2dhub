using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEntradaNoticia : MonoBehaviour {

	[SerializeField]
	Image IconoImage;
	[SerializeField]
	Text TituloText;
	[SerializeField]
	Text ContenidoText;
	[SerializeField]
	Text FechaText;
	// Use this for initialization
	void Start () {
		
	}

	public Sprite Icono{
		set { IconoImage.sprite = value;}
	}

	public string Titulo{
		set{ 
			TituloText.text = value;
		}
	}

	public string Contenido{
		set{
			ContenidoText.text = value;
		}
	}

	public string Fecha{
		set{ 
			FechaText.text = value;
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class idiomaV2 : MonoBehaviour {

	public static string idiomaActual = "ES"; /**/
	public TextAsset GameAsset;
	//public XmlText XML;
	XmlDocument xmlDoc;
	static XmlNodeList listaPalabrasEnXML;

	void Awake(){
		detectarIdioma ();
		cargaManual ();
	}
	// Use this for initialization
	void Start () {
		
	}

	public void detectarIdioma(){

		if (PlayerPrefs.GetString ("idiomaV2", "").Equals ("")) {
			if (Application.systemLanguage == SystemLanguage.Spanish) {
				idiomaActual = "ES";
				//Debug.Log ("Idioma "+idiomaActual);
			} else {
				idiomaActual = "EN";
			}
		} else {
			idiomaActual = PlayerPrefs.GetString ("idiomaV2", "EN");
		}



		//idiomaActual = "ES";

	}

	public void onClickCambiarIdioma(){
		if (idiomaActual.Equals ("ES")) {
			idiomaActual = "EN";
		} else {
			idiomaActual = "ES";
		}
        PlayerPrefs.GetString ("idiomaV2", idiomaActual);
	}

	public void cargaManual(){

		xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(GameAsset.text); // load the file.
		listaPalabrasEnXML =  xmlDoc.GetElementsByTagName(idiomaActual);
	}


	public static string textoTraducido(string textoId){

        //Idioma

        //Debug.Log("idioma " + idiomaActual + " tecto " + textoId);

        foreach (XmlNode nodoActualXML in listaPalabrasEnXML) {

			XmlNodeList listaTexto = nodoActualXML.ChildNodes;

			foreach (XmlNode texto in listaTexto) {
				if (texto.Name.Equals ("texto")) {
					if(texto.Attributes["id"].Value.ToUpperInvariant().Equals(textoId.ToUpperInvariant()))
						return texto.InnerText;
				}
			}
		}

		return "["+idiomaActual+"]"+textoId+"";
	}
}

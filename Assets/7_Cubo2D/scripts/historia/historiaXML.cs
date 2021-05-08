using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class historiaXML: MonoBehaviour {

	public TextAsset GameAsset;

	public List<nodoXML> listaDeNodos = new List<nodoXML>();

	void Awake(){
		loadManual ();
	}

	void Start () {
		//ImprimirHistoria ();
	}

	public void loadHistoria(string _nombre){
		
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(GameAsset.text); // load the file.

		XmlNodeList historiaEnXML = xmlDoc.GetElementsByTagName(_nombre);
		XmlNodeList listaNodosEnXML = null;

		/*foreach (XmlNode historia in historiaEnXML) {

			listaNodosEnXML = historia.ChildNodes;

			//if (nodo.Name.Equals ("nodo")) {

				//nodo.
				
				TextoXML texto = new TextoXML();
				texto.personaje = nodo.Attributes ["personaje"].InnerText;
				texto.expresion = nodo.Attributes ["expresion"].InnerText;
				texto.dialogo = nodo.InnerText;
				//Debug.Log ("Texto: " +subNodo.InnerText);
				nodoXML.addTexto (texto);
			//}
		}*/

		listaNodosEnXML = xmlDoc.GetElementsByTagName("nodo"); // array of the level nodes.

		foreach (XmlNode nodoActualXML in listaNodosEnXML) {
			nodoXML nodoXML = new nodoXML();
			nodoXML.id = nodoActualXML.Attributes ["id"].Value;

			XmlNodeList listaTexto = nodoActualXML.ChildNodes;

			foreach (XmlNode subNodo in listaTexto) {
				if (subNodo.Name.Equals ("texto")) {
					TextoXML texto = new TextoXML();
					texto.personaje = subNodo.Attributes ["personaje"].InnerText;
					texto.expresion = subNodo.Attributes ["expresion"].InnerText;
					texto.dialogo = subNodo.InnerText;
					//Debug.Log ("Texto: " +subNodo.InnerText);
					nodoXML.addTexto (texto);
				}else if(subNodo.Name.Equals ("opcion")){
					opcionXML opcion = new opcionXML();
					opcion.nodo = subNodo.Attributes ["nodo"].InnerText;
					opcion.accion = subNodo.Attributes ["accion"].InnerText;
					opcion.textoOpcion = subNodo.InnerText;

					//Debug.Log ("Opcion: " +subNodo.InnerText);
					nodoXML.addOpcion (opcion);
				}
			}

			listaDeNodos.Add (nodoXML);
		}
	}

	public void loadManual(){
		loadHistoria ("historia");
	}

	public void ImprimirHistoria(){
		foreach(nodoXML nodo in listaDeNodos){
			Debug.Log ("Nodo: " +nodo.id);
			foreach(TextoXML texto in nodo.textos){
				Debug.Log ("Texto: " +texto.dialogo);

			}
			foreach(opcionXML opcion in nodo.opciones){
				Debug.Log ("Opcion: " +opcion.textoOpcion);

			}
			Debug.Log ("------------------");
		}
	}


	public static historiaXML Load(string path)
	{
		var serializer = new XmlSerializer(typeof(historiaXML));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as historiaXML;
		}
	}


}

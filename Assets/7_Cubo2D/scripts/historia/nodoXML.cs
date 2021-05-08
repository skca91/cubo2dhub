using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


public class nodoXML {

	[XmlAttribute("id")]
	public string id;


	public List<opcionXML> opciones = new List<opcionXML>();

	public List<TextoXML> textos = new List<TextoXML>();

	public nodoXML(){
		textos = new List<TextoXML> (2);
		opciones = new List<opcionXML>(1);
	}

	public void addTexto(TextoXML text){
		textos.Add (text);
	}

	public void addOpcion(opcionXML opcion){
		opciones.Add (opcion);
	}

	public opcionXML getOpcion(int index){
		return null;
	} 
}

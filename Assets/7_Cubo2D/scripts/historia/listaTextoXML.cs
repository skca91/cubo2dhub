using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("lista_texto")]
public class listaTextoXML {

	[XmlArray("textos")]
	[XmlArrayItem("texto")]
	public List<TextoXML> textos = new List<TextoXML>();

	[XmlArray("opciones")]
	[XmlArrayItem("opcion")]
	public List<TextoXML> opcion = new List<TextoXML>();


	public static listaTextoXML Load(string path)
	{
		var serializer = new XmlSerializer(typeof(listaTextoXML));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as listaTextoXML;
		}
	}

}

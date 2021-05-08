using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class opcionXML {


	[XmlAttribute("nodo")]
	public string nodo;

	[XmlAttribute("accion")]
	public string accion;

	public string textoOpcion;
}

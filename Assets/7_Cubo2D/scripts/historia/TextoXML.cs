using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class TextoXML{

	[XmlAttribute("id")]
	public string id;

	[XmlAttribute("personaje")]
	public string personaje;

	[XmlAttribute("expresion")]
	public string expresion;

	public string dialogo;
}

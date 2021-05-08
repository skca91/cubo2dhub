using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class personaje{
	
	[XmlAttribute("nombre")]
	public string nombre;

	[XmlAttribute("imagen_expresion")]
	public string[] imagen_normal;

}

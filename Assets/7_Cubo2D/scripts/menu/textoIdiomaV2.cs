using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
#if UNITY_EDITOR
using UnityEditor;
#endif


[ExecuteInEditMode]
public class textoIdiomaV2 : MonoBehaviour {

	public enum modoMuestraTexto{sinCambios,todoMayusculas,primeraLetraMayuscula}

	Text texto;
	Text[] textoInChildren;
	public string tipoTexto;
	public bool actualizarEnTiempoReal = false;
	public bool noTraducir = false;
	public bool modificarTextoInChildren = false;
	public modoMuestraTexto modoTexto = modoMuestraTexto.sinCambios;

	void Start () {

		texto = GetComponent<Text> ();
		textoInChildren = GetComponentsInChildren<Text> ();
		//actualizarTexto ();

        if (Application.isPlaying)
        {
            actualizarTexto();
        }
        else
        {
            //tipoTexto = texto.text;
            tipoTexto = tipoTexto.Replace("{", "");
            tipoTexto = tipoTexto.Replace("}", "");
            InvokeRepeating("actualizarTextoEditor", 0.1f, 0.5f);
        }
    }

	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            if (actualizarEnTiempoReal)
            {
                actualizarTexto();
            }
        }
        else {
           // texto.text = "{"+tipoTexto+"}";
        }
       
#else

        if (actualizarEnTiempoReal) {
			actualizarTexto ();
		}
#endif

    }

    public void actualizarTextoEditor()
    {

        texto.text = "{" + tipoTexto + "}";
    }



    public void actualizarTexto(){

		if (texto == null)
			return;
		if (noTraducir) {
			texto.text = tipoTexto;
		} else {

			if (modoTexto.Equals (modoMuestraTexto.sinCambios)) {
				texto.text = idiomaV2.textoTraducido (tipoTexto);
			}else if(modoTexto.Equals (modoMuestraTexto.todoMayusculas)){
				texto.text = idiomaV2.textoTraducido (tipoTexto).ToUpper();
			}else if(modoTexto.Equals (modoMuestraTexto.primeraLetraMayuscula)){
				texto.text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(idiomaV2.textoTraducido(tipoTexto));
            }
            else{
				texto.text = idiomaV2.textoTraducido (tipoTexto);
			}



		}


		if (modificarTextoInChildren) {
			foreach(Text t in textoInChildren){
				t.text = texto.text;
			}
		}
	}

	public void setTextoID(string _idTexto){
		tipoTexto = _idTexto;
		actualizarTexto ();
	}


	public void setTextoLiteral(string mensaje){
		
		if (texto == null) {
			texto = GetComponent<Text> ();
			if (modificarTextoInChildren) {
				textoInChildren = GetComponentsInChildren<Text> ();
			}
		}

		tipoTexto = mensaje;

		actualizarTexto ();
	}
}

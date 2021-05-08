using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
#if UNITY_EDITOR
using UnityEditor;
#endif


[ExecuteInEditMode]
public class textoIdiomaV3 : MonoBehaviour
{

    public enum modoMuestraTexto { sinCambios, todoMayusculas, primeraLetraMayuscula }

    Text texto;
    public string tipoTexto;
    public bool noTraducir = false;
    public bool agregar2Puntos = false;
    public modoMuestraTexto modoTexto = modoMuestraTexto.primeraLetraMayuscula;

    void Start()
    {

        texto = GetComponent<Text>();



#if UNITY_EDITOR

        if (Application.isPlaying)
        {
            actualizarTexto();
        }
        else {
            //tipoTexto = texto.text;
            //tipoTexto = tipoTexto.Replace("{", "");
            //tipoTexto = tipoTexto.Replace("}", "");
            InvokeRepeating("actualizarTextoEditor", 0.1f+Random.Range(0.1f,0.2f), 3.0f);
        }
#else
        actualizarTexto();
#endif

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void actualizarTextoEditor() {
        string _agregarAlFinal = "";
        if (agregar2Puntos)
            _agregarAlFinal = ":";

        texto.text = "{" + tipoTexto+ _agregarAlFinal + "}";
    }

    public void actualizarTexto()
    {

        if (texto == null)
            return;
        if (noTraducir)
        {
            texto.text = tipoTexto;
        }
        else
        {

            string _agregarAlFinal = "";
            if (agregar2Puntos)
                _agregarAlFinal = ":";

            if (modoTexto.Equals(modoMuestraTexto.sinCambios))
            {
                texto.text = idiomaV2.textoTraducido(tipoTexto)+ _agregarAlFinal;
            }
            else if (modoTexto.Equals(modoMuestraTexto.todoMayusculas))
            {
                texto.text = idiomaV2.textoTraducido(tipoTexto).ToUpper()+ _agregarAlFinal;
            }
            else if (modoTexto.Equals(modoMuestraTexto.primeraLetraMayuscula))
            {
                texto.text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(idiomaV2.textoTraducido(tipoTexto))+ _agregarAlFinal;
            }
            else
            {
                texto.text = idiomaV2.textoTraducido(tipoTexto)+ _agregarAlFinal;
            }



        }
    }

    public void setTextoID(string _idTexto)
    {
        tipoTexto = _idTexto;
        actualizarTexto();
    }


    public void setTextoLiteral(string mensaje)
    {

        if (texto == null)
        {
            texto = GetComponent<Text>();
        }

        tipoTexto = mensaje;

        actualizarTexto();
    }
}


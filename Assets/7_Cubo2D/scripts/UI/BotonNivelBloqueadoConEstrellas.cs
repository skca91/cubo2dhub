using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Se recomienda implementar IBotonNivelBloqueadoConEstrellas
/// </summary>
[RequireComponent(typeof(Button))]
public class BotonNivelBloqueadoConEstrellas : MonoBehaviour {

    public string Id;
    [SerializeField]
    Text EtiquetaText;
    [SerializeField]
    Image BloqueadoImagen;
    [SerializeField]
    Image[] EstrellaImagen;
    public GameObject Duenio;
    IBotonNivelBloqueadoConEstrellas DuenioInterfaz;
    Button boton;


    // Use this for initialization
	void Start () {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(OnClick);
        DuenioInterfaz = Duenio.GetComponent<IBotonNivelBloqueadoConEstrellas>();
    }
	
    /*
	// Update is called once per frame
	void Update () {
		
	}*/

    public void OnClick(){
        Debug.Log("on click click");
        if(!BloqueadoImagen.gameObject.activeSelf){
            if (DuenioInterfaz != null)
            {
                DuenioInterfaz.OnClickBotonNivelBloqueadoConEstrellas(Id);
            }
            else {
                Duenio.SendMessage("OnClickBotonNivelBloqueadoConEstrellas", Id);
            }
        }
        else{
            Debug.Log("bloqueado " + Id);
        }
           
    }

    public void Bloqueado(string _EstaBloqueado){

        if(_EstaBloqueado.ToLower().Equals("si")){
            BloqueadoImagen?.gameObject.SetActive(true);
        }else{
            BloqueadoImagen?.gameObject.SetActive(false);
        }
    }

    public void Estrellas(int _ContEstrellas){
        int cont = 0;
        foreach(Image i in EstrellaImagen){
            if(cont < _ContEstrellas){
                i.gameObject.SetActive(true);
            }else{
                i.gameObject.SetActive(false);
            }
        }
    }

    public void CambiarColorEstrellas(Color _NuevoColor)
    {
        foreach (Image i in EstrellaImagen)
        {
            i.color = _NuevoColor;
        }
    }
    /// <summary>
    /// Texto que se muestra en el boton
    /// </summary>
    public string Etiqueta{
        set { EtiquetaText.text = value; }
    }
}

public interface IBotonNivelBloqueadoConEstrellas {
    void OnClickBotonNivelBloqueadoConEstrellas(string Id);
}

public class NivelBloqueadoEstrellas{

    public string Bloqueado = "si";
    public int Estrellas = 0;

    public NivelBloqueadoEstrellas(){

    }

    public string ToStringDatos(){
        return Bloqueado+","+Estrellas.ToString();
    }

    public void FromStringDatos(string _Datos){
        string[] _datosSplit = _Datos.Split(',');
        Bloqueado = _datosSplit[0];
        Estrellas = 0;
        int.TryParse(_datosSplit[1],out Estrellas);
    }
}
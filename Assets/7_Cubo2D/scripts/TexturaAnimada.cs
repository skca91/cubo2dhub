using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TexturaAnimada : MonoBehaviour {

    public enum ModoAnimacionTextura {
        Avanza,
        Regresa,
        PingPing
    }

    public ModoAnimacionTextura animacion = ModoAnimacionTextura.Avanza;
    public bool Repetir = false;
    /** 0.05 = 20 fotogramas por segundo*/
    public float frecuenciaFotograma = 0.05f;

    public Texture[] Texturas;
    MeshRenderer mr;
    int cont = 0;
    // Use this for initialization
    void Start () {
        mr = GetComponent<MeshRenderer>();
        Reiniciar();
        InvokeRepeating("animar", 0, frecuenciaFotograma);
       
    }
	
	// Update is called once per frame
	void Update () {

	}

    void animar(){

        switch (animacion)
        {
            case ModoAnimacionTextura.Avanza:
                if (Texturas.Length > 0 && cont < Texturas.Length)
                {
                    mr.material.SetTexture("_MainTex", Texturas[cont]);
                    cont++;
                }
                else
                {
                    if(Repetir){
                        Reiniciar();
                    }
                    else
                    {
                        CancelInvoke("animar");
                    }

                }
                break;
            case ModoAnimacionTextura.Regresa:
                if (Texturas.Length > 0 && cont > -1)
                {
                    Debug.Log(cont);
                    mr.material.SetTexture("_MainTex", Texturas[cont]);
                    cont--;
                }
                else
                {
                    if (Repetir)
                    {
                        Reiniciar();
                    }else{
                        CancelInvoke("animar");
                    }

                }
                break;
        }


    }

    public void Reiniciar(){
        switch(animacion){
            case ModoAnimacionTextura.Avanza:
                cont = 0;
                break;
            case ModoAnimacionTextura.Regresa:
                cont = Texturas.Length-1;
                break;
            case ModoAnimacionTextura.PingPing:
                cont = 0;
                break;
        }
    }
}

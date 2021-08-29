using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cambia el punto de vista y el angulo de la camara para pantallas con caracteristicas especiales mas de 1.8
/// Solo funciona en portrait
/// </summary>
[RequireComponent(typeof(Camera))]
public class AjustarCamaraPorProporcionDePantalla : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Vector3 DistanciaDeCamara = new Vector3(0, 0, -35);
    [SerializeField]
    Vector3 DistanciaDeCamaraBase = new Vector3(0, 0, -25);
    Camera camera;

    void Start()
    {
        InvokeRepeating("AjustarCamaraPorProporcionDePantallaEnTiempoReal",1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjustarCamaraPorProporcionDePantallaEnTiempoReal() {
        if (Screen.height > Screen.width * 1.8f)
        {
            this.transform.position = DistanciaDeCamara;
        }
        else
        {
            this.transform.position = DistanciaDeCamaraBase;
        }
    }
}

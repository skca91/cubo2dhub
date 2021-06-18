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
    
    Camera camera;

    void Start()
    {
        if(Screen.height > Screen.width* 1.8f) {
            this.transform.position = new Vector3(0,0,-35);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

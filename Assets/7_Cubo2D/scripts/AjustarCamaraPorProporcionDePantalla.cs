using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarCamaraPorProporcionDePantalla : MonoBehaviour
{
    // Start is called before the first frame update
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

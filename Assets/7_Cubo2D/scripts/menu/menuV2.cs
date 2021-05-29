using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]

public class menuV2 : MonoBehaviour, IMenuControlador, IMenuRespuesta
{
    bool Open = false;
    [SerializeField]
    bool noMoverAlInicio;
    [SerializeField]
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        var rect = GetComponent<RectTransform>();
        if (noMoverAlInicio)
        {

        }
        else
        {
            rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
        }
        if(!isOpen)
            this.gameObject.SetActive(false);


        actualizarTexto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actualizarTexto()
    {

        foreach (textoIdiomaV2 t in GetComponentsInChildren<textoIdiomaV2>())
        {
            t.actualizarTexto();
        }
    }

    public void hideMenu() {
        this.gameObject.SetActive(false);
    }

    [Obsolete("showMenu no se recomienda con menuV2 use set active directamente en el gameobject")]
    public void showMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void show()
    {
        throw new System.NotImplementedException();
    }

    public void hide()
    {
        throw new System.NotImplementedException();
    }
}

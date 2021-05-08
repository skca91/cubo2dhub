using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]

public class menuV2 : MonoBehaviour
{
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
}

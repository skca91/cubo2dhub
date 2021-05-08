using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaraPersonalizadaCubo2d : MonoBehaviour
{
    [SerializeField]
    public float TargetFPS = 30;
    [SerializeField]
    private Camera cam;
    private float DelayRender;
    void Start()
    {
        if(cam == null)
        cam = GetComponent<Camera>();
       
        StartCoroutine(DelayedRendering());

    }

    public void Update()
    {
        DelayRender = 1 / TargetFPS;
    }

    public IEnumerator DelayedRendering()
    {
        while (true)
        {
            cam.Render();
            yield return new WaitForSeconds(DelayRender);
        }
    }



    /*void Render()
    {
        cam.enabled = true;
    }
    void OnPostRender()
    {
        cam.enabled = false;
    }*/

}

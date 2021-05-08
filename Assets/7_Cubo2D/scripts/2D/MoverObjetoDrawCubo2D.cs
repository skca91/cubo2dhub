using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetoDrawCubo2D : MonoBehaviour {

    public enum EjeMovimiento { 
        x
    }
    [SerializeField]
    EjeMovimiento Eje = EjeMovimiento.x;
    [SerializeField]
    GameObject ObjetivoGameObjet;
    [SerializeField]
    Vector2 LimitesMovimientoPosicionMinima;
    [SerializeField]
    Vector2 LimitesMovimientoPosicionMaxima;
    [SerializeField]
    float Velocidad = 1.0f;
    float Movimiento = 0;

    Vector3 PosicionInicial;
    Vector3 PosicionActual;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        PosicionInicial = Input.mousePosition;
    }

    public void OnMouseDrag()
    {
        Debug.Log("draw!!!");
        if (EjeMovimiento.x.Equals(Eje)) {
            PosicionActual = Input.mousePosition;
            Movimiento = PosicionInicial.x - PosicionActual.x;
            Debug.Log("Movimiento :"+ Movimiento);
            ObjetivoGameObjet.transform.Translate(Movimiento,0,0);
            //ObjetivoGameObjet.transform.position = new Vector3(Mathf.Lerp(ObjetivoGameObjet.transform.position.x,LimitesMovimientoPosicionMinima.x,LimitesMovimientoPosicionMaxima.x), ObjetivoGameObjet.transform.position.y, ObjetivoGameObjet.transform.position.z);
            PosicionInicial = PosicionActual;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimientoGiroscopioAcelerometro : MonoBehaviour {

    [SerializeField]
    Vector3 RangoLibertad = new Vector3(0,0,0);
    [SerializeField]
    float Velocidad = 1f;
    [SerializeField]
    float Sensibilidad = 0.1f;
    Quaternion RotacionInicial;
    Vector3 MovimientoExtra = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
        Quaternion q = GetComponent<Transform>().transform.rotation;
        RotacionInicial = new Quaternion(q.x,q.y,q.z,q.w);

    }
	
	// Update is called once per frame
	void Update () {

       

		if(Mathf.Abs(Input.acceleration.y) > Sensibilidad ) {
            MovimientoExtra.x += Velocidad* Time.deltaTime * Input.acceleration.y;
            MovimientoExtra.x = Mathf.Clamp(MovimientoExtra.x, RangoLibertad.x * -1, RangoLibertad.x);
            MovimientoExtra.z = Mathf.Clamp(MovimientoExtra.z,RangoLibertad.z * -1, RangoLibertad.z);

            //Debug.Log("MovimientoExtra x" + MovimientoExtra.x );
            transform.rotation = Quaternion.Euler(RotacionInicial.eulerAngles + MovimientoExtra);
        }

        if (Mathf.Abs(Input.acceleration.x) > Sensibilidad )
        {
            MovimientoExtra.y += Velocidad * Time.deltaTime * Input.acceleration.x;
            MovimientoExtra.y = Mathf.Clamp(MovimientoExtra.y,RangoLibertad.y * -1, RangoLibertad.x);
            MovimientoExtra.z = Mathf.Clamp(MovimientoExtra.z,RangoLibertad.z * -1, RangoLibertad.z);
            transform.rotation = Quaternion.Euler(RotacionInicial.eulerAngles + MovimientoExtra);
        }


       // SendMessage("SetDebugText", ("acelerometro " + Input.acceleration.ToString() + " MovimientoExtra: " + MovimientoExtra.ToString() + " rotacion inicial  " + RotacionInicial));


        //transform.
        /* if (Mathf.Abs(Input.acceleration.x) > Sensibilidad)
         {
             transform.Rotate(Velocidad * Time.deltaTime * Input.acceleration.x, 0, 0);
         }*/

        // transform.rotation = new Quaternion ().ToEulerAngles(Mathf.Lerp(0, RangoLibertad.x, transform.rotation.x), Mathf.Lerp(0, RangoLibertad.x, transform.rotation.x), Mathf.Lerp(0, RangoLibertad.x, transform.rotation.x));
    }
}

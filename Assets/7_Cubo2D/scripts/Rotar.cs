using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour {

    public float xRotation = 0F;
    public float yRotation = 0F;
    public float zRotation = 0F;
    void OnEnable()
    {
        InvokeRepeating("rotate", 0f, 0.0167f);
        //invo
    }

    /*void OnDisable()
    {
        CancelInvoke();
    }*/

    public void OnRotar()
    {
        InvokeRepeating("rotate", 0f, 0.0167f);
    }
    public void OffRotar()
    {
        CancelInvoke();
    }
    void rotate()
    {
        this.transform.localEulerAngles += new Vector3(xRotation, yRotation, zRotation);
    }
}

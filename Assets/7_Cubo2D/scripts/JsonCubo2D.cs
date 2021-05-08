using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonCubo2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static string ToJsonPrettyLog(string _json) {
        string[] datos = _json.Split(',');
        string salida ="";
        string tabulaciones = "";
        int contTab = 0;

        foreach (string dato in datos) {
            if (dato.Contains("{")) {
                contTab++;
            }
            tabulaciones = "";
            for (int i = 0; i < contTab; i++)
                tabulaciones += "\t";

            salida += tabulaciones + dato + "\n";
            if (dato.Contains("}"))
            {
                contTab--;
            }
        }
        return salida;
    }
}

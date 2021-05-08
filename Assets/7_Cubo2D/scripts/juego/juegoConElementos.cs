using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juegoConElementos : MonoBehaviour {

    public Elemento[] ReglasElementos;

    /// <summary>
    /// Nombres de elemento ganador.
    /// </summary>
    /// <returns>El ganador.</returns>
    /// <param name="NombreElementoA">Nombre elemento A no toma en cuenta mayusculas ni minusculas.</param>
    /// <param name="NombreElementoB">Nombre elemento B no toma en cuenta mayusculas ni minusculas.</param>

    public string NombreGanador(string NombreElementoA, string NombreElementoB) {

        string NombreElementoAUpper = NombreElementoA.ToUpperInvariant();
        string NombreElementoBUpper = NombreElementoB.ToUpperInvariant();

        foreach (Elemento ElementoActual in ReglasElementos)
        {

           // Debug.Log("reglas: " + ElementoActual.NombreElemento);
            if (ElementoActual.NombreElemento.ToUpperInvariant().Equals(NombreElementoAUpper))
            {
              //  Debug.Log("Equals: " + NombreElementoA);
                foreach (string ElementoVencido in ElementoActual.VenceNombreElemento)
                {
                 //   Debug.Log("ventaja: " + ElementoVencido);
                    if (ElementoVencido.ToUpperInvariant().Equals(NombreElementoBUpper)) {
                //        Debug.Log("vence a: " + NombreElementoB);
                        return NombreElementoA;
                    }
                }
            }

            if (ElementoActual.NombreElemento.ToUpperInvariant().Equals(NombreElementoBUpper))
            {
              //  Debug.Log("Equals: " + NombreElementoB);
                foreach (string ElementoVencido in ElementoActual.VenceNombreElemento)
                {
                 //   Debug.Log("ventaja: " + ElementoVencido);
                    if (ElementoVencido.ToUpperInvariant().Equals(NombreElementoAUpper))
                    {
                  //      Debug.Log("vence a: " + NombreElementoA);
                        return NombreElementoB;
                    }
                }
            }
        }

        return "";
    }

    public bool GanaElementoA(string NombreElementoA, string NombreElementoB) {

        if (NombreElementoA.Equals(NombreGanador(NombreElementoA, NombreElementoB)))
            return true;

        return false;
    }

    public bool GanaElementoB(string NombreElementoA, string NombreElementoB)
    {

        if (NombreElementoB.Equals(NombreGanador(NombreElementoA, NombreElementoB)))
            return true;

        return false;
    }

    /// <summary>
    /// Ventajas a como un numero 1 cuando gana y -1 cuando pierde y 0 si son neutrales.
    /// </summary>
    /// <returns> 0 si es empate, 1 si gana a y -1 si perde a.</returns>
    /// <param name="NombreElementoA">Nombre elemento a.</param>
    /// <param name="NombreElementoB">Nombre elemento b.</param>

    public int VentajaA(string NombreElementoA, string NombreElementoB) {

        if (NombreGanador(NombreElementoA, NombreElementoB).Equals(NombreElementoA))
        {
            Debug.Log(NombreElementoA +" Vence A "+ NombreElementoB);
            return 1;
        }
        else if(NombreGanador(NombreElementoA, NombreElementoB).Equals(NombreElementoB))
        {
            Debug.Log(NombreElementoB + " Vence A " + NombreElementoA);
            return -1;
        }
        Debug.Log(NombreElementoA + " Neutral " + NombreElementoB);
        return 0;
    }
}

[System.Serializable]
public class Elemento {
    public string NombreElemento;
    public Sprite IconoElemento;
    public string[] VenceNombreElemento;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CloudBuildAndroid : MonoBehaviour
{
    /// <summary>
    /// Puede variar dependiendo de la version de udp
    /// </summary>
    public static readonly string rutaBillingModeJson = @"Assets/Resources/BillingMode.json";

    private static CloudBuildAndroid cloudBuildInstance;

    public enum Cubo2dBillingMode
    {
        UDP,
        GooglePlay,
        SamsungApps,
        AmazonAppStore
    }

    public static CloudBuildAndroid GetInstance()
    {
        if (cloudBuildInstance == null)
        {
            cloudBuildInstance = new CloudBuildAndroid();
        }
        return cloudBuildInstance;
    }

    /// <summary>
    /// El BillingMode del Editor debe estar en modo UDP para que se aplique la configuracion.
    /// </summary>
    public void SetBillingMode(Cubo2dBillingMode BillingMode, string ruta)
    {

        Debug.Log("SetBillingMode: " + BillingMode.ToString());
        Debug.Log("rutaBillingModeJson: " + ruta.ToString());

        string json = File.ReadAllText(ruta);

        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("No se el json de billing en: " + ruta.ToString());
            return;
        }

        switch (BillingMode)
        {
            case Cubo2dBillingMode.GooglePlay:
                json = json.Replace("UDP", "GooglePlay");
                break;
            case Cubo2dBillingMode.SamsungApps:
                json = json.Replace("UDP", "SamsungApps");
                break;
            case Cubo2dBillingMode.AmazonAppStore:
                json = json.Replace("UDP", "AmazonAppStore");
                break;
            case Cubo2dBillingMode.UDP:
                break;
            default:
                break;
        }


        File.WriteAllText(ruta, json);

        Debug.Log("Prebuild end ok");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEditor;

public class CloudBuildAndroidEditor : MonoBehaviour
{

#if UNITY_CLOUD_BUILD
    public static void PreExportGooglePlay() {
        var BillingMode = CloudBuildAndroid.Cubo2dBillingMode.GooglePlay;
        var ruta = CloudBuildAndroid.rutaBillingModeJson;
        CloudBuildAndroid.GetInstance().SetBillingMode(BillingMode, ruta);
    }

    public static void PreExportSamsung() {
        var BillingMode = CloudBuildAndroid.Cubo2dBillingMode.SamsungApps;
        var ruta = CloudBuildAndroid.rutaBillingModeJson;
        CloudBuildAndroid.GetInstance().SetBillingMode(BillingMode, ruta);
    }

    public static void PreExportAmazon() {
        var BillingMode = CloudBuildAndroid.Cubo2dBillingMode.AmazonAppStore;
        var ruta = CloudBuildAndroid.rutaBillingModeJson;
        CloudBuildAndroid.GetInstance().SetBillingMode(BillingMode, ruta);
    }
#endif

}

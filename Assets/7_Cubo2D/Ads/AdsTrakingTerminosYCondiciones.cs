using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

[RequireComponent(typeof(UnityChartbootsAdsCubo2d2019))]
public class AdsTrakingTerminosYCondiciones : MonoBehaviour
{
    GameObject MenuActivarTraking;
    GameObject MenuTrakingAnonimo;
    // Start is called before the first frame update
    void Start()
    {
        MetaData gdprMetaData = new MetaData("gdpr");
        gdprMetaData.Set("consent", "true");
        Advertisement.SetMetaData(gdprMetaData);

        MetaData privacyMetaData = new MetaData("privacy");
        privacyMetaData.Set("consent", "true");
        Advertisement.SetMetaData(privacyMetaData);

        MetaData ageGateMetaData = new MetaData("privacy");
        ageGateMetaData.Set("useroveragelimit", "true");
        Advertisement.SetMetaData(ageGateMetaData);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Solo para california
    /// </summary>
    public void OnClickAceptarGDPR() {
        MetaData privacyMetaData = new MetaData("gdpr");
        privacyMetaData.Set("consent", "true");
        Advertisement.SetMetaData(privacyMetaData);
    }

    public void OnClickAceptarPrivacity()
    {
        MetaData privacyMetaData = new MetaData("privacy");
        privacyMetaData.Set("consent", "true");
        Advertisement.SetMetaData(privacyMetaData);
    }

    public void OnClickAceptarCCPA()
    {

        MetaData ageGateMetaData = new MetaData("privacy");
        ageGateMetaData.Set("useroveragelimit", "true");
        Advertisement.SetMetaData(ageGateMetaData);
    }
}

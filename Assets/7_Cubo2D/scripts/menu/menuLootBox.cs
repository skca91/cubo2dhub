using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IMenuControlador))]
public class menuLootBox : MonoBehaviour
{
    IMenuControlador menu;
    [SerializeField]
    GameObject LootBoxClosed;
    [SerializeField]
    GameObject Rewar;
    [SerializeField]
    Button OpenBoxButton;
    [SerializeField]
    Button GetRewarButton;
    [SerializeField]
    GameObject BuyPanel;
    [SerializeField]
    Text CoinsText;
    [SerializeField]
    Text BoxContText;
    [SerializeField]
    GameObject PuntoDeMontajeGO;

    int ContBoxes;
    int ContCoins;
    bool CanShowBuyPanel;
    bool CanSeeRewar;

    public int Boxes {
        set
        {
            ContBoxes = value;
            if (BoxContText != null)
                BoxContText.text = ContBoxes.ToString();
        }
        get
        {
            return ContBoxes;
        }
    }

    public int Coins {
        set
        {
            ContCoins = value;
            if (CoinsText != null)
                CoinsText.text = ContCoins.ToString();
        }
        get
        {
            return ContCoins;
        }
    }

    public bool ShowBuyPanel{
        set {
            CanShowBuyPanel = value;
            if (BuyPanel != null) {
                BuyPanel.SetActive(value);
            }
        }

        get { return CanShowBuyPanel; }
    }
    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<IMenuControlador>();
        Init();
    }

    public void Init() {
        LootBoxClosed.SetActive(false);
        Rewar.SetActive(false);
        GetRewarButton.gameObject.SetActive(false);
        OpenBoxButton.gameObject.SetActive(false);
        CanSeeRewar = false;
    }

    public void ShowLootBoxClose()
    {
        if (!CanSeeRewar) {

            LootBoxClosed.SetActive(true);
            Rewar.SetActive(false);
            GetRewarButton.gameObject.SetActive(false);
            OpenBoxButton.gameObject.SetActive(true);
        }
    }

    public void ShowRewar(string Id) {
        LootBoxClosed.SetActive(false);
        Rewar.SetActive(true);
        var PuntoDeMontaje = PuntoDeMontajeGO.GetComponentInChildren<IPuntoDeMontaje>();
        PuntoDeMontaje.montar(Id);
        GetRewarButton.gameObject.SetActive(true);
        OpenBoxButton.gameObject.SetActive(false);
        CanSeeRewar = true;
    }

    public void OnClickClaimRewar()
    {
        CanSeeRewar = false;
        if (ContBoxes > 0)
        {

            ShowLootBoxClose();
        }
        else {
            Init();
            LootBoxClosed.SetActive(false);
        }

    }


}

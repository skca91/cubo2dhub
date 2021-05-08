using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenuOnBackButton : MonoBehaviour
{
   
    [SerializeField]
    menu BackMenu;
    [SerializeField]
    GameObject BackMenuV2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (BackMenuV2 != null)
                BackMenuV2.SetActive(true);
            if(BackMenu!=null)
                BackMenu.showMenu();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    //Ammo Variables
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private GameObject gun;

    private int fullAmmo;
    private int ammo;

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
    }

    void DisplayAmmo()
    {
        fullAmmo = gun.GetComponent<Gun>().maxAmmo;
        ammo = gun.GetComponent<Gun>().currentAmmo;
        ammoText.text = "AMMO: " + ammo + " / " + fullAmmo;
    }


}

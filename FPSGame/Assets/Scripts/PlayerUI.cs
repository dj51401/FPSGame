using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    //Health
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    //Ammo Variables
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private GameObject gun;

    private int fullAmmo;
    private int ammo;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void DisplayAmmo()
    {
        /*
        fullAmmo = gun.GetComponent<Gun>().maxAmmo;
        ammo = gun.GetComponent<Gun>().currentAmmo;
        ammoText.text = "AMMO: " + ammo + " / " + fullAmmo;
        */
    }


}

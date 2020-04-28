using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject zombie1;
    public GameObject zombie2;
    // Start is called before the first frame update
    void Start()
    {
        zombie1.SetActive(false);
        zombie2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy1()
    {
        zombie1.SetActive(true);
    }
}

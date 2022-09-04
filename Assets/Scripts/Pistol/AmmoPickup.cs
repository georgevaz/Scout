using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject ammoDisplayBox;
    void OnTriggerEnter()
    {
        ammoDisplayBox.SetActive(true);
        GlobalAmmo.ammoCount += 7;
        gameObject.SetActive(false);
    }
}

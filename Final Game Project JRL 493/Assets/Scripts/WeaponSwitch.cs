using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject pan;
    public GameObject onion;

    void Start()
    {
        onion.SetActive(false);
        pan.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pan.SetActive(true);
            onion.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pan.SetActive(false);
            onion.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenadethrow : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject prefab;
    public Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(prefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}

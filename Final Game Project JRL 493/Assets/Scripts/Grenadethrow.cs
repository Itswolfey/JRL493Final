using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenadethrow : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject prefab;
    public Transform shootPoint;
    public float waitToThrow = 5f;
    public bool hasThrown;
    public bool canThrow;
    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canThrow)
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(prefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

        StartCoroutine(WaitToThrow());
    }

    IEnumerator WaitToThrow()
    {

        canThrow = false;
        yield return new WaitForSeconds(waitToThrow);
        canThrow = true;
    }
}

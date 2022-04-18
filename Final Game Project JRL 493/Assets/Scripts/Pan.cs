using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public CapsuleCollider panHit;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Swing");
            //aSource.PlayOneShot(panHitSound);
        }
    }

    public void DisablePan()
    {
        panHit.enabled = false;
    }

    public void EnablePan()
    {
        panHit.enabled = true;
    }
    
}

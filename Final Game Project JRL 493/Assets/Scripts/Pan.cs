using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public CapsuleCollider panHit;
    public bool canSwing;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        canSwing = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSwing)
        {
            anim.SetTrigger("Swing");
            canSwing = false;
            StartCoroutine(PanCoolDown());
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
    
    IEnumerator PanCoolDown()
    {
        yield return new WaitForSeconds(1);
        canSwing = true;
    }
}

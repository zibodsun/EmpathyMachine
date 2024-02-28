using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/*
 *  Attach to the toy gun object for the wondrous event. While holding the gun, the player can shoot with the trigger. Bullets that hit the slimes will kill them.
 */
public class FireGun : GenericWondrousObject
{
    public GameObject bullet;
    public Transform muzzle;
    public float bulletSpeed = 10f;
    public GameObject wondrousEvent;

    // for recoil animation
    Animator anim;
    Rigidbody rb;

    XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(Shoot);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        // Debug shoot
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Shoot();
        }
    }

    // Shoot event that creates a bullet and destroys it after 5 seconds
    public void Shoot(ActivateEventArgs args) {

        // disable shooting if the event finished
        if (!wondrousEvent.activeSelf)
        {
            grabInteractable.activated.RemoveListener(Shoot);
        }

        StartCoroutine(Recoil());
        GameObject b = Instantiate(bullet, muzzle.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        Destroy(b, 5);
    }

    // Debug Function called with keyboard press
    public void Shoot()
    {
        StartCoroutine(Recoil());
        GameObject b = Instantiate(bullet, muzzle.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        Destroy(b, 5);
    }

    // Physics of this implementation don't work with XR Grab
    IEnumerator Recoil() {
        anim.Play("Recoil");
        rb.AddForce(transform.right * -80, ForceMode.Force);
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
    }
}

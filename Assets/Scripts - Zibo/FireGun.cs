using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireGun : GenericWondrousObject
{
    public GameObject bullet;
    public Transform muzzle;
    public float bulletSpeed = 10f;
    public GameObject wondrousEvent;

    XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(Shoot);
    }

    // Update is called once per frame
    void Update()
    {
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

        GameObject b = Instantiate(bullet, muzzle.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        Destroy(b, 5);
    }

    // Debug Function called with keyboard press
    public void Shoot()
    {
        GameObject b = Instantiate(bullet, muzzle.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        Destroy(b, 5);
    }
}

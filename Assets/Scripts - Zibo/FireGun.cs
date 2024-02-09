using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;
using static UnityEngine.GraphicsBuffer;

/*
 *  Slimes are a part of the toy gun event. They will smoothly follow the player with their rotation. 
 *  They can get hit by objects tagged "Bullet" which will kill them.
 */
public class Slime : MonoBehaviour
{
    public Transform targetObj;
    public float rotationSpeed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (targetObj == null) {
            var mainCamera = Camera.main;
            if (mainCamera != null)
                targetObj = mainCamera.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var targetRotation = Quaternion.LookRotation(targetObj.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") {
            anim.SetTrigger("Hit");
            Destroy(other.gameObject);
        }
    }
}

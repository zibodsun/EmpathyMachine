using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;
using static UnityEngine.GraphicsBuffer;

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
            other.transform.SetParent(transform);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingApple : MonoBehaviour
{
    public Material material;
    public float size;
    public Vector3 floatDirection;
    public Vector3 torqueDirection;
    public float waitTimer;
    private float time;

    private Rigidbody rb;
    private float scaleIncrement = 0.1f;
    public Transform apparitionEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = material;
        transform.localScale = new Vector3(size, size, size);
        rb.AddForce(floatDirection, ForceMode.Impulse);
        rb.AddTorque(torqueDirection);
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < waitTimer)
        {
            time += Time.deltaTime;
            return;
        }

        if (transform.localScale.x < size) {
            transform.localScale += new Vector3(scaleIncrement * size, scaleIncrement * size, scaleIncrement * size);
        }
    }
    // Play effect when destroyed
    public void OnDestroy()
    {
        if (apparitionEffect != null) {
            apparitionEffect.transform.position = transform.position;
            apparitionEffect.gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  The broom script can be attached to play the animation to transform it into a sword
 */
public class Broom : GenericWondrousObject
{
    public GameObject wondrousEvent;
    public bool isSword;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSword && !wondrousEvent.activeSelf)
        {
            anim.Play("TransformToBroom");
            isSword = false;
        }
    }
}

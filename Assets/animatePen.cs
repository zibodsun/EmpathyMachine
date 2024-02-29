using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class animatePen : MonoBehaviour
{
    public float jumpPower;
    public float jumpTime;
    Tween tween;

    private void Start()
    {
        tween = transform.DOJump(transform.position, jumpPower, 1, jumpTime);
    }

    private void Update()
    {
        // Debug.Log(!tween.IsPlaying());

        if (!tween.IsPlaying())
        {
            tween = transform.DOJump(transform.position, jumpPower, 1, jumpTime);
        }
    }
}

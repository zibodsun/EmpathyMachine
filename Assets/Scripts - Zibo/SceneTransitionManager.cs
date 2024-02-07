using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class SceneTransitionManager : MonoBehaviour
{

    public float _timer;
    private float _timeElapsed;
    public Animator anim;
    public float timeToWaitBeforeEnd = 1f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (_timeElapsed < _timer)
        {
            _timeElapsed += Time.deltaTime;
        }
        else {
            anim.Play("FadeOutToBlack");
        } */
    }
    public void LoadNewScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

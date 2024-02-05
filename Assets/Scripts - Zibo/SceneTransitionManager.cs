using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class SceneTransitionManager : MonoBehaviour
{

    public float _timer;
    private float _timeElapsed;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_timeElapsed < _timer)
        {
            _timeElapsed += Time.deltaTime;
        }
        else {
            SwapScene();
        }
    }

    public void SwapScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

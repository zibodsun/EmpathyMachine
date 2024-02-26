using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Controls the sword (apple slicing) event. The apples are placed in world space and are stored in this class.
 */
public class SpawnApplesSwordEvent : MonoBehaviour
{
    public FloatingApple[] apples;
    public WondrousEventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        apples = FindObjectsOfType<FloatingApple>(true);
        foreach (FloatingApple apple in apples)
        {
            apple.gameObject.SetActive(true);
        }
        StartCoroutine(StopEvent());
    }

    IEnumerator StopEvent()
    {
        yield return new WaitForSeconds(eventManager.swordEventDuration);

        apples = FindObjectsOfType<FloatingApple>(true);    // refresh the current apples that are still whole
        GameObject[] slicedApples = GameObject.FindGameObjectsWithTag("SlicedApple");

        // destroy all floating apples and slices 

        foreach (FloatingApple apple in apples)
        {
            Destroy(apple.gameObject);
        }
        foreach (GameObject apple in slicedApples)
        {
            Destroy(apple);
        }
    }
}

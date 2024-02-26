using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;

/*
 *  Manager of the dream sequence. Responsible for switching the state of the sequence and the timing of the events in the dream scene.
 */
public class NarratorAudioControl : MonoBehaviour
{
    public List<GameObject> audioLines = new();     // an ordered sequence of audio sources
    public Runner hare, turtle;

    public SceneTransitionManager sceneTransitionManager;
    int nextLine = 0;
    bool audioIsPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        if(sceneTransitionManager != null)
        {
            sceneTransitionManager = FindAnyObjectByType<SceneTransitionManager>();
        }

        StartCoroutine(DelayedStart());
    }

    // Plays a narration line after pausing currently playing ones
    public void Play(int index, float delay)
    {
        for (int i = 0; i < audioLines.Count; i++)
        {
            if (index == i)
            {
                audioLines[index].SetActive(true);
                audioIsPlaying = true;
                StartCoroutine(WaitUntilFinished(audioLines[index].GetComponent<AudioSource>().clip.length, delay));
                nextLine++;
            }
            else
            {
                audioLines[i].SetActive(false);
            }
        }
    }
    IEnumerator DelayedStart() {
        yield return new WaitForSeconds(1.5f);
        Play(nextLine, 0f);
    }
    IEnumerator WaitUntilFinished(float clipLength, float delay) {
        yield return new WaitForSeconds(clipLength + delay);
        audioIsPlaying = false;
        SwitchState();
    }

    void SwitchState() {

        switch (nextLine)
        {                                   // "A Hare was making fun of the Tortoise one day for being so slow."
            case 1:                         // "Do you ever get anywhere?"
            case 2:                         // "Yes, and I get there sooner than you think. I'll run you a race and prove it."
                if (!audioIsPlaying)
                {
                    Play(nextLine, .3f);
                }
                break;
            case 3:                         // "The Hare was much amused at the idea of running a race with the Tortoise, but for
                if (!audioIsPlaying)        // the fun of the thing he agreed. So, the runners met at the starting line and started the race."
                {
                    Play(nextLine, 7f);
                }
                // Both start running
                hare.anim.SetTrigger("BeginRun");
                turtle.anim.SetTrigger("BeginRun");
                break;

            case 4:                         // "The Hare was soon far out of sight, and to make the Tortoise feel very deeply how ridiculous  
                if (!audioIsPlaying)        // it was for him to try a race with a Hare, he lay down beside the course to take a nap until the
                {                           // Tortoise should catch up. The Tortoise meanwhile kept going slowly but steadily, and, after
                    Play(nextLine, 8f);     // a time, passed the place where the Hare was sleeping."
                }
                // Hare stops and takes a nap
                hare.anim.SetTrigger("Nap");
                turtle.anim.SetTrigger("Accelerate");
                break;

            case 5:                         // "But the Hare slept on very peacefully; and when at last he did wake up, the Tortoise was near      
                if (!audioIsPlaying)        //  the goal. The Hare now ran his swiftest, but he could not overtake the Tortoise in time."
                {                           
                    Play(nextLine, 5f);    
                }
                hare.anim.SetTrigger("BeginRun");
                StartCoroutine(WaitThenEndScene());
                break;
        }
    }

    IEnumerator WaitThenEndScene() {
        yield return new WaitForSeconds(sceneTransitionManager.timeToWaitBeforeEnd);
        sceneTransitionManager.anim.Play("FadeOutToBlack");
    }
}

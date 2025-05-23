using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    [SerializeField] ParticleSystem celebration;
    bool hasChildren = true;
    bool hasPlayed = false;

    void Update()
    {
        if (!hasPlayed && transform.childCount == 0)
        {
            hasChildren = false;
            hasPlayed = true;
            celebration.Play();
            StartCoroutine(StopCelebrationAfterDuration());
        }
    }

    IEnumerator StopCelebrationAfterDuration()
    {
        float duration = celebration.main.duration;
        yield return new WaitForSeconds(duration);
        celebration.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

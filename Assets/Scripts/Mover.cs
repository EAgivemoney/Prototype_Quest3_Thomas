using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject bulletTimeOverlay;

    void Start()
    {
        if (bulletTimeOverlay != null)
            bulletTimeOverlay.SetActive(false);
    }

    void Update()
    {
        MoveHero();
    }

    private void MoveHero()
    {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float yValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue, 0, yValue);
    }

    public IEnumerator SlowDownTime()
    {
        if (bulletTimeOverlay != null)
            bulletTimeOverlay.SetActive(true);

        Time.timeScale = 0.5f;
        print("Time slowed down!");
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        print("Time back to normal!");

        if (bulletTimeOverlay != null)
            bulletTimeOverlay.SetActive(false);
    }
}

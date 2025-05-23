using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        print("Aww, you got me");
        if (other.CompareTag("Player"))
        {
            Mover mover = other.GetComponent<Mover>();
            if (mover != null)
            {
                StartCoroutine(mover.SlowDownTime());
            }
        }

        foreach (var renderer in GetComponentsInChildren<Renderer>())
            renderer.enabled = false;

        foreach (var collider in GetComponentsInChildren<Collider>())
            collider.enabled = false;

        if (explosionEffect != null)
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
        StartCoroutine(DestroyEnemyAfterBulletTime());
    }

    private IEnumerator DestroyEnemyAfterBulletTime()
    {
        yield return new WaitForSeconds(2.1f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    private Vector3 rotationSpeed = new Vector3(30f, 45f, 60f);

    void Update()
    {
        transform.Rotate(2 * Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mover mover = other.GetComponent<Mover>();
            if (mover != null)
            {
                StartCoroutine(BoostSpeed(mover));
            }
        }
    }

    IEnumerator BoostSpeed(Mover mover)
    {
        float originalSpeed = mover.moveSpeed;
        mover.moveSpeed = originalSpeed * 1.5f;
        yield return new WaitForSeconds(3f);
        mover.moveSpeed = originalSpeed;
    }
}

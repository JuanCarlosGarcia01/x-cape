using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource Sound;
    private void OnTriggerEnter(Collider collision)

    {
        if (collision.CompareTag("Player"))
        {

            Sound.Play();
            Destroy(gameObject);

        }
    }
}

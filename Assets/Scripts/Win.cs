using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GrabObject grabObject;

    public string scene;

    private void OnTriggerStay(Collider collision)

    {
        if (collision.CompareTag("Player") && grabObject.score == 10)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(scene);
        }
    }
}
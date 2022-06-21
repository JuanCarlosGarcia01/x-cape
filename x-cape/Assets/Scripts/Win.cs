using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GrabObjects grabObject;
    public string scene;

    private void OnTriggerEnter(Collider collision)

    {
        if (collision.CompareTag("Player") && grabObject.score == 10)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(scene);
        }
    }
}
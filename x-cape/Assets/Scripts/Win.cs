using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Score score;
    public string scene;

    private void OnTriggerEnter(Collider collision)

    {
        if (collision.CompareTag("Player") && score.score == 10)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(scene);
        }
    }
}
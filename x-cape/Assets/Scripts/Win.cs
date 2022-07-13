using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Score score;
    public string sceneWin;
    public string sceneLose;

    private void OnTriggerEnter(Collider collision)

    {
        if (collision.CompareTag("Player") && score.score >= 7)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(sceneWin);
        }
        else if (collision.CompareTag("Player") && score.score <= 7)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(sceneLose);
        }
    }
}
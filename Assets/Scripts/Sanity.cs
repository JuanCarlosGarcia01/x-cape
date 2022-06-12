using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Sanity : MonoBehaviour
{

    public Text indicator;
    public float sanity;
    public float changePerSecond;

    void FixedUpdate()
    {

        sanity += changePerSecond * Time.deltaTime;
        indicator.text = ((int)sanity).ToString();

        if (sanity <= 1)

        {
            Cursor.lockState = CursorLockMode.None;
            changePerSecond = 0;
            SceneManager.LoadScene("Lose");
        }

    }

}

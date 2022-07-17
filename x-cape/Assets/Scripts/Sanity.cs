using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class Sanity : MonoBehaviour
{
    public Volume volume;
    public Text indicator;
    public float sanity;
    public float changePerSecond;
    public float changePerSecondVignette;
    Vignette vignette;
    void Start()
    {
        if(volume.profile.TryGet<Vignette>(out vignette))
        {

        } 
    }
    void FixedUpdate()
    {
        vignette.intensity.value += changePerSecondVignette * Time.deltaTime; 
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

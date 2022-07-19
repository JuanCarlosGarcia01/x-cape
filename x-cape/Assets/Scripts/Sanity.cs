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
    public AudioSource heartSound;
    public AudioSource demonioSound;
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

        if ((int)sanity == 30)
        {
            latido();
        }

        if ((int)sanity == 10)
        {
            demonio();
        }

        if (sanity <= 1)

        {
            Cursor.lockState = CursorLockMode.None;
            changePerSecond = 0;
            SceneManager.LoadScene("Lose");
        }

    }

    void latido()
    {
            heartSound.Play();
    }

    void demonio()
    {
        demonioSound.Play();
    }

}

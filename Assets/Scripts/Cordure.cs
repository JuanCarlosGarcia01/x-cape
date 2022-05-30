using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Cordure : MonoBehaviour
{

    public Text indicator;

    public float cordure;

    public float changePerSecond;


    void FixedUpdate()
    {

        cordure += changePerSecond * Time.deltaTime;


        indicator.text = ((int)cordure).ToString();

        if (cordure <= 1)

        {
            Cursor.lockState = CursorLockMode.None;
            changePerSecond = 0;
            SceneManager.LoadScene("Lose");
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            indicator.text = "Game Over";
            changePerSecond = 0;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAngle : MonoBehaviour
{
    public Puzzles puzzles;

    private float RotateRate = 1f;

    private float WaitTime = 0;

    private int angle = 0;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (Input.GetKey("e") && Time.time > WaitTime)
            {
                if (angle < 360)
                {

                    angle += 90;

                    gameObject.LeanRotateZ(angle, 1f);

                    WaitTime = Time.time + RotateRate;

                    Invoke("ComprobateCross", 1f);

                }
                else
                {
                    angle = 0;
                }
            }
        }
    }

    public void ComprobateCross()
    {


        puzzles.ComprobateCross();

    }

}

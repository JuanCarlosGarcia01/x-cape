using UnityEngine;

public class CrossAngle : MonoBehaviour
{
    public Puzzles puzzles;

    private float RotateRate = 1f;

    private float WaitTime = 0;

    private int angle = 0;

    public AudioSource CrossSound;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand1"))
        {
            if ((Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) && Time.time > WaitTime)
            {
                if (angle < 360)
                {

                    angle += 90;
                    gameObject.LeanRotateZ(angle, 1f);
                    WaitTime = Time.time + RotateRate;
                    Invoke("ComprobateCross", 1f);
                    CrossSound.Play();
                }
                else
                {
                    angle = 0;
                }
            }
        }
        if (other.gameObject.CompareTag("Hand2"))
        {
            if ((Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch)) && Time.time > WaitTime)
            {
                if (angle < 360)
                {

                    angle += 90;
                    gameObject.LeanRotateZ(angle, 1f);
                    WaitTime = Time.time + RotateRate;
                    Invoke("ComprobateCross", 1f);
                    CrossSound.Play();
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

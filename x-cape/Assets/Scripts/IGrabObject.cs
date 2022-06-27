using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static OVRInput;

public class IGrabObject : MonoBehaviour
{
    public GameObject handPoint;
    public GameObject pickedObject = null;
    public GameObject Battery;
    public Score score;
    public float WaitTime = 0;
    private float TimeRate = 1f;
    public AudioSource SoundPickBattery;
    public AudioSource BibleSound;
    public IGrabObject oppositeHand;
    
    public Hand hand;
    public enum Hand {Right, Left}

    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r") || OVRInput.GetDown(OVRInput.Button.Two, (hand == Hand.Left ? Controller.LTouch : Controller.RTouch)) && Time.time > WaitTime)
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
                WaitTime = Time.time + TimeRate;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        {
            if ((other.gameObject.CompareTag("Object") || other.gameObject.CompareTag("Bible") || other.gameObject.CompareTag("PutBible")) && Time.time > WaitTime)
            {
                if (Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, (hand == Hand.Left ? Controller.LTouch : Controller.RTouch)) && pickedObject == null)
                {
                    if (oppositeHand.pickedObject == other.gameObject)
                        oppositeHand.LetGo();
                        
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.transform.position = handPoint.transform.position;
                    other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                    pickedObject = other.gameObject;
                    WaitTime = Time.time + TimeRate;
                    if (other.gameObject.CompareTag("PutBible"))
                    {

                        BibleSound.Play();
                        Invoke("coldown", 2f);
                    }
                    if (other.gameObject.CompareTag("Object"))
                    {
                        SoundPickBattery.Play();
                    }
                    if (other.gameObject.CompareTag("Bible"))
                    {
                        BibleSound.Play();
                    }
                }
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                if (Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, (hand == Hand.Left ? Controller.LTouch : Controller.RTouch)) && pickedObject == null)
                {
                    score.MoreScore();
                    Destroy(other.gameObject);
                }
            }
        }
    }

    public void LetGo()
    {
        pickedObject = null;
    }

    void coldown()
    {
        pickedObject.gameObject.tag = "Bible";
    }
}

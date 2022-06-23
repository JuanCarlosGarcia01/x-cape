using UnityEngine;
using TMPro;

public class GrabObjectsL : MonoBehaviour
{

    public GameObject handPoint;
    public GameObject pickedObject = null;
    public GameObject Battery;
    public Score score;
    public float WaitTime = 0;
    private float TimeRate = 1f;
    public AudioSource SoundPickBattery;
    public AudioSource BibleSound;

    void Update()
    {



        if (pickedObject != null)
        {
            if (Input.GetKey("r") || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch) && Time.time > WaitTime)
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
                if (Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch) && pickedObject == null)
                {
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
                if (Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch) && pickedObject == null)
                {
                    score.MoreScore();
                    Destroy(other.gameObject);
                }
            }
        }
    }
    void coldown()
    {
        pickedObject.gameObject.tag = "Bible";
    }
}

using UnityEngine;
using TMPro;

public class GrabObjects : MonoBehaviour
{

    public GameObject handPoint;
    public GameObject pickedObject = null;
    public GameObject Battery;
    public int score;
    public TMP_Text TXTScore;
    public float WaitTime = 0;
    private float TimeRate = 1f;
    public AudioSource SoundPickBattery;
    public AudioSource BibleSound;

    void Update()
    {
        TXTScore.text = "Score: " + score;


        if (pickedObject != null)
        {
            if (Input.GetKey("r") && Time.time > WaitTime)
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
            if (other.gameObject.CompareTag("Object") || other.gameObject.CompareTag("Bible") || other.gameObject.CompareTag("PutBible") && Time.time > WaitTime)
            {
                if (Input.GetKey("m") /*|| OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)*/ && pickedObject == null)
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
                        other.tag = "Bible";
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
                if (Input.GetKey("m") && pickedObject == null)
                {
                    Debug.Log("hola");
                    score++;
                    Destroy(other.gameObject);
                }
            }                        
        }
    }
}

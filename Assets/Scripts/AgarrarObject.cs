using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgarrarObject : MonoBehaviour
{

    public GameObject handPoint;

    public GameObject pickedObject = null;

    public GameObject Battery;

    public int score;

    public TMP_Text TXTScore;

    public float WaitTime = 0;

    private float TimeRate = 1f;
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
                if (Input.GetKey("e") && pickedObject == null)
                {
                    other.GetComponent<Rigidbody>().useGravity = false;

                    other.GetComponent<Rigidbody>().isKinematic = true;

                    other.transform.position = handPoint.transform.position;

                    other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                    pickedObject = other.gameObject;

                    WaitTime = Time.time + TimeRate;

                    if (other.gameObject.CompareTag("PutBible"))
                    {
                        other.tag = "Bible";
                    }
                }


            }

            if (other.gameObject.CompareTag("Coin"))
            {
                if (Input.GetKey("e") && pickedObject == null)
                {
                    score++;
                    Destroy(other.gameObject);

                }
            }                        
        }
    }
}

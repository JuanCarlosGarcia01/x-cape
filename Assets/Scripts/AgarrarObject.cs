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

    void Update()
    {
        TXTScore.text = "Score: " + score;


        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        {
            if (other.gameObject.CompareTag("Object"))
            {
                if (Input.GetKey("e") && pickedObject == null)
                {
                    other.GetComponent<Rigidbody>().useGravity = false;

                    other.GetComponent<Rigidbody>().isKinematic = true;

                    other.transform.position = handPoint.transform.position;

                    other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                    pickedObject = other.gameObject;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiblePuzzle : MonoBehaviour
{
    public GameObject WallPoint;

    public AgarrarObject agarrarObject;

    private float TimeRate = 2f;


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Bible") && Time.time > agarrarObject.WaitTime)
        {

            other.transform.position = WallPoint.transform.position;

            other.transform.rotation = WallPoint.transform.rotation;

            agarrarObject.pickedObject = null;

            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.transform.SetParent(null);

            agarrarObject.WaitTime = Time.time + TimeRate;

            other.tag = "PutBible";


        }
    }
}

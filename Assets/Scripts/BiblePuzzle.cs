using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiblePuzzle : MonoBehaviour
{
    public GameObject WallPoint;

    public GrabObject agarrarObject;

    public BibleWallPoint bibleWall;

    public Puzzles puzzles;

    private float TimeRate = 2f;

    public bool active = false;


    
    


    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.CompareTag("Bible") && Time.time > agarrarObject.WaitTime && WallPoint.transform.childCount == 0)
        {

            active = true;

            other.transform.position = WallPoint.transform.position;

            other.transform.rotation = WallPoint.transform.rotation;

            agarrarObject.pickedObject = null;

            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.transform.SetParent(null);

            agarrarObject.WaitTime = Time.time + TimeRate;

            other.tag = "PutBible";

            other.gameObject.transform.SetParent(WallPoint.gameObject.transform);

            bibleWall.BiblePuzzle();

            puzzles.BibleComprobate();

        }
    }

}

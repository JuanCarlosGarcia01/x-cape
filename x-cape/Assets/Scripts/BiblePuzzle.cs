using UnityEngine;

public class BiblePuzzle : MonoBehaviour
{
    public GameObject WallPoint;
    public IGrabObject agarrarObjectL;
    public IGrabObject agarrarObjectR;
    public BibleWallPoint bibleWall;
    public Puzzles puzzles;
    private float TimeRate = 2f;
    public bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bible") && Time.time > agarrarObjectL.WaitTime  && WallPoint.transform.childCount == 0 || other.gameObject.CompareTag("Bible") && Time.time > agarrarObjectR.WaitTime && WallPoint.transform.childCount == 0)
        {
            active = true;
            other.transform.position = WallPoint.transform.position;
            other.transform.rotation = WallPoint.transform.rotation;
            agarrarObjectL.pickedObject = null;
            agarrarObjectR.pickedObject = null;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(null);
            agarrarObjectL.WaitTime = Time.time + TimeRate;
            agarrarObjectR.WaitTime = Time.time + TimeRate;
            other.tag = "PutBible";
            other.gameObject.transform.SetParent(WallPoint.gameObject.transform);
            bibleWall.BiblePuzzle();
            puzzles.BibleComprobate();
        }
    }
}

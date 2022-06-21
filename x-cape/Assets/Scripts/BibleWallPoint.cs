using UnityEngine;

public class BibleWallPoint : MonoBehaviour
{
    public GameObject objectToFind;
    public GameObject Bible;

    public bool active = false;

    public void BiblePuzzle()
    {
        objectToFind = transform.GetChild(0).gameObject;

        if (objectToFind == Bible)
        {
            active = true;     
        }
        else
        {
            active = false;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class Puzzles : MonoBehaviour
{
    public GameObject BatteryPoint;

    public OpenDoor OpenCroosDoor;
    public OpenDoor OpenBatteryDoor;
    public OpenDoor OpenBibleDoor;

    public GrabObjects grabObject;

    public BibleWallPoint bibleWall;
    public BibleWallPoint bibleWall1;
    public BibleWallPoint bibleWall2;

    public GameObject Cross;
    public GameObject Cross1;
    public GameObject Cross2;

    public GameObject Palanca;
    public GameObject Palanca1;
    public GameObject Palanca2;
    public GameObject Palanca3;

    public Text prueba;
    public Text prueba2;

    public AudioSource BatterySound;
    public AudioSource PutBatterySound;


    public void ComprobateCross()
    { 
         //Comprobación puzzle cruces
        if (Cross.transform.rotation.eulerAngles.z == 180 && Cross1.transform.rotation.eulerAngles.z == 180 && Cross2.transform.rotation.eulerAngles.z == 180)
        {
            OpenCroosDoor.Opendoor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Poner Bateria y abrir puertas
        if (other.gameObject.CompareTag("Object"))
        {
            other.transform.position = BatteryPoint.transform.position;
            other.transform.rotation = BatteryPoint.transform.rotation;
            grabObject.pickedObject = null;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(null);
            other.tag = "ASD";
            OpenBatteryDoor.Opendoor();

            BatterySound.Play();
            PutBatterySound.Play();
        }
    }

    public void BibleComprobate()
    {
        if (bibleWall.active == true && bibleWall1.active == true && bibleWall2.active == true)
        {
            OpenBibleDoor.Opendoor();
        }
    }
}

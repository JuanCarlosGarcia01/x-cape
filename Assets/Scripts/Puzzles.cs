using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzles : MonoBehaviour
{
    public GameObject BatteryPoint;

    public AgarrarObject agarrarObject;

    public PalancaAngle palancaAngle;
    public PalancaAngle palancaAngle1;
    public PalancaAngle palancaAngle2;
    public PalancaAngle palancaAngle3;


    public GameObject Cross;
    public GameObject Cross1;
    public GameObject Cross2;

    public GameObject Palanca;
    public GameObject Palanca1;
    public GameObject Palanca2;
    public GameObject Palanca3;

    public Text prueba;
    public Text prueba2;


    void Update()
    {
        //Comprobación puzzle palancas
        if (palancaAngle.active == true && palancaAngle1.active == false && palancaAngle2.active == true && palancaAngle3.active == true)
        {

            StartCoroutine("PalancaPuzzle");

        }
        // Comprobación puzzle cruces
        if (Cross.transform.rotation.eulerAngles.z == 180 && Cross1.transform.rotation.eulerAngles.z == 180 && Cross2.transform.rotation.eulerAngles.z == 180)
        {

            CrossPuzzle();

        }

    }

    private void OnTriggerStay(Collider other)
    {
        //Poner Bateria y abrir puertas
        if (other.gameObject.CompareTag("Object"))
        {

            other.transform.position = BatteryPoint.transform.position;

            other.transform.rotation = BatteryPoint.transform.rotation;

            agarrarObject.pickedObject = null;

            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().isKinematic = true;

            other.gameObject.transform.SetParent(null);

            other.tag = "ASD";

        }
    }

    void CrossPuzzle()
        //abrir puertas
    {

        prueba.text = "HelloWord!";

    }

    IEnumerator PalancaPuzzle()
    {
        //abrir puertas
        yield return new WaitForSeconds(1);
        prueba2.text = "HelloWord!";

    }
}

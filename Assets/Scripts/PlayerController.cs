using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rapidezDesplazamiento = 10.0f;

    public Camera camaraPrimeraPersona;

    private Rigidbody rb;

    public GameObject mecanics;

    public GameObject map;


    void Start()
    {   
         rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {


        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }


        if (Input.GetKeyDown("x"))
        {

            gameObject.transform.position = mecanics.transform.position;

        }

        if (Input.GetKeyDown("z"))
        {

            gameObject.transform.position = map.transform.position;

        }
    }
}
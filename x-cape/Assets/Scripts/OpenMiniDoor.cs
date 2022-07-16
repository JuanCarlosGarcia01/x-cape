using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMiniDoor : MonoBehaviour
{
    public OpenDoor opendoor;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand1"))
        {
            if ((Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)))
            {
                opendoor.OpendoorBible();
            }
        }
        if (other.gameObject.CompareTag("Hand2"))
        {
            if ((Input.GetKey("e") || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch)))
            {
                opendoor.OpendoorBible();
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaAngle : MonoBehaviour
{
    [HideInInspector] public ILeverManager manager;

    private float RotateRate = 1f;

    private float WaitTime = 0;

    public bool active = false;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (Input.GetKey("e") && Time.time > WaitTime)
            {

                active = !active;

                gameObject.LeanRotateX(active ? 45 : 315, 1f);

                WaitTime = Time.time + RotateRate;
                
                manager.Check();
            }
        }
    }

}

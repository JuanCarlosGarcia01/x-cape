using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int angle = 0;
    public void Opendoor()
    {
        gameObject.LeanRotateY(angle, 2f);
    }
}

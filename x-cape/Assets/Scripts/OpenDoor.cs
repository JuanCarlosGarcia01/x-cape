using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int angle = 0;
    public void Opendoor()
    {
        gameObject.LeanRotateZ(angle, 3f);
    }

    public void OpendoorBible()
    {
        gameObject.LeanRotateY(angle, 3f);
    }
}

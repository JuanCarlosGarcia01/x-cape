using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int angle = 0;
    public GameObject container;
    public GameObject doorcross;
    public void Opendoor()
    {
        gameObject.LeanRotateZ(angle, 3f);
    }

    public void OpendoorBible()
    {
        gameObject.LeanRotateY(angle, 3f);
    }
    public void OpenDoorCross()
    {
        LeanTween.moveY(doorcross, -15, 2f);
    }

    public void OpenDoorLever()
    {
        LeanTween.moveX(container, 182, 2f);
    }
}

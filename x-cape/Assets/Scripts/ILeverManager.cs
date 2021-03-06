using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ILeverManager : MonoBehaviour
{
    [SerializeField] private LeverAngle[] leversObj;
    [SerializeField] private UnityEvent actions;
    [SerializeField] private TextMeshPro text;

    public AudioSource VictorySound;
    public OpenDoor OpenPalancasDoor;

    private bool[] levers;

    private void Start()
    {
        foreach (var lev in leversObj)
            lev.manager = this;

        levers = new bool[leversObj.Length];
        for (int i = 0; i < leversObj.Length; i++)
        {
            levers[i] = Random.Range(0, 2) == 0 ? false : true;
            text.text += levers[i] ? "↓" : "↑";
        }
    }

    public void Check()
    {
        for (int i = 0; i < levers.Length; i++)
            if (levers[i] != leversObj[i].active)
                return;

        // TODO OK
        actions?.Invoke();
        OpenPalancasDoor.OpenDoorLever();
        VictorySound.Play();
    }
}

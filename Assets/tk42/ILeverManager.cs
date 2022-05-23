using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ILeverManager : MonoBehaviour
{
    [SerializeField] private PalancaAngle[] leversObj;
    [SerializeField] private UnityEvent actions;
    [SerializeField] private TextMeshPro text;

    private bool[] levers;

    private void Start()
    {
        foreach (var lev in leversObj)
            lev.manager = this;

        levers = new bool[leversObj.Length];
        for (int i = 0; i < leversObj.Length; i++)
        {
            levers[i] = Random.Range(0, 2) == 0 ? false : true;
            text.text += levers[i] ? "1" : "0";
        }
    }

    public void Check()
    {
        for (int i = 0; i < levers.Length; i++)
            if (levers[i] != leversObj[i].active)
                return;

        // TODO OK
        actions?.Invoke();
        Debug.Log("Bien");
    }
}

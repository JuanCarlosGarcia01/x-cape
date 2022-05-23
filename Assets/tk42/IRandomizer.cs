using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRandomizer : MonoBehaviour
{
    [SerializeField] private Vector3[] positions;
    private void Start() => transform.position = positions[Random.Range(0, positions.Length)];
}

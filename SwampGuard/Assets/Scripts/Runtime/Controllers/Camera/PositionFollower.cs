using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public Vector3 Offset {get => offset; set => offset = value;}

    private void Update()
    {
        transform.position = target.position + offset;
    }
}

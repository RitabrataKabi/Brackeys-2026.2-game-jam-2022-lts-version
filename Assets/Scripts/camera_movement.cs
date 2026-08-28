using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    [SerializeField] private Transform playerBody;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    public void LateUpdate()
    {
        transform.position = playerBody.transform.position + offset;
    }
}

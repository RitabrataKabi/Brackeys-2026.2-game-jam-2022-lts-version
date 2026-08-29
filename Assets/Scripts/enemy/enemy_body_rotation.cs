using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_body_rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, Time.deltaTime * rotationSpeed, 0);
    }
}

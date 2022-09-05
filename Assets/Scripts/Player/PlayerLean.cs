using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLean : MonoBehaviour
{
    public Transform pivot;

    public float speed = 100f;
    public float maxAngle = 20f;
    private float currentAngle = 0f;

    void Awake()
    {
        if (pivot == null && transform.parent != null)
        {
            pivot = transform.parent;
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, maxAngle, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, -maxAngle, speed * Time.deltaTime);
        }
        else
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, 0f, speed * Time.deltaTime);
        }

        pivot.transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
    }
}

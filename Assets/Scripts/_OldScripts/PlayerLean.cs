using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLean : MonoBehaviour
{
    // ----    This is the old leaning code.                                                    ----
    // ----    The disabled lines are for a leaning mechanic that is more of a sharper lean.    ----
    // ----    While the active code makes the leaning smoother.                                ----


    // public Transform pivot;

    // public float speed = 100f;
    // public float maxAngle = 20f;
    // private float currentAngle = 0f;

    // void Awake()
    // {
    //     if (pivot == null && transform.parent != null)
    //     {
    //         pivot = transform.parent;
    //     }
    // }


    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.Q))
    //     {
    //         currentAngle = Mathf.MoveTowardsAngle(currentAngle, maxAngle, speed * Time.deltaTime);
    //     }
    //     else if (Input.GetKey(KeyCode.E))
    //     {
    //         currentAngle = Mathf.MoveTowardsAngle(currentAngle, -maxAngle, speed * Time.deltaTime);
    //     }
    //     else
    //     {
    //         currentAngle = Mathf.MoveTowardsAngle(currentAngle, 0f, speed * Time.deltaTime);
    //     }

    //     pivot.transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
    // }

    public Transform leanPivot;
    private float currentLean;
    private float targetLean;
    public float leanAngle;
    public float leanSmoothing;
    private float leanVelocity;

    private bool isLeaningLeft;
    private bool isLeaningRight;


    private void CalculateLeaning()
    {
        if (isLeaningLeft)
        {
            targetLean = leanAngle;
        }
        else if (isLeaningRight)
        {
            targetLean = -leanAngle;
        }
        else
        {
            targetLean = 0;
        }

        currentLean = Mathf.SmoothDamp(currentLean, targetLean, ref leanVelocity, leanSmoothing);
        leanPivot.localRotation = Quaternion.Euler(new Vector3(0, 0, currentLean));
    }

    void Update()
    {
        CalculateLeaning();
        Debug.Log("Left = " + isLeaningLeft + " " + "Right = " + isLeaningRight + " " + "Target lean = " + targetLean);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isLeaningLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            isLeaningRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isLeaningLeft = false;

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isLeaningRight = false;
        }

    }
}

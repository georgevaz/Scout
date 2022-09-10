using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCam : MonoBehaviour
{

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public bool camOn = false;
    public int cameraNumber;
    void Start()
    {
        cameraNumber = 1;
        StartCoroutine(CameraSwitch());
    }
    IEnumerator CameraSwitch()
    {
        yield return new WaitForSeconds(5);
        cameraTwo.SetActive(true);
        cameraOne.SetActive(false);
        camOn = true;
        cameraNumber = 2;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartoXR : MonoBehaviour
{
    public GameObject xrOrigin;

    // Update is called once per frame
    void Update()
    {
        Vector3 xrOriginPosition = xrOrigin.transform.position;
        transform.position = xrOriginPosition;
    }
}

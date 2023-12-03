using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public GameObject otherObject;      // 충돌을 무시할 대상

    void Start()
    {
        // otherObject의 모든 콜라이더와 충돌 무시
        Collider[] colliders = otherObject.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), col, true);
        }
    }
}
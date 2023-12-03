using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private BoxCollider boxCollider;
    
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.GameEnd(true); //GameClear
        }
    }
}
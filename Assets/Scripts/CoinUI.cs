using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public GameObject coinUI;
    public Slider slider;

    bool isGrabbing = false;
    float GrabTime = 0.0f;

    void Update()
    {
        if(isGrabbing)
        {
            if (GrabTime < 2.0f)
            {
                GrabTime += Time.deltaTime;
                slider.value = GrabTime / 2.0f;
            }
            else
            {
                this.GetComponent<SimpleCollectibleScript>().Collect();
            }
        }
    }

    public void GrabEntered()
    {
        isGrabbing = true;
        coinUI.SetActive(true);
        this.GetComponent<SimpleCollectibleScript>().rotate = false;
    }

    public void GrabExited()
    {
        isGrabbing = false;
        coinUI.SetActive(false);
        GrabTime = 0.0f;
        this.GetComponent<SimpleCollectibleScript>().rotate = true;
    }
}
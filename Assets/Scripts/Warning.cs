﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour {
    public int heartBPM;
    public int subpressure;
    public GameObject mainCanvas;
    public GameObject sp;
    public GameObject sp2;


    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(false);
        sp.SetActive(false);
        sp2.SetActive(false);
    }

    void Update()
    {
        HeartWarning();
        PressureWarning();
    }

    public void HeartWarning()
    {
        if (heartBPM < 80 || heartBPM > 100)
        {
            mainCanvas.SetActive(true);
        } else
        {
            mainCanvas.SetActive(false);
        }
    }
    
    public void PressureWarning()
    {
        if (subpressure < 2 || subpressure > 4)
        {
            sp.SetActive(true);
            sp2.SetActive(true);
        }
        else
        {
            sp.SetActive(false);
            sp2.SetActive(false);
        }
    }


}

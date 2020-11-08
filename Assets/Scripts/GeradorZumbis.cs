﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zombi;
    public float TempoGerarZumbi = 1;

    private float contadorTempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= TempoGerarZumbi)
        {
            Instantiate(Zombi, transform.position, transform.rotation);
            contadorTempo = 0;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public ReservaExtensivel reservaDeBalas;
    public GameObject CanoDaArma;
    public AudioClip SomDetiro;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.Atirar();
            ControlaAudio.instancia.PlayOneShot(SomDetiro);
        }
    }

    private void Atirar()
    {
        if (this.reservaDeBalas.TemObjeto())
        {
            var bala = this.reservaDeBalas.PegarObjeto();
            bala.transform.position = CanoDaArma.transform.position;
            bala.transform.rotation = CanoDaArma.transform.rotation;
        }
    }
}

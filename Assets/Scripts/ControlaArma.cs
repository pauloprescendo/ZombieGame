using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public ReservaExtensivel reservaDeBalas;
    public GameObject CanoDaArma;
    public AudioClip SomDetiro;

    private void Update()
    {
        var toquesNaTela = Input.touches;
        foreach (var toque in toquesNaTela)
        {
            if (toque.phase == TouchPhase.Began)
            {
                this.Atirar();
                ControlaAudio.instancia.PlayOneShot(SomDetiro);
            }
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

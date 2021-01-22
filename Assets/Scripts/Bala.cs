using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade = 20;
    public AudioClip SomDeMorte;

    private int danoDoTiro = 1;

    private Rigidbody rigidbodyBala;

    void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbodyBala.MovePosition(rigidbodyBala.position + transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            objetoDeColisao.GetComponent<ControlaInimigo>().TomarDano(danoDoTiro);
        }

        Destroy(gameObject);
    }
}

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
        Debug.Log("Objeto de Colisao: " + objetoDeColisao.tag);
        switch (objetoDeColisao.tag)
        {
            case Tags.Inimigo:
                objetoDeColisao.GetComponent<ControlaInimigo>().TomarDano(danoDoTiro);
                break;
            case Tags.ChefeDeFase:
                objetoDeColisao.GetComponent<ControlaChefe>().TomarDano(danoDoTiro);
                break;
        }

        Destroy(gameObject);
    }
}

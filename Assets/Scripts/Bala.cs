using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour, IReservavel
{
    public float Velocidade = 20;
    public AudioClip SomDeMorte;

    private int danoDoTiro = 1;

    private Rigidbody rigidbodyBala;
    private IReservaDeObjetos reserva;

    public void SetReserva(IReservaDeObjetos reserva)
    {
        this.reserva = reserva;
    }

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
        Quaternion rotacaoOpostaABala = Quaternion.LookRotation(-transform.forward);
        switch (objetoDeColisao.tag)
        {
            case Tags.Inimigo:
                ControlaInimigo inimigo = objetoDeColisao.GetComponent<ControlaInimigo>();
                inimigo.TomarDano(danoDoTiro);
                inimigo.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;
            case Tags.ChefeDeFase:
                ControlaChefe chefe = objetoDeColisao.GetComponent<ControlaChefe>();
                chefe.TomarDano(danoDoTiro);
                chefe.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;
        }

        Destroy(gameObject);
    }

    public void AoEntrarNaReserva()
    {
        this.gameObject.SetActive(false);
    }

    public void AoSairDaReserva()
    {
        this.gameObject.SetActive(true);
    }
}

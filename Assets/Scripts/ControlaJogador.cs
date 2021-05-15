using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel, ICuravel
{
    // public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDeDano;
    public Status statusJogador;

    private Vector3 direcao;
    private AnimacaoPersonagem animacaoJogador;
    private MovimentoJogador meuMovimentoJogador;

    void Start()
    {
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        statusJogador = GetComponent<Status>();
    }

    void Update()
    {
        animacaoJogador.Movimentar(this.meuMovimentoJogador.Direcao.magnitude);
    }

    void FixedUpdate()
    {
        meuMovimentoJogador.Movimentar(statusJogador.Velocidade);
        meuMovimentoJogador.RotacaoJogador();
    }

    public void TomarDano(int dano)
    {
        statusJogador.Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDeDano);

        if (statusJogador.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        scriptControlaInterface.GameOver();
    }

    public void CurarVida(int quantidadeDeCura)
    {
        statusJogador.Vida += quantidadeDeCura;
        if (statusJogador.Vida > statusJogador.VidaInicial)
        {
            statusJogador.Vida = statusJogador.VidaInicial;
        }
        scriptControlaInterface.AtualizarSliderVidaJogador();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour, IMatavel
{
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDeDano;
    public Status statusJogador;

    private Vector3 direcao;
    private AnimacaoPersonagem animacaoJogador;
    private MovimentoJogador meuMovimentoJogador;

    void Start()
    {
        Time.timeScale = 1;
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        statusJogador = GetComponent<Status>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.Movimentar(direcao.magnitude);

        if (statusJogador.Vida <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("ZombieGame");
            }
        }
    }

    void FixedUpdate()
    {
        meuMovimentoJogador.Movimentar(direcao, statusJogador.Valocidade);
        meuMovimentoJogador.RotacaoJogador(MascaraChao);
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
        Time.timeScale = 0;
        TextoGameOver.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour
{
    public Transform[] PosicoesPossiveisDeGeracao;
    public ReservaFixa reserva;
    public float tempoEntreGeracoes = 60;
    private float tempoParaProximaGeracao = 0;
    private ControlaInterface scriptControlaInterface;
    private Transform jogador;

    void Start()
    {
        tempoParaProximaGeracao = tempoEntreGeracoes;
        scriptControlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
        jogador = GameObject.FindWithTag(Tags.Jogador).transform;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > tempoParaProximaGeracao)
        {
            if (this.reserva.TemObjeto())
            {
                Vector3 posicaoDeCriacao = CalcularPosicaoMaisDistanteDoJogador();
                var chefe = this.reserva.PegarObjeto();
                var controleChefe = chefe.GetComponent<ControlaChefe>();
                controleChefe.SetPosicao(posicaoDeCriacao);
                scriptControlaInterface.AparecerTextoChefeCriado();
                tempoParaProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
            }
        }
    }

    public Vector3 CalcularPosicaoMaisDistanteDoJogador()
    {
        Vector3 posicaoDeMaiorDistancia = Vector3.zero;
        float maiorDistancia = 0;
        foreach (Transform posicao in PosicoesPossiveisDeGeracao)
        {
            float distanciaEntreOJogador = Vector3.Distance(posicao.position, jogador.position);
            if (distanciaEntreOJogador > maiorDistancia)
            {
                maiorDistancia = distanciaEntreOJogador;
                posicaoDeMaiorDistancia = posicao.position;
            }
        }
        return posicaoDeMaiorDistancia;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 10;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;

    private Vector3 direcao;
    private Rigidbody ridigbodyJogador;
    private Animator animatorJogador;

    void Start()
    {
        Time.timeScale = 1;
        ridigbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            animatorJogador.SetBool("Movendo", false);
        }

        if (Vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("ZombieGame");
            }
        }
    }

    void FixedUpdate()
    {
        ridigbodyJogador.MovePosition(ridigbodyJogador.position + (direcao * velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            ridigbodyJogador.MoveRotation(novaRotacao);
        }
    }
}

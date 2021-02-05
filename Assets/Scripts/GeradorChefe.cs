using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour
{
    public GameObject ChefePrefab;

    private float tempoParaProximaGeracao = 0;
    private float tempoEntreGeracoes = 60;

    // Start is called before the first frame update
    void Start()
    {
        tempoParaProximaGeracao = tempoEntreGeracoes;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > tempoParaProximaGeracao)
        {
            Instantiate(ChefePrefab, transform.position, Quaternion.identity);
            tempoParaProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenu : MonoBehaviour
{
    public GameObject BotaoSair;

    void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
            BotaoSair.SetActive(true);
        #endif
    }

    public void JogarJogo()
    {
        StartCoroutine(MudarCena("ZombieGame"));
    }

    IEnumerator MudarCena(string name)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(name);
    }

    IEnumerator Sair()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void SairDoJogo()
    {
        StartCoroutine(Sair());
    }
}

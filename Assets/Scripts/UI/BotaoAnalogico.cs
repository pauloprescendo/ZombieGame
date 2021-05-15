using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotaoAnalogico : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private RectTransform imagemFundo;
    [SerializeField]
    private RectTransform imagemBolinha;
    [SerializeField]
    private MeuEventoDinamicoVector2 QuandoMudarOValor;

    public void OnDrag(PointerEventData eventData)
    {
        var posicaoMouse = CalcularPosicaoMouse(eventData);
        var posicaoLimitada = this.LimitarPosicao(posicaoMouse);
        this.posicionarJoystick(posicaoLimitada);
        this.QuandoMudarOValor.Invoke(posicaoLimitada);
    }

    private Vector2 LimitarPosicao(Vector2 posicaoMouse)
    {
        var posicaoLimitada = posicaoMouse / this.TamanhoDaImagem();
        if (posicaoLimitada.magnitude > 1)
        {
            posicaoLimitada = posicaoLimitada.normalized;
        }
        return posicaoLimitada;
    }

    private float TamanhoDaImagem()
    {
        return this.imagemFundo.rect.width / 2;
    }

    private void posicionarJoystick(Vector2 posicaoMouse)
    {
        this.imagemBolinha.localPosition = posicaoMouse * TamanhoDaImagem();
    }

    private Vector2 CalcularPosicaoMouse(PointerEventData eventData)
    {
        Vector2 posicao;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imagemFundo,
            eventData.position,
            eventData.enterEventCamera,
            out posicao
        );
        return posicao;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.posicionarJoystick(Vector2.zero);
        this.QuandoMudarOValor.Invoke(Vector2.zero);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.OnDrag(eventData);
    }
}

[Serializable]
public class MeuEventoDinamicoVector2 : UnityEvent<Vector2>
{

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_Engenhagem : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [Header("Componentes")]
    [SerializeField]
    Image my_Imagem;
    [SerializeField]
    RectTransform _myRectTransform;
    [SerializeField]
    Canvas _canvas;
    [SerializeField]
    CanvasGroup _canvasGroup;

    [Header("Ultimo Slot que foi dado")]
    [SerializeField]
    Slot_Engenhagem ult_SlotScript;

    [Header("Sprite de Slot")]
    [SerializeField] Sprite imagem_SlotUI;
    [SerializeField] Sprite image_SlotEngenhagem;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        GerencerState(EnumEngenhagem.No_Slot);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _myRectTransform.anchoredPosition += eventData.delta/ _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _myRectTransform.SetParent(ult_SlotScript.myRectTransform);
        _myRectTransform.anchoredPosition =new Vector2(0,0);
        _canvasGroup.alpha = 1f;
        GerencerState(state);
    }

    public void OnDrop(Slot_Engenhagem slotScript, EnumEngenhagem newstate)
    {
        ult_SlotScript.isVoid = true;
        state = newstate;
        ult_SlotScript = slotScript;
        ult_SlotScript.isVoid = false;
    }


    private void GerencerState(EnumEngenhagem newstate)
    {
        switch(newstate)
        {
            case EnumEngenhagem.Slot_UI:
                my_Imagem.sprite = imagem_SlotUI;
                break;
            case EnumEngenhagem.Slot_Engenhagem:
                my_Imagem.sprite = image_SlotEngenhagem;
                break;
            case EnumEngenhagem.No_Slot:
                _canvasGroup.blocksRaycasts = false;
                _myRectTransform.SetParent(_canvas.transform);
                _canvasGroup.alpha = 0.5f;
                 my_Imagem.sprite = imagem_SlotUI;
                break;
        }

        ManagerSlot.instancie.Contador(newstate);
    }

    EnumEngenhagem state;
}

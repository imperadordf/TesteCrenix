using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot_Engenhagem : MonoBehaviour,IDropHandler
{
    
    public RectTransform myRectTransform;
    [SerializeField]
    EnumEngenhagem Slot;
    public bool isVoid=true;
    public bool antiHorario;
    public void OnDrop(PointerEventData eventData)
    {
        if (isVoid)
        {
            eventData.pointerDrag.GetComponent<Drag_Engenhagem>().OnDrop(this, Slot);
        }
       
    }

    public void StartRotate()
    {
        Debug.Log("Rodando");
    }

    public void StopRotate()
    {
        Debug.Log("Paramos");
    }
}

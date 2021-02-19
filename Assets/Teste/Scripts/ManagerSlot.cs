using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSlot : MonoBehaviour
{
 
    public static ManagerSlot instancie;

    private void Awake()
    {
        if (instancie == null)
        {
            instancie = this;
        }
    }

    private void Start()
    {
        foreach (Slot_Engenhagem slots in slotList_UI)
        {
            slots.isVoid = false;
        }
    }

    public void Contador(EnumEngenhagem state)
    {
       
            switch (state)
            {
                case EnumEngenhagem.Slot_Engenhagem:
                    contador_Engenhagem++;
                    ult_State = state;
                    break;
                case EnumEngenhagem.Slot_UI:
                    contador_Engenhagem--;
                    ult_State = state;
                    break;
                case EnumEngenhagem.No_Slot:
                    StopRotate();
                    break;
            }
      

        if (!rotate && contador_Engenhagem == 5 && state != EnumEngenhagem.No_Slot)
            StartEngenhagem();
        else if (rotate)
            StopRotate();
    } 

    private void StartEngenhagem()
    {
        foreach (Slot_Engenhagem slots in slotList_Engenhagem)
        {
            slots.StartRotate();
        }
        rotate = true;
    }

    private void StopRotate()
    {
        foreach (Slot_Engenhagem slots in slotList_Engenhagem)
        {
            slots.StopRotate();
        }
        rotate = false;
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [SerializeField]
    List<Slot_Engenhagem> slotList_UI = new List<Slot_Engenhagem>();

    [SerializeField]
    List<Slot_Engenhagem> slotList_Engenhagem = new List<Slot_Engenhagem>();

    EnumEngenhagem ult_State;
    int contador_Engenhagem = 0;
    bool rotate;
}

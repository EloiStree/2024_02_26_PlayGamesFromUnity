using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchInputBuilderExampleMono : MonoBehaviour
{
    public ScratchInputBuilderMono m_fabrique;


    [ContextMenu("Process the task")]
    public void Process() {


        m_fabrique.CrééUneSequence();
        //m_fabrique.Ajouter_PressKey(true, ScratchInputBuilderMono.KeyScratchType.Space);
        //m_fabrique.Ajouter_Attendre(1);
        //m_fabrique.Ajouter_PressKey(false, ScratchInputBuilderMono.KeyScratchType.Space);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Ajouter_PressKeyForSeconds(1, ScratchInputBuilderMono.KeyScratchType.RightArrow);
        m_fabrique.Ajouter_PressKeyForSeconds(1, ScratchInputBuilderMono.KeyScratchType.DownArrow);
        m_fabrique.Ajouter_PressKeyForSeconds(1, ScratchInputBuilderMono.KeyScratchType.LeftArrow);
        m_fabrique.Ajouter_PressKeyForSeconds(1, ScratchInputBuilderMono.KeyScratchType.UpArrow);
        m_fabrique.Start();

    }
}

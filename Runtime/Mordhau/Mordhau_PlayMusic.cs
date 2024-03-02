using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mordhau_PlayMusic : MonoBehaviour
{
    public MordhauBuilderMono m_fabriquer;

    public float m_timeBetween060notes = 0.8f;

    public float m_chatTime = 0.02f;
    public float m_timeBeforeEnter=0.02f;
    public float m_timeBetweenClipboardActoin = 0.02f;

    [ContextMenu("Lancer Toutes Les Notes")]
    public void LancerToutesLesNotes()
    {
        m_fabriquer.CrééUneSequence();

        m_fabriquer.Ajouter_Attendre(0.1f);

        for (int i = 0; i <=60; i++)
        {
            m_fabriquer.Ajouter_Clipboard("equipmentcommand "+ i);
          //  m_fabriquer.Ajouter_Attendre(m_timeBetween060notes);

        }

        m_fabriquer.Start();
    }


    public void LancerUneSequence(int note)
    {
        note = Math.Clamp(note,0, 60);
        m_fabriquer.CrééUneSequence();
        m_fabriquer.Ajouter_Clipboard("equipmentcommand " + note);
        m_fabriquer.Start();
    }
}


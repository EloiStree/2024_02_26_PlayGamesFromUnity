using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardToMordhauPlayMusicMono : MonoBehaviour
{

    public Mordhau_PlayMusic m_mordhauInterface;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) m_mordhauInterface.LancerUneSequence(0);
        if (Input.GetKeyDown(KeyCode.Alpha1)) m_mordhauInterface.LancerUneSequence(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) m_mordhauInterface.LancerUneSequence(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) m_mordhauInterface.LancerUneSequence(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) m_mordhauInterface.LancerUneSequence(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) m_mordhauInterface.LancerUneSequence(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) m_mordhauInterface.LancerUneSequence(6);
        if (Input.GetKeyDown(KeyCode.Alpha7)) m_mordhauInterface.LancerUneSequence(7);
        if (Input.GetKeyDown(KeyCode.Alpha8)) m_mordhauInterface.LancerUneSequence(8);
        if (Input.GetKeyDown(KeyCode.Alpha9)) m_mordhauInterface.LancerUneSequence(9);
        if (Input.GetKeyDown(KeyCode.Keypad0)) m_mordhauInterface.LancerUneSequence(10);
        if (Input.GetKeyDown(KeyCode.Keypad1)) m_mordhauInterface.LancerUneSequence(11);
        if (Input.GetKeyDown(KeyCode.Keypad2)) m_mordhauInterface.LancerUneSequence(12);
        if (Input.GetKeyDown(KeyCode.Keypad3)) m_mordhauInterface.LancerUneSequence(13);
        if (Input.GetKeyDown(KeyCode.Keypad4)) m_mordhauInterface.LancerUneSequence(14);
        if (Input.GetKeyDown(KeyCode.Keypad5)) m_mordhauInterface.LancerUneSequence(15);
        if (Input.GetKeyDown(KeyCode.Keypad6)) m_mordhauInterface.LancerUneSequence(16);
        if (Input.GetKeyDown(KeyCode.Keypad7)) m_mordhauInterface.LancerUneSequence(17);
        if (Input.GetKeyDown(KeyCode.Keypad8)) m_mordhauInterface.LancerUneSequence(18);
        if (Input.GetKeyDown(KeyCode.Keypad9)) m_mordhauInterface.LancerUneSequence(19);
        for (KeyCode key = KeyCode.A; key <= KeyCode.Z; key++)
        {
            if (Input.GetKeyDown(key))
            {
                int sequenceIndex = (int)key - (int)KeyCode.A + 20;
                m_mordhauInterface.LancerUneSequence(sequenceIndex);
            }
        }

    }

}

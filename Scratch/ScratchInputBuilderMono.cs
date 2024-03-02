using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScratchInputBuilderMono : MonoBehaviour
{

    public UnityEvent<string> m_relayMessage;

    public List<Action_Abstract> m_sequenceActions = new List<Action_Abstract>();


    public void Ajouter_Do(string word, bool active)
    {
        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 " + word, m_relayMessage.Invoke));
        else m_sequenceActions.Add(new Action_SendTextMessage("0 " + word, m_relayMessage.Invoke));

    }

    public void Ajouter_DoForSeconds(string word, float durationInSeconds)
    {
        m_sequenceActions.Add(new Action_SendTextMessage("1 " + word, m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
        m_sequenceActions.Add(new Action_SendTextMessage("0 " + word, m_relayMessage.Invoke));
    }


    public abstract class Action_Abstract
    {

        public abstract IEnumerator GetAction();
    }

    public class Action_Seconds : Action_Abstract
    {
        public float m_attendreEnSeconds = 2;

        public Action_Seconds(float attendreEnSeconds)
        {
            m_attendreEnSeconds = attendreEnSeconds;
        }

        public override IEnumerator GetAction()
        {


            //Debug.Log("Start Waiting");
            yield return new WaitForSeconds(m_attendreEnSeconds);
        }
    }

    public class Action_SendTextMessage : Action_Abstract
    {
        public string m_messageToSend = "";
        private Action<string> m_actionToRelay;

        public Action_SendTextMessage(string message, Action<string> onTrigger)
        {
            m_actionToRelay = onTrigger;
            m_messageToSend = message;
        }

        public override IEnumerator GetAction()
        {

            if (m_actionToRelay != null)
            {


                //Debug.Log("Enovyé: "+m_messageToSend);
                m_actionToRelay.Invoke(m_messageToSend);
            }
            yield return null;
        }
    }

    public void CrééUneSequence()
    {
        m_sequenceActions = new List<Action_Abstract>();
    }


    public void Ajouter_Attendre(float durationInSeconds)
    {
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
    }


    public enum KeyScratchType { 
        Space, _0, _1, _2, _3, _4, _5, _6, _7, _8, _9,
        LeftArrow, RightArrow, UpArrow, DownArrow,
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z

    }

    public void Ajouter_PressKey(bool setKeyDown, KeyScratchType key)
    {

        string value = "";
        value = GetKeyAsString(key);
        Ajouter_Do(value, setKeyDown);
    }

    public void Ajouter_PressKeyForSeconds(float timeToPressInSeconds, KeyScratchType key)
    {

        string value = "";
        value = GetKeyAsString(key);
        Ajouter_DoForSeconds(value, timeToPressInSeconds);
    }

    private static string GetKeyAsString(KeyScratchType key)
    {
        string value = "";
        switch (key)
        {
            case KeyScratchType.Space:
                break;
            case KeyScratchType._0:
            case KeyScratchType._1:
            case KeyScratchType._2:
            case KeyScratchType._3:
            case KeyScratchType._4:
            case KeyScratchType._5:
            case KeyScratchType._6:
            case KeyScratchType._7:
            case KeyScratchType._8:
            case KeyScratchType._9:
                value = key.ToString().Replace("_", "");
                break;
            case KeyScratchType.LeftArrow: value = "Left"; break;
            case KeyScratchType.RightArrow: value = "Right"; break;
            case KeyScratchType.UpArrow: value = "Up"; break;
            case KeyScratchType.DownArrow: value = "Down"; break;
            default:
                value = key.ToString();
                break;
        }

        return value;
    }



    public Coroutine m_coroutine;
    internal void Start()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
        m_coroutine = StartCoroutine(GetExecutionList());
    }

    private IEnumerator GetExecutionList()
    {
        foreach (var item in m_sequenceActions)
        {
            if (item != null)
                yield return item.GetAction();
        }
    }
}

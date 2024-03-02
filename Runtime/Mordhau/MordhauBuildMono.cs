using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MordhauBuilderMono : MonoBehaviour
{

    public UnityEvent<string> m_relayMessage;

    public List<Action_Abstract> m_sequenceActions = new List<Action_Abstract>();



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

    public class Action_SendSeveralTextsMessage : Action_Abstract
    {
        public List<string>m_messagesToSend = new List<string>();
        private Action<string> m_actionToRelay;
        public float m_betweenSeconds;
        public float m_pressingSeconds;

        public Action_SendSeveralTextsMessage( Action<string> onTrigger, float betweenSeconds, float timePressingSeconds, params string [] texts)
        {
            m_actionToRelay = onTrigger;
            m_messagesToSend.AddRange(texts);
            m_betweenSeconds = betweenSeconds;
            m_pressingSeconds = timePressingSeconds;
        }

        public override IEnumerator GetAction()
        {

            foreach (var item in m_messagesToSend)
            {

                m_actionToRelay.Invoke("1 " + item);
                yield return new WaitForSeconds(m_betweenSeconds);
                m_actionToRelay.Invoke("0 " + item);
                yield return new WaitForSeconds(m_pressingSeconds);
                
            }
            yield return null;
        }
    }

    public void CrééUneSequence()
    {
        m_sequenceActions = new List<Action_Abstract>();
    }


    public void Ajouter_WriteText(string text)
    {

        m_sequenceActions.Add(new Action_SendSeveralTextsMessage(
            m_relayMessage.Invoke,
            0.2f,
            0.2f,
            text.ToArray().Select(k => k.ToString()).ToArray()
            )); 
    }




    public void Ajouter_Attendre(float durationInSeconds)
    {
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
    }


    public void Ajouter_Sauter(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 space", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 space", m_relayMessage.Invoke));
    }




    public void Ajouter_AllerGauche(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 q", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 q", m_relayMessage.Invoke));
    }
  


    public void Ajouter_AllerDroite(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 d", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 d", m_relayMessage.Invoke));
    }


    public void Ajouter_AllerEnAvant(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 z", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 z", m_relayMessage.Invoke));
    }



    public void Ajouter_AllerEnArrière(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 s", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 s", m_relayMessage.Invoke));
    }

    public void Ajouter_Clipboard(string message)
    {

        m_sequenceActions.Add(new Action_SendTextMessage("1 multiply", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("0 multiply", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("c "+ message, m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("1 Ctrl", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("1 v", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("0 v", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("0 Ctrl", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("1 enter", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("0 enter", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("1 enter", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_SendTextMessage("0 enter", m_relayMessage.Invoke));

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

    internal void Ajouter_Enter(bool active)
    {
        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 enter", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 enter", m_relayMessage.Invoke));
    }
}

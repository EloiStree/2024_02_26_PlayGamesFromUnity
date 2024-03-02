using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TenSecondsNinjaBuilderMono : MonoBehaviour
{

    public static TenSecondsNinjaBuilderMono Instance;
    public UnityEvent<string> m_relayMessage;

    public List<Action_Abstract> m_sequenceActions = new List<Action_Abstract>();



    public abstract class Action_Abstract {

        public abstract IEnumerator GetAction();
    }

    public class Action_Seconds : Action_Abstract
    {
        public float m_attendreEnSeconds = 2;

        public Action_Seconds(float attendreEnSeconds)
        {
            m_attendreEnSeconds = attendreEnSeconds;
        }

        public override IEnumerator GetAction() {


            //Debug.Log("Start Waiting");
            yield return new WaitForSeconds(m_attendreEnSeconds); }
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

        public override IEnumerator GetAction() {

            if (m_actionToRelay != null) {


                //Debug.Log("Enovyé: "+m_messageToSend);
                m_actionToRelay.Invoke(m_messageToSend);
            }
            yield return null;
        }
    }

    public void CrééUneSequence() {
        m_sequenceActions = new List<Action_Abstract>();
    }


    public void Ajouter_Attendre(float durationInSeconds )
    {
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
    }
    public void Ajouter_LancerShuriken(float durationInSeconds=0.05f)
    {
        m_sequenceActions.Add(new Action_SendTextMessage("1 z", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
        m_sequenceActions.Add(new Action_SendTextMessage("0 z", m_relayMessage.Invoke));
    }
    public void Ajouter_CoupEpee(float durationInSeconds= 0.05f)
    {
        m_sequenceActions.Add(new Action_SendTextMessage("1 x", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
        m_sequenceActions.Add(new Action_SendTextMessage("0 x", m_relayMessage.Invoke));
    }
    public void Ajouter_RedemarrerLeJeu(float durationInSeconds= 0.05f)
    {
        m_sequenceActions.Add(new Action_SendTextMessage("1 r", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
        m_sequenceActions.Add(new Action_SendTextMessage("0 r", m_relayMessage.Invoke));
    }





    public void Ajouter_LancerShuriken(bool active)
    {
        if(active)
        m_sequenceActions.Add(new Action_SendTextMessage("1 z", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 z", m_relayMessage.Invoke));
    }
    public void Ajouter_CoupEpee(bool active)
    {
        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 x", m_relayMessage.Invoke));
        else m_sequenceActions.Add(new Action_SendTextMessage("0 x", m_relayMessage.Invoke));
    }
    public void Ajouter_RedemarrerLeJeu(bool active)
    {
        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 r", m_relayMessage.Invoke));
        else m_sequenceActions.Add(new Action_SendTextMessage("0 r", m_relayMessage.Invoke));
    }


    public void Ajouter_SauterPendant(float durationInSeconds)
    {
        m_sequenceActions.Add(new Action_SendTextMessage("1 up", m_relayMessage.Invoke));
        m_sequenceActions.Add(new Action_Seconds(durationInSeconds));
        m_sequenceActions.Add(new Action_SendTextMessage("0 up", m_relayMessage.Invoke));

    }
    public void Ajouter_Sauter(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 up", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 up", m_relayMessage.Invoke));
    }




    public void Ajouter_AllerGauche(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 left", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 left", m_relayMessage.Invoke));
    }
    public void Ajouter_AllerGauche( float duration)
    {
        Ajouter_AllerGauche(true);
        m_sequenceActions.Add(new Action_Seconds(duration));
        Ajouter_AllerGauche(false);
    }




    public void Ajouter_AllerDroite(bool active)
    {

        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 right", m_relayMessage.Invoke));
        else
            m_sequenceActions.Add(new Action_SendTextMessage("0 right", m_relayMessage.Invoke));
    }
    public void Ajouter_AllerDroite( float duration)
    {
        Ajouter_AllerDroite(true);
        m_sequenceActions.Add(new Action_Seconds(duration));
        Ajouter_AllerDroite(false);
    }

    public Coroutine m_coroutine;
    internal void Start()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
        m_coroutine=StartCoroutine(GetExecutionList());
    }

    private IEnumerator GetExecutionList()
    {
        foreach (var item in m_sequenceActions)
        {
            if(item!=null)
                yield return item.GetAction();
        }
    }
}

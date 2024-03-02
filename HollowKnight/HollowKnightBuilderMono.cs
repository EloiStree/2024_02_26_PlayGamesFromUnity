using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HollowKnightBuilderMono : MonoBehaviour
{

    public UnityEvent<string> m_relayMessage;

    public List<Action_Abstract> m_sequenceActions = new List<Action_Abstract>();


    private void Ajouter_Do(string word, bool active)
    {
        if (active)
            m_sequenceActions.Add(new Action_SendTextMessage("1 " + word, m_relayMessage.Invoke));
        else m_sequenceActions.Add(new Action_SendTextMessage("0 " + word, m_relayMessage.Invoke));

    }

    private void Ajouter_DoForSeconds(string word, float durationInSeconds)
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



    public void Ajouter_TabMap(bool active) => Ajouter_Do("x", active);
    public void Ajouter_Attaque(bool active) => Ajouter_Do("x", active);
    public void Ajouter_RuéePuissante(bool active) => Ajouter_Do("S", active);
    public void Ajouter_Ruée(bool active) => Ajouter_Do("c", active);
    public void Ajouter_Aiguillons(bool active) => Ajouter_Do("d", active);
    public void Ajouter_CanaliserSort(bool active) => Ajouter_Do("a", active);
    public void Ajouter_LancerUnSort(bool active) => Ajouter_Do("f", active);
    public void Ajouter_Sauter(bool active) => Ajouter_Do("z", active);
    public void Ajouter_Inventaire(bool active) => Ajouter_Do("i", active);


    public void Ajouter_AllerGauche(bool active) => Ajouter_Do("left", active);
    public void Ajouter_AllerRight(bool active) => Ajouter_Do("right", active);
    public void Ajouter_AllerHaut(bool active) => Ajouter_Do("up", active);
    public void Ajouter_AllerBas(bool active) => Ajouter_Do("down", active);








    public void Ajouter_TabMap(float duration) => Ajouter_DoForSeconds("x", duration);
    public void Ajouter_Attaque(float duration) => Ajouter_DoForSeconds("x", duration);
    public void Ajouter_RuéePuissante(float duration) => Ajouter_DoForSeconds("S", duration);
    public void Ajouter_Ruée(float duration) => Ajouter_DoForSeconds("c", duration);
    public void Ajouter_Aiguillons(float duration) => Ajouter_DoForSeconds("d", duration);
    public void Ajouter_CanaliserSort(float duration) => Ajouter_DoForSeconds("a", duration);
    public void Ajouter_LancerUnSort(float duration) => Ajouter_DoForSeconds("f", duration);
    public void Ajouter_Sauter(float duration) => Ajouter_DoForSeconds("z", duration);
    public void Ajouter_Inventaire(float duration) => Ajouter_DoForSeconds("i", duration);


    public void Ajouter_AllerGauche(float duration) => Ajouter_DoForSeconds("left", duration);
    public void Ajouter_AllerRight(float duration) => Ajouter_DoForSeconds("right", duration);
    public void Ajouter_AllerHaut(float duration) => Ajouter_DoForSeconds("up", duration);
    public void Ajouter_AllerBas(float duration) => Ajouter_DoForSeconds("down", duration);





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

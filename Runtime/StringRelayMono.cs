using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringRelayMono : MonoBehaviour
{
    public UnityEvent<string> m_onRelay;
    public string m_lastReceived;
    public void Push(string textToRelay)
    {
        m_lastReceived = textToRelay;
        m_onRelay.Invoke(m_lastReceived);
    }
}

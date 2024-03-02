using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopTickInSecondsMono
    : MonoBehaviour
{

    public UnityEvent m_onTick;
    public float m_timeBetWeenTick=12;
    IEnumerator Start()
    {
        while (true) {

            m_onTick.Invoke();
            yield return new WaitForSeconds(m_timeBetWeenTick);
            yield return new WaitForEndOfFrame();
        }
        
    }

}

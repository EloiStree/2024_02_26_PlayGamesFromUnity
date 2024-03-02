using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SendRandomInputToPythonInjectorMono : MonoBehaviour
{
    public UnityEvent<string> m_onPush;

    public float m_timeBetween = 0.1f;
    public float m_timeBetweenMinPress = 0.1f;
    public float m_timeBetweenMaxPress = 1f;

    public string[] m_randomToPush = new string[] { "Left", "Rigth", "Up" };
    IEnumerator Start()
    {
        while (true) {
            string cmd = "0x" + GetRandomF() + GetRandomF();
            m_onPush.Invoke("1 " + cmd);
            yield return new WaitForSeconds(UnityEngine.Random.Range(m_timeBetweenMinPress, m_timeBetweenMaxPress));
            m_onPush.Invoke("0 " + cmd);
            yield return new WaitForSeconds(m_timeBetween);
            cmd = GetRandomCommandInspector();
            m_onPush.Invoke("1 " + cmd);
            yield return new WaitForSeconds(UnityEngine.Random.Range(m_timeBetweenMinPress, m_timeBetweenMaxPress));
            m_onPush.Invoke("0 " + cmd);
            yield return new WaitForSeconds(m_timeBetween);


            yield return new WaitForEndOfFrame();
        }
    }

    private string GetRandomCommandInspector()
    {
        return m_randomToPush[UnityEngine.Random.Range(0, m_randomToPush.Length)];
    }

    private char GetRandomF()
    {
       switch (UnityEngine.Random.Range(0, 16)) {
                              
            case 0: return  '0';
            case 1: return  '1';
            case 2: return  '2';
            case 3: return  '3';
            case 4: return  '4';
            case 5: return  '5';
            case 6: return  '6';
            case 7: return  '7';
            case 8: return  '8';
            case 9: return  '9';
            case 10: return 'A';
            case 11: return 'B';
            case 12: return 'C';
            case 13: return 'D';
            case 14: return 'E';
            case 15: return 'F';
            default:  return '0';
        }
    }

}

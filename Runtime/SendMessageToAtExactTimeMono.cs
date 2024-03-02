using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SendMessageToAtExactTimeMono : MonoBehaviour
{
    public UnityEvent<string> m_onDateTimeMessage;
    public string m_lastPushed;
    public void PushMessage(bool isPressed, string keyType, DateTime time, long milliseconds)
    {
        long unixTimestamp = (long)(time - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        string msg = (isPressed ? "1 " : "0 ") + keyType + " " + (unixTimestamp +" "  + milliseconds);
        m_lastPushed = msg;
        m_onDateTimeMessage.Invoke(msg);
    }

}

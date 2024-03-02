using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MacroRelativeTimeTextBuilderMono
    : MonoBehaviour
{


    public UnityEvent<string> m_onSendMessage;


    public ReplaceBy[] m_replaceBy; 

    [System.Serializable]


    public class ReplaceBy {

        public string m_word;
        public string m_replacement;
    }
    
    [TextArea(0, 10)]
    public string m_example= "1 Up 1000\n0 Up 1020";

    [TextArea(0,10)]
    public string m_setupWithText;
    public TextAsset m_setupWithTextFile;
    public string m_setupWithDirectPath;
    public string m_setupWithRelativePath = "MacroRelative.txt";
    public string m_setupWithRelativePathFull = "MacroRelative.txt";

    [ContextMenu("Push All")]

    public void PushTextAsAction() {


        m_setupWithRelativePathFull = Path.Join(Application.streamingAssetsPath,"../../TextMacro/"+m_setupWithRelativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(m_setupWithRelativePathFull));
        string t = m_setupWithText;
        if(m_setupWithTextFile)
            t +="\n" + m_setupWithTextFile.text;
        if (File.Exists(m_setupWithDirectPath))
            t += "\n" + File.ReadAllText(m_setupWithDirectPath);
        if (!File.Exists(m_setupWithRelativePathFull))
            File.Create(m_setupWithRelativePathFull);
            t += "\n" + File.ReadAllText(m_setupWithRelativePathFull);


        DateTime dateTime = DateTime.Now;
        while (t.IndexOf("  ") > -1)
            t = t.Replace("  ", " ");
        foreach (var line in t.Split("\n"))
        {
            string[] tokens = line.Trim().Split(" ");
            if (tokens.Length == 3)
            {
                bool isPressing = false;
                if (tokens[0].Trim() == "1")
                    isPressing = true;
                else bool.TryParse(tokens[0].Trim(), out isPressing);


                long.TryParse(tokens[2].Trim(), out long milliseconds);



                PushMessage(isPressing,
                    ReplaceByIfNeeded(tokens[1]), dateTime.AddMilliseconds( milliseconds));
            }
            else if (line.Length >3 ) Debug.Log("Humm ?");

        }
    }


    private void Update()
    {
        DateTime now = DateTime.Now; 
        if (m_waiting.Count > 0) {

            for (int i = m_waiting.Count-1; i >= 0; i--)
            {
                if (m_waiting[i].m_dateTime < now)
                {
                    ReadyToBePushed(m_waiting[i]);
                    m_waiting.RemoveAt(i); 
                }

            }
        }
    }

    private void ReadyToBePushed(Waiting waiting)
    {
        m_onSendMessage.Invoke((waiting.m_isPressed ? "1 " : "0 ") + waiting.m_keywords);
    }

    [System.Serializable]
    public struct Waiting {
        public bool m_isPressed;
        public string m_keywords;
        public DateTime m_dateTime;
    }
    public List<Waiting> m_waiting = new List<Waiting>();

    private void PushMessage(bool isPressing, string words, DateTime time )
    {
        m_waiting.Add(new Waiting() { m_isPressed = isPressing, m_keywords = words, m_dateTime = time });
    }

    private string ReplaceByIfNeeded(string v)
    {
        v= v.Trim().ToLower();
        foreach (var item in m_replaceBy)
        {
            if (item.m_word.Trim().ToLower() == v)
                return item.m_replacement;

        }
        return v;
    }


    //[System.Serializable]
    //public class MessageTimedRelative{

    //    public bool m_press;
    //    public string m_message;
    //    public ulong m_relativeMilliSeconds;

    //    public MessageTimedRelative()
    //    {
    //    }

    //    public MessageTimedRelative(bool pressType, string message, ulong relativeMilliSeconds)
    //    {
    //        m_press = pressType;
    //        m_message = message;
    //        m_relativeMilliSeconds = relativeMilliSeconds;
    //    }
    //}

    //public void Add(MessageTimedRelative message)
    //{

    //    m_messageToSend.Add(message);
    //}
    //public void Add(PressType press, string message, ulong milliseconds)
    //{

    //    m_messageToSend.Add(new MessageTimedRelative());
    //}
    //public void Clear() {

    //    m_messageToSend.Clear();
    //}
}

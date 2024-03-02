using UnityEngine;
using UnityEngine.Events;

public class HollowKnightFacadeMono : MonoBehaviour
{

    public FR fr= new FR();
    public EN en = new EN();

    [System.Serializable]
    public class FR {
        public UnityEvent<string> m_onRequest;
        public string m_lastSent;

  

    public void Haut(bool pressKey) => SendRequest(pressKey, "Up");
    public void Bas(bool pressKey) => SendRequest(pressKey, "Down");
    public void Droite(bool pressKey) => SendRequest(pressKey, "Right");
    public void Gauche(bool pressKey) => SendRequest(pressKey, "Left");
    public void Carte(bool pressKey) => SendRequest(pressKey, "Tab");
    public void Sauter(bool pressKey) => SendRequest(pressKey, "Z");
    public void Attaque(bool pressKey) => SendRequest(pressKey, "X");
    public void RueePuissante(bool pressKey) => SendRequest(pressKey, "S");
    public void Ruee(bool pressKey) => SendRequest(pressKey, "C");
    public void CanaliserSort(bool pressKey) => SendRequest(pressKey, "A");
    public void LancerUnSort(bool pressKey) => SendRequest(pressKey, "F");
    public void Inventaire(bool pressKey) => SendRequest(pressKey, "I");

    private void SendRequest(bool pressKey, string request)
    {
        m_lastSent = (pressKey ? "1 " : "0 ") + request;
        m_onRequest.Invoke(m_lastSent);
        }
    }


    [System.Serializable]
    public class EN
    {
        public UnityEvent<string> m_onRequest;
        public string m_lastSent;



        public void Haut(bool pressKey) => SendRequest(pressKey, "Up");
        public void Bas(bool pressKey) => SendRequest(pressKey, "Down");
        public void Droite(bool pressKey) => SendRequest(pressKey, "Right");
        public void Gauche(bool pressKey) => SendRequest(pressKey, "Left");
        public void Carte(bool pressKey) => SendRequest(pressKey, "Tab");
        public void Sauter(bool pressKey) => SendRequest(pressKey, "Z");
        public void Attaque(bool pressKey) => SendRequest(pressKey, "X");
        public void RueePuissante(bool pressKey) => SendRequest(pressKey, "S");
        public void Ruee(bool pressKey) => SendRequest(pressKey, "C");
        public void CanaliserSort(bool pressKey) => SendRequest(pressKey, "A");
        public void LancerUnSort(bool pressKey) => SendRequest(pressKey, "F");
        public void Inventaire(bool pressKey) => SendRequest(pressKey, "I");

        private void SendRequest(bool pressKey, string request)
        {
            m_lastSent = (pressKey ? "1 " : "0 ") + request;
            m_onRequest.Invoke(m_lastSent);
        }
    }

}

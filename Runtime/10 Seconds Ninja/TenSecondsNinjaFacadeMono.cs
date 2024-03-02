using UnityEngine;
using UnityEngine.Events;

public class TenSecondsNinjaFacadeMono : MonoBehaviour
{
    public UnityEvent<string> m_onRequest;
    public string m_lastSent;

    public void Gauche(bool pressKey) => SendRequest(pressKey, "Left");
    public void Droite(bool pressKey) => SendRequest(pressKey, "Right");
    public void Sauter(bool pressKey) => SendRequest(pressKey, "Up");
    public void Epee(bool pressKey) => SendRequest(pressKey, "X");
    public void Shuriken(bool pressKey) => SendRequest(pressKey, "Z");
    public void Reessayer(bool pressKey) => SendRequest(pressKey, "R");
    public void X(bool pressKey) => SendRequest(pressKey, "X");
    public void C(bool pressKey) => SendRequest(pressKey, "C");
    public void Z(bool pressKey) => SendRequest(pressKey, "Z");
    public void Enter(bool pressKey) => SendRequest(pressKey, "Enter");

    private void SendRequest(bool pressKey, string request)
    {
        m_lastSent = (pressKey ? "1 " : "0 ") + request;
        m_onRequest.Invoke(m_lastSent);
    }

}

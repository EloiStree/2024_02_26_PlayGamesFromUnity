using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TenSecondsNinja_Level1_ExampleMono : MonoBehaviour
{

    public TenSecondsNinjaFacadeMono m_10NinjaFacade;

    private void Start()
    {
        LaunchLevelOne();
    }

    [ContextMenu("Launch Level One")]

    private void LaunchLevelOne()
    {
        StartCoroutine(TryLevel1());
    }

    private IEnumerator TryLevel1()
    {
        while (true)
        {
            TenSecondsNinjaFacadeMono n = m_10NinjaFacade;

            yield return ForDuration(n.Reessayer);
            n.Droite(true);
            yield return new WaitForSeconds(0.2f);
            yield return ForDuration(n.Shuriken);
            yield return new WaitForSeconds(0.1f);
            n.Droite(false);
            yield return ForDuration(n.Sauter, 0.4f);
            n.Gauche(true);
            n.Sauter(true);
            yield return new WaitForSeconds(0.1f);
            n.Sauter(false);
            yield return new WaitForSeconds(0.1f);
            yield return ForDuration(n.Epee, 0.1f);
            n.Gauche(false);
            n.Droite(true);
            yield return new WaitForSeconds(0.3f);
            yield return ForDuration(n.Sauter, 0.4f);
            yield return new WaitForSeconds(0.1f);
            yield return ForDuration(n.Sauter, 0.1f);
            yield return new WaitForSeconds(0.05f);
            yield return ForDuration(n.Shuriken);
            n.Droite(true);


            yield return new WaitForSeconds(1);
        }

    }

    public IEnumerator ForDuration(Action<bool> action, float seconds=0.1f) {

        if(action!= null)
            action(true);
        yield return new WaitForSeconds(seconds);
        if (action != null)
            action(false);
    }
}

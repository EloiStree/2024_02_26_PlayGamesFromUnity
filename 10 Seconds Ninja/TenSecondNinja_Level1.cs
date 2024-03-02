using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenSecondNinja_Level1 : MonoBehaviour
{
    public TenSecondsNinjaBuilderMono m_fabriquer;


   

    
    [ContextMenu("Lancer une séquence")]
    public void LancerUneSequence()
    {
        m_fabriquer.CrééUneSequence();


        m_fabriquer.Ajouter_RedemarrerLeJeu();
        m_fabriquer.Ajouter_AllerDroite(true);
        m_fabriquer.Ajouter_Attendre(0.1f);
        m_fabriquer.Ajouter_AllerDroite(false);
        m_fabriquer.Start();

        //m_fabriquer.Ajouter_RedemarrerLeJeu();

        //m_fabriquer.Ajouter_Attendre(0.1f);
        //m_fabriquer.Ajouter_AllerDroite(true);
        //m_fabriquer.Ajouter_Attendre(0.1f);
        //m_fabriquer.Ajouter_AllerDroite(false);

        //m_fabriquer.Ajouter_LancerShuriken(0.05f);

        //m_fabriquer.Ajouter_Attendre(0.1f);
        //m_fabriquer.Ajouter_Sauter(true);
        //m_fabriquer.Ajouter_Attendre(0.1f);
        //m_fabriquer.Ajouter_Sauter(false);
        //m_fabriquer.Ajouter_Attendre(0.1f);
        //m_fabriquer.Ajouter_Sauter(true);
        //m_fabriquer.Ajouter_Attendre(0.1f);
        //m_fabriquer.Ajouter_Sauter(false);
    }
}

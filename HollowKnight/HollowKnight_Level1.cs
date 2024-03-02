using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowKnight_Level1 : MonoBehaviour
{

    public HollowKnightBuilderMono m_fabrique;


    [ContextMenu("Process Level")]
    public void ProcessLevel()
    {
        m_fabrique.CrééUneSequence();
        m_fabrique.Ajouter_AllerRight(true);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Ajouter_AllerRight(false);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Ajouter_AllerGauche(true);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Ajouter_AllerGauche(false);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Ajouter_Attaque(true);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Ajouter_Attaque(false);
        m_fabrique.Ajouter_Attendre(1);
        m_fabrique.Start();
    }


}

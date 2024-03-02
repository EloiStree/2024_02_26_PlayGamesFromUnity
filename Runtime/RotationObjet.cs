using UnityEngine;

public class RotationObjet : MonoBehaviour
{
    public float vitesseRotation = 50f;
    public KeyCode toucheGauche = KeyCode.LeftArrow;
    public KeyCode toucheDroite = KeyCode.RightArrow;

    void Update()
    {
        // Rotation vers la gauche
        if (Input.GetKey(toucheGauche))
        {
            transform.Rotate(Vector3.up, -vitesseRotation * Time.deltaTime);
        }

        // Rotation vers la droite
        if (Input.GetKey(toucheDroite))
        {
            transform.Rotate(Vector3.up, vitesseRotation * Time.deltaTime);
        }
    }
}

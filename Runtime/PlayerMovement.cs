using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement du personnage

    // M�thode appel�e � chaque frame
    private void Update()
    {
        // R�cup�rer les entr�es de d�placement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculer le d�placement
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Appliquer le d�placement
        MovePlayer(movement);
    }

    // M�thode pour d�placer le joueur
    private void MovePlayer(Vector3 movement)
    {
        // D�placer le joueur dans l'espace en fonction du vecteur de mouvement
        transform.Translate(movement);
    }
}

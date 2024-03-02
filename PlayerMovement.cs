using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du personnage

    // Méthode appelée à chaque frame
    private void Update()
    {
        // Récupérer les entrées de déplacement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculer le déplacement
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Appliquer le déplacement
        MovePlayer(movement);
    }

    // Méthode pour déplacer le joueur
    private void MovePlayer(Vector3 movement)
    {
        // Déplacer le joueur dans l'espace en fonction du vecteur de mouvement
        transform.Translate(movement);
    }
}

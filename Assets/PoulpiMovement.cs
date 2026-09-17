using UnityEngine;

public class PoulpiMovement : MonoBehaviour
{
    // Vitesse de déplacement que tu pourras modifier dans Unity
    public float moveSpeed = 5f;

    // Référence au composant physique du joueur
    public Rigidbody2D rb;

    // Stocke la direction (X pour gauche/droite, Y pour haut/bas)
    private Vector2 movement;

    // Update lit les touches appuyées à chaque image (frame)
    void Update()
    {
        // GetAxisRaw donne -1, 0 ou 1. Parfait pour des contrôles rétro précis !
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Cela empêche le joueur d'aller plus vite quand il marche en diagonale
        movement = movement.normalized;
    }

    // FixedUpdate est utilisé pour tout ce qui touche à la physique
    void FixedUpdate()
    {
        // On déplace le Rigidbody à sa position actuelle + la direction * vitesse
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

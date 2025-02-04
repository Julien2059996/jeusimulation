using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice4 : MonoBehaviour
{
    private Coroutine currentMoveCoroutine; // Pour stocker la coroutine en cours

    // Vitesse de déplacement
    public float moveSpeed = 5f;

    // Start est appelé avant la première image
    void Start()
    {
        // Aucune initialisation nécessaire ici
    }

    // Update est appelé une fois par image
    void Update()
    {
        // Détecter les clics de souris
        if (Input.GetMouseButtonDown(0)) // Clic gauche de la souris
        {
            // Si une coroutine est déjà en cours, l'arrêter
            if (currentMoveCoroutine != null)
            {
                StopCoroutine(currentMoveCoroutine);
            }

            // Démarrer la coroutine pour déplacer le joueur vers la position du clic
            currentMoveCoroutine = StartCoroutine(MovePlayerToMousePosition());
        }
    }

    // Coroutine pour déplacer le joueur vers la position du clic
    IEnumerator MovePlayerToMousePosition()
    {
        // Crée un rayon à partir de la position du clic de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si le rayon touche un objet comme le terrain ou le sol
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Tant qu'on est trop loin de la cible (par exemple, à plus de 0.5f)
            while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
            {
                // Déplacement progressif du joueur vers la cible
                transform.position += direction * moveSpeed * Time.deltaTime;

                // Attendre la prochaine frame avant de continuer
                yield return null;
            }

            // Assurez-vous que le joueur arrive exactement à la cible
            transform.position = targetPosition;
        }
    }
}

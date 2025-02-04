using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice4 : MonoBehaviour
{
    private Coroutine currentMoveCoroutine; // Pour stocker la coroutine en cours

    // Vitesse de d�placement
    public float moveSpeed = 5f;

    // Start est appel� avant la premi�re image
    void Start()
    {
        // Aucune initialisation n�cessaire ici
    }

    // Update est appel� une fois par image
    void Update()
    {
        // D�tecter les clics de souris
        if (Input.GetMouseButtonDown(0)) // Clic gauche de la souris
        {
            // Si une coroutine est d�j� en cours, l'arr�ter
            if (currentMoveCoroutine != null)
            {
                StopCoroutine(currentMoveCoroutine);
            }

            // D�marrer la coroutine pour d�placer le joueur vers la position du clic
            currentMoveCoroutine = StartCoroutine(MovePlayerToMousePosition());
        }
    }

    // Coroutine pour d�placer le joueur vers la position du clic
    IEnumerator MovePlayerToMousePosition()
    {
        // Cr�e un rayon � partir de la position du clic de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si le rayon touche un objet comme le terrain ou le sol
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Tant qu'on est trop loin de la cible (par exemple, � plus de 0.5f)
            while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
            {
                // D�placement progressif du joueur vers la cible
                transform.position += direction * moveSpeed * Time.deltaTime;

                // Attendre la prochaine frame avant de continuer
                yield return null;
            }

            // Assurez-vous que le joueur arrive exactement � la cible
            transform.position = targetPosition;
        }
    }
}

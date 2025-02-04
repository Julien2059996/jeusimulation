using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerice3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Aucune initialisation nécessaire pour ce script
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Détecter les clics de souris
        if (Input.GetMouseButtonDown(0)) // Clic gauche de la souris
        {
            TeleportPlayerToMousePosition();
        }
    }

    void TeleportPlayerToMousePosition()
    {
        // 2. Faire correspondre le clic à un point sur le plan
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crée un rayon à partir de la position du clic de la souris
        RaycastHit hit;

        // Si le rayon touche un objet (comme le terrain ou le sol)
        if (Physics.Raycast(ray, out hit))
        {
            // 3. Déplacer le personnage en téléportant sa position
            // Nous allons déplacer l'objet parent du joueur (GameObject vide parent)
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}

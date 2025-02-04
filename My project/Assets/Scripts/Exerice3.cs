using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerice3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Aucune initialisation n�cessaire pour ce script
    }

    // Update is called once per frame
    void Update()
    {
        // 1. D�tecter les clics de souris
        if (Input.GetMouseButtonDown(0)) // Clic gauche de la souris
        {
            TeleportPlayerToMousePosition();
        }
    }

    void TeleportPlayerToMousePosition()
    {
        // 2. Faire correspondre le clic � un point sur le plan
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cr�e un rayon � partir de la position du clic de la souris
        RaycastHit hit;

        // Si le rayon touche un objet (comme le terrain ou le sol)
        if (Physics.Raycast(ray, out hit))
        {
            // 3. D�placer le personnage en t�l�portant sa position
            // Nous allons d�placer l'objet parent du joueur (GameObject vide parent)
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}

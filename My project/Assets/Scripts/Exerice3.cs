using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerice3 : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TeleportPlayerToMousePosition();
        }
    }

    void TeleportPlayerToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}

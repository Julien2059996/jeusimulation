using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice7 : MonoBehaviour
{
    private Coroutine currentMoveCoroutine;
    private Coroutine currentRotateCoroutine;
    public float moveSpeed = 5f;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ((currentMoveCoroutine != null) && (currentRotateCoroutine != null))
            {
                StopCoroutine(currentMoveCoroutine);
                StopCoroutine(currentRotateCoroutine);
            }
            currentRotateCoroutine = StartCoroutine(RotatePlayerToMousePosition());
            currentMoveCoroutine = StartCoroutine(MovePlayerToMousePosition());
        }
    }

    IEnumerator RotatePlayerToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = (targetPosition - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 400 * Time.deltaTime);
                yield return null;
            }

            transform.rotation = targetRotation;

        }
    }

    IEnumerator MovePlayerToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = (targetPosition - transform.position).normalized;


            while (Vector3.Distance(transform.position, targetPosition) > 0.5f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}

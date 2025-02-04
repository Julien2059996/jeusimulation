using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Plane collisionNotifier;
    public int Point = 0;

    [SerializeField] GameObject textTMP;

    private void OnEnable()
    {
        // Subscribe to the AddScore event
        if (collisionNotifier != null)
        {
            collisionNotifier.AddScore += HandleAddScore;
        }
    }

    private void OnDisable()
    {
        // Unsubscribe when the script is disabled or destroyed
        if (collisionNotifier != null)
        {
            collisionNotifier.AddScore -= HandleAddScore;
        }
    }

    // This method will be called when the AddScore event is triggered
    private void HandleAddScore(Collision collision)
    {
        Point++;
        if (textTMP != null)
        {
            textTMP.GetComponent<TMP_Text>().text = $"Points: {Point}";
        }
    }
}

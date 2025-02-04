using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public event Action<Collision> AddScore;
    [SerializeField] private GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == sphere)
        {
            AddScore?.Invoke(collision);
            print("Hurray");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

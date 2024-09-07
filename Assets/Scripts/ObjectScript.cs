using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool isTrap;
    [SerializeField] private float moveSpeed = 5f;
    private bool isRight;

    private void Start()
    {
        // Using ternary operator for cleaner code
        isRight = transform.position.x < 0; 
        // Destroy the GameObject after 5 seconds
        Destroy(gameObject, 5f);              
    }

    private void Update()
    {
        float direction = isRight ? 1 : -1;
        transform.Translate(direction * moveSpeed * Time.deltaTime, 0, 0);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance == null)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (isTrap)
            {
                Destroy(other.gameObject);
                GameManager.instance.DeathScreen();            
            }
            else
            {
                GameManager.instance.AddScore();                     
                Destroy(gameObject);
            }
        }
    }
}

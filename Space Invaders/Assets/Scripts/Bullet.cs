using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (this.gameObject.CompareTag("Bullet_Player"))
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        else if (this.gameObject.CompareTag("Bullet_Enemy"))
        {
            rb.velocity = transform.up * -bulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        //Debug.Log($"Hit {collision.gameObject.name}");
        Destroy(gameObject);
    }
}

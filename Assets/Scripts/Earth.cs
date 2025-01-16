using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public static bool touchedEarth;
    // Start is called before the first frame update
    void Start()
    {
        touchedEarth = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Earth hit by enemy");
            touchedEarth = true;
            GameManager.Instance.GameOver();
        }
    }

}

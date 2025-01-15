using Unity.VisualScripting;
using UnityEngine;

/*
    This player script handles mechanics such as player health,
    and dying
*/

public class Player : MonoBehaviour
{
    public int HitPoints {get; private set;}
    
    public bool PlayerDied {get; private set;}

    public static bool playerInput = true;

    void TakeLife()
    {
        AudioManager.Instance.PlayPlayerHurt();
        HitPoints = HitPoints > 0 ? HitPoints-1 : 0;
        GameManager.Instance.SetPlayerHealth(HitPoints);
        if (HitPoints == 0)
        {
            PlayerDied = true;
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        playerInput = false;
        Destroy(gameObject);
        PlayerDied = true;
        GameManager.Instance.GameOver();
    }

    protected void ResetPlayer()
    {
        playerInput = true;
        PlayerDied = false;
        HitPoints = 3;
        GameManager.Instance.SetPlayerHealth(HitPoints);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_Enemy"))
        {
            TakeLife();
        }
    }
}

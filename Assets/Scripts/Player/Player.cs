using System.Collections;
using UnityEngine;

/*
    This player script handles mechanics such as player health,
    and dying
*/

public class Player : MonoBehaviour
{
    protected SpriteRenderer sr;
    public int HitPoints {get; private set;}
    public bool PlayerDied {get; private set;}

    public static bool playerInput = true;

    protected bool _invulnerable = false;
    [SerializeField] protected float _invulnerableTime = 1f;
    

    protected void TakeLife()
    {
        AudioManager.Instance.PlayPlayerHurt();
        HitPoints = HitPoints > 0 ? HitPoints-1 : 0;
        GameManager.Instance.SetPlayerHealth(HitPoints);
        if (HitPoints > 0)
        {
            _invulnerable = true;
            StartCoroutine("FlickerSprite");
        }
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
    protected IEnumerator FlickerSprite()
    {
        do
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.15f);
        } while (_invulnerable);
    }
}

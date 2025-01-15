using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int enemyCount;
    public BulletSpawner bulletSpawner;
    [SerializeField] private int hitPoints = 1;
    public float _moveSpeed = 0.25f;
    public float _moveInterval = 2f;
    public int moveDistance = 5;
    protected float _attackSpeed;
    public float _minAttackSpeed;
    public float _maxAttackSpeed;
    public int score;

    private int moveCount;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "Mothership")
        {
            enemyCount++;
        }
        StartCoroutine("MoveEnemy");
        StartCoroutine("ShootBullet");
    }

    // Update is called once per frame
    void Update()
    {
        // if (moveCount % 2 == 0)
        // {
        //     _moveSpeed += 0.125f;
        // }
    }


    IEnumerator MoveEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_moveInterval);
            
            for (int i = 0; i <= moveDistance; i++)
            {
                transform.position += Vector3.right * _moveSpeed;
    
                yield return new WaitForSeconds(_moveInterval);
            }

            if (gameObject.name != "Mothership")
            {
                transform.position += Vector3.down * Mathf.Abs(_moveSpeed);
            }

            _moveInterval = _moveInterval > 0.125f ? _moveInterval-0.125f : 0.125f;
            _moveSpeed *= -1;
        }
    }

    IEnumerator ShootBullet()
    {
        while (true)
        {
            _attackSpeed = Random.Range(_minAttackSpeed, _maxAttackSpeed);
            yield return new WaitForSeconds(_attackSpeed);
            bulletSpawner.SpawnBullet();
        }
    }

    void TakeLife()
    {
        hitPoints = hitPoints > 0 ? hitPoints-1 : 0;
        if (hitPoints == 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        if (gameObject.name != "Mothership")
        {
            enemyCount--;
            Debug.Log($"{enemyCount} Enemies Left");
        }
        GameManager.Instance.PlayerScores(score);
        AudioManager.Instance.PlayDestroyEnemy();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_Player"))
        {
            TakeLife();
        }
    }
}

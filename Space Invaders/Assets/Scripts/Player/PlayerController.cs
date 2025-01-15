using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    public BulletSpawner bulletSpawner;
    private Rigidbody2D rb;
    private float _xInput;
    [SerializeField] private float _moveSpeed = 5f;
    private Vector2 _movement;

    [SerializeField] private float _attackSpeed = 0.75f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput)
        {
            ReadInput();
            _movement = new Vector2(_xInput * _moveSpeed, rb.velocity.y);
            rb.velocity = _movement;
        }
        timer += Time.deltaTime;
    }

    void ReadInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        if (Input.GetButton("Shoot") && timer >= _attackSpeed)
        {
            bulletSpawner.SpawnBullet();
            AudioManager.Instance.PlayEnemyShoot();
            timer = 0;
        }
    }

}

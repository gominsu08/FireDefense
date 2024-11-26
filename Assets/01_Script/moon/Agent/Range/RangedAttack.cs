using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private Animator _animator;
    public float moveSpeed;
    public float attackDamaged;
    public float moveSpeedX = 1;
    public int canAttackCount = 1;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Start()
    {
        if(_animator != null)
        {
            Play("Attack");
        }
    }
    private void Update()
    {
        transform.position += new Vector3(moveSpeed* moveSpeedX, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = 0;
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(attackDamaged);
            canAttackCount--;
        }
        if(canAttackCount <= 0)
        {
            PlayDestroy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    public void Play(string name)
    {
        _animator.Play(name);
    }
    private void PlayDestroy()
    {
        Play("Destroy");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}

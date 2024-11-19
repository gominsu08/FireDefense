using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private Animator _animator;
    public float moveSpeed;
    public float attackDamaged;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Start()
    {
        Play("Attack");
    }
    private void Update()
    {
        transform.position += new Vector3(moveSpeed, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = 0;
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(attackDamaged);
        }
        PlayDestroy();
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

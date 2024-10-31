using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyDistanceChecker : MonoBehaviour
{
    public static MyEnemyDistanceChecker instance = null;
    [SerializeField] private LayerMask Enemy;
    [SerializeField] private LayerMask Player;
    private List<Transform> Enemys = new List<Transform>();
    private List<Transform> Players = new List<Transform>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        EnemyCheck();
        PlayerCheck();
    }

    private void EnemyCheck()
    {
        Collider2D[] EnemysCollider = Physics2D.OverlapCircleAll(Vector3.zero, 100, Enemy);
        foreach (Collider2D collider in EnemysCollider)
        {
            Enemys.Add(collider.transform);
        }

    }
    private void PlayerCheck()
    {
        Collider2D[] PlayerCollider = Physics2D.OverlapCircleAll(Vector3.zero, 100, Player);
        foreach (Collider2D collider in PlayerCollider)
        {
            Players.Add(collider.transform);
        }
    }
    private Vector3 FindCloseEnemy(Transform myTransform)
    {
        Transform closeEnemy = null;
        float minDistance = float.MaxValue;

        foreach (Transform enemy in Enemys)
        {
            if (enemy == null) continue;
            float distance = Vector3.Distance(myTransform.position, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closeEnemy = enemy;
            }
        }

        return closeEnemy.position;
    }
    private Vector3 FindClosePlayer(Transform myTransform)
    {
        Transform closePlayer = null;
        float minDistance = float.MaxValue;

        foreach (Transform player in Players)
        {
            if (player == null) continue;
            float distance = Vector3.Distance(myTransform.position, player.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closePlayer = player;
            }
        }

        return closePlayer.position;
    }
    public Vector3 MyEnemyCheck(Transform myTransform, LayerMask myLayer)
    {
        if(myLayer == Enemy)
        {
            return FindClosePlayer(myTransform);
        }
        else if(myLayer == Player)
        {
            return FindCloseEnemy(myTransform);
        }
        else
        {
            Debug.LogError("myLayer is Enemy or Player");
            return Vector3.zero;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 100);
    }
}   

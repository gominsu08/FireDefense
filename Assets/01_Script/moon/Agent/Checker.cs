using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    public List<Health> myEnemys = new List<Health>();
    private int findedEnemy;
    private int FindedEnemy
    {
        get
        {
            return findedEnemy;
        }
        set
        {
            if(value <= 0)
            {
                findedEnemy = 0;
                IsEnemy = false;
            }
            else
            {
                findedEnemy = value;
                IsEnemy = true;
            }
        }
    }
    private bool isEnemy;
    public bool IsEnemy
    {
        get
        {
            return isEnemy;
        }
        set
        {
            isEnemy = value;
            if (isEnemy)
            {
                OnEnemyEnter?.Invoke();
            }
            else
            {
                OnEnemyAllExit?.Invoke();
            }
        }
    }
    public UnityEvent OnEnemyEnter,OnEnemyAllExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.transform.GetComponent<Health>() != null)
            {
                myEnemys.Add(collision.transform.GetComponent<Health>());
                FindedEnemy++;
            }
        }
        catch (Exception)
        {
            print("Health has a problem");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            if (collision.transform.GetComponent<Health>() != null)
            {
                myEnemys.Remove(collision.transform.GetComponent<Health>());
                FindedEnemy--;
            }
        }
        catch (Exception)
        {
            print("Health has a problem");
        }
    }
}

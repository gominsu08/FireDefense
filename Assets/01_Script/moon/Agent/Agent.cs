using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    #region component region
    public Animator AnimatorCompo { get; protected set; }
    public Checker CheckerCompo { get; private set; }
    #endregion
    
    [SerializeField]LayerMask MyEnemy;

    protected virtual void Awake()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();
        CheckerCompo = transform.Find("Checker").GetComponent<Checker>();
    }
}

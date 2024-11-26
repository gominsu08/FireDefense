using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentNextButton : MonoBehaviour
{
    [SerializeField] GameObject[] _hideThing;
    [SerializeField]MyEnemyDistanceChecker _enemyDistanceChecker;
    public void Next()
    {
        _enemyDistanceChecker.Chack();
        Time.timeScale = 1.0f;
        foreach (var thing in _hideThing)
        {
            thing.SetActive(false);
        }
    }
}

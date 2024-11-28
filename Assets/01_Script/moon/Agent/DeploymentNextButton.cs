using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentNextButton : MonoBehaviour
{
    [SerializeField] GameObject[] _hideThing;
    public void Next()
    {
        MyEnemyDistanceChecker.instance.Chack();
        Time.timeScale = 1.0f;
        foreach (var thing in _hideThing)
        {
            thing.SetActive(false);
        }
    }
}

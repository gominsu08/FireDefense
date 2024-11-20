using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Range(1, 4)]
    public int StageNumber = 1;
    [Range(1, 4)]
    public int StageDifficulty = 1;

    [field: SerializeField] public int StageCost { get; private set; }


}


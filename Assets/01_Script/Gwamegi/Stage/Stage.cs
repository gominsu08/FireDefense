using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [field:SerializeField] public int StageNumber {  get; private set; }
    [field: SerializeField] public int StageDifficulty { get; private set; }
    [field: SerializeField] public int StageCost { get; private set; }


}


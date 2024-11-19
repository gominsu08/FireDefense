using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Data/Stage/ToolInfoSO")]
public class ToolInfoSO : ScriptableObject
{
    [Header("StageManager")]
    public string StageSOFolder = "Assets/06_SO/Gwamegi/Stage";
    public string poolAssetName = "StageData.asset";
}

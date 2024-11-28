using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "SO/UnitCardColorData")]
public class UnitCardColorData : ScriptableObject
{
    public Sprite commonUnitCardSprite;
    public Sprite unCommonUnitCardSprite;
    public Sprite rareUnitCardSprite;
    public Sprite legendaryUnitCardSprite;
}

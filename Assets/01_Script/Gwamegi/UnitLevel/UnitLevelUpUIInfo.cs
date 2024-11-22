using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitLevelUpInfoClass
{
    public string unitName;
    public int attackPower;
    public int attackSpeed;
    public int moveSpeed;
    public int health;
    public int level;
    public Sprite unitSprite;
}


public class UnitLevelUpUIInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitNameText_B, _unitNameText_F;
    [SerializeField] private TextMeshProUGUI _unitStatInfoText;
    [SerializeField] private Image _unitImage;
    [SerializeField] private Button _unitLevelUpBtn;

    public void InfoPanelSet(UnitLevelUpInfoClass ULUI, UnitLevelClass unitLevel)
    {
        _unitNameText_B.SetText(ULUI.unitName);
        _unitNameText_F.SetText(ULUI.unitName);
        _unitImage.sprite = ULUI.unitSprite;


        _unitStatInfoText.SetText(StatTextSet(ULUI.attackPower, ULUI.attackSpeed, ULUI.moveSpeed, ULUI.health, unitLevel));
    }

    public string StatTextSet(int attackPower, int attackSpeed, int moveSpeed, int health, UnitLevelClass unitLevel)
    {
        string info = $"" +
            $"ü�� : {unitLevel.health}<size=30>(<#60D671>+{health}</color>)</size>\n" +
            $"���ݷ� : {unitLevel.attackPower}<size=30>(<#60D671>+{attackPower}</color>)</size>\n" +
            $"���ݷ� : {unitLevel.attackSpeed}<size=30>(<#60D671>+{attackSpeed}</color>)</size>\n" +
            $"�̵��ӵ� : {unitLevel.moveSpeed}<size=30>(<#60D671>+{moveSpeed}</color>)</size>";

        return info;

    }
}

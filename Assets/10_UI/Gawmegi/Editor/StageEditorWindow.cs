using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class StageEditorWindow : EditorWindow
{

    [Header("Enemy")]
    private IntegerField _enemyCount;
    private EnumField _useEnemyType;
    private ObjectField _enemyList;
    private EnemyEnum[] _haveEnemyType;


    [Header("Stage")]
    private TextField _stageName;
    private IntegerField _stageChapter;
    private IntegerField _stageNumber;
    private Vector2Field _stageSize;
    private ObjectField _tile;


    [SerializeField]private VisualTreeAsset m_VisualTreeAsset = default;
    [SerializeField] private EnemyListSO enemyListSO = default;
    [SerializeField] private ToolInfoSO toolInfoSO = default;

    private Button _createBtn;
    private VisualElement _btnContainer;
    private Vector2 pVec2;

    [MenuItem("Tools/StageEditorWindow")]
    public static void ShowWindow()
    {
        StageEditorWindow wnd = GetWindow<StageEditorWindow>();
        wnd.titleContent = new GUIContent("StageManager");
        wnd.minSize = new Vector2(350, 400);
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        VisualElement content = m_VisualTreeAsset.Instantiate();
        content.style.flexGrow = 1;
        root.Add(content);

        _stageSize = root.Q<Vector2Field>("StageSize");
        _btnContainer = root.Q<VisualElement>("BtnContainer");

        Initalize(root);

    }

    private void Initalize(VisualElement root)
    {
        
        _createBtn = root.Q<Button>("SOCreatBtn");
        _stageName = root.Q<TextField>("StageName");
        _enemyCount = root.Q<IntegerField>("EnemyCount");
        _useEnemyType = root.Q<EnumField>("EnumField");
        _enemyList = root.Q<ObjectField>("EnemyList");
        _stageChapter = root.Q<IntegerField>("StageChapter");
        _stageNumber = root.Q<IntegerField>("StageNumber");
        _tile = root.Q<ObjectField>("Tile");

        _createBtn.clicked += SOCreate;
    }

    private void SOCreate()
    {
        StageDataSO stageSO = ScriptableObject.CreateInstance<StageDataSO>();
        stageSO.enemyList = _enemyList.value as EnemyListSO;
        stageSO.tile = _tile.value as RuleTile;
        stageSO.stageName = _stageName.value;
        stageSO.enemyCount = _enemyCount.value;
        stageSO.haveEnemyType = _haveEnemyType;
        stageSO.stageChapter = _stageChapter.value;
        stageSO.stageNumber = _stageNumber.value;
        stageSO.stageSize = _stageSize.value;

        string fileName = $"{_stageName.value}_stageSO.asset";
        string filePath = $"{toolInfoSO.StageSOFolder}";

        CreateForderinfoNotExist(filePath);
        AssetDatabase.CreateAsset(stageSO, $"{filePath}/{fileName}");

    }

    private void Update()
    {
        if (_stageSize.value != pVec2)
        {
            _btnContainer.Clear();
            

            for (int y = 0;y < _stageSize.value.y;y++)
            {
                VisualElement rowContainer = new VisualElement();
                rowContainer.style.flexDirection = FlexDirection.Row;
                _btnContainer.Add(rowContainer);

                for (int x = 0; x < _stageSize.value.x; x++)
                {
                    Button btn = new Button();
                    btn.AddToClassList("stage-btn");
                    btn.clicked += () =>
                    {
                        btn.AddToClassList("stage-enemy-click-btn");
                    };
                    rowContainer.Add(btn);
                }
            }
        }

        pVec2 = _stageSize.value;
    }

    private void CreateForderinfoNotExist(string fullPath)
    {
        if (!System.IO.Directory.Exists(fullPath))
            System.IO.Directory.CreateDirectory(fullPath);
    }
}

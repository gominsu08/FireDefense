using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(Rigidbody2D))]
public class AstarAgent : MonoBehaviour, IAgentComponent
{
    public float moveSpeed;
    public float stoppingDistance = 0.1f;
    [SerializeField] private bool _cornerCheck = true;
    [SerializeField] private bool _lineDebug = true;

    private Vector3Int _currentPos, _destination;
    private Vector3 _worldDestination;

    [SerializeField] private MapInfoSO _map;
    public MapInfoSO Map => _map;

    #region Astar variables
    private PriorityQueue<AstarNode> _openList;
    private List<AstarNode> _closeList;
    private List<Vector3> _rountePath = new List<Vector3>();
    public List<Vector3> RoutePath => _rountePath;

    private int _currentIndex;
    #endregion

    private Agent _agent;
    private AgentMovement _movement;
    private PathLineDrawer _lineDrawer;

    public void Initialize(Agent agent)
    {
        _agent = agent;
        _lineDrawer = transform.Find("PathDrawer").GetComponent<PathLineDrawer>();
        _lineDrawer.SetActiveLine(_lineDebug);
    }
    public bool SetDestination(Vector3 destination)
    {
        _worldDestination = destination;
        _currentPos = Map.GetTilePosFromWorldPos(transform.position);
        _destination = Map.GetTilePosFromWorldPos(destination);

        _rountePath = CalcRoute();
        _currentIndex = 0;

        if(_rountePath.Count > 0 && _lineDebug)
        {
            _lineDrawer.DrawLine(_rountePath.ToArray());
        }
        return _rountePath.Count > 0;
    }
    private void FixedUpdate()
    {
        CheckToMove();
    }

    private void CheckToMove()
    {
        if(_currentIndex >= _rountePath.Count)return;

        Vector3 pos = _rountePath[_currentIndex];
        Vector3 direction = pos - transform.position;

        if(direction.magnitude < stoppingDistance)
        {
            _currentIndex++;
            if(_currentIndex >= _rountePath.Count)
            {
                _movement.SetVelocity(Vector2.zero);//µµÂø
                return;
            }
        }
        _movement.SetVelocity(direction.normalized * moveSpeed);
    }

    #region Astar Algorithm
    private List<Vector3> CalcRoute()
    {
        _openList = new PriorityQueue<AstarNode>();
        _closeList = new List<AstarNode>();

        _openList.Push(
            new AstarNode { 
                pos = _currentPos, 
                parent = null, 
                G = 0, F = CalH(_currentPos)
            }
         );

        bool result = false;
        while( _openList.Count > 0)
        {
            AstarNode next = _openList.Pop();
            FindOpenList(next);
            _closeList.Add(next);

            if(next.pos == _destination)
            {
                result = true; 
                break;
            }
        }
        List<Vector3> routePath = new List<Vector3>();
        if (result)
        {
            AstarNode lastNode = _closeList[^1];
            while(lastNode.parent != null)
            {
                routePath.Add(Map.GetCellCenterToWorld(lastNode.pos));
                lastNode = lastNode.parent;
            }
            routePath.Reverse();
        }
        
        return routePath;
    }

    private void FindOpenList(AstarNode node)
    {
        for(int i = -1 ; i <= 1; i++)
        {
            for(int j = -1 ; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                Vector3Int nextPos = node.pos + new Vector3Int(j, i);

                AstarNode nextNode = _closeList.Find(x => x.pos == nextPos);
                if (nextNode != null) continue;



                if(Map.CanMove(nextPos))
                {
                    float g = (nextPos - nextPos).magnitude + node.G;
                    nextNode = new AstarNode
                    {
                        pos = nextPos,
                        parent = node,
                        G = g,
                        F = g + CalH(nextPos)
                    };

                    AstarNode exist = _openList.Contains(nextNode);

                    if(exist != null)
                    {
                        if(nextNode.G < exist.G)
                        {
                            exist.G = nextNode.G;
                            exist.F = nextNode.F;
                            exist.parent = nextNode.parent;
                        }
                    }
                    else
                    {
                        _openList.Push(nextNode);
                    }
                }
            }
        }
    }

    private float CalH(Vector3Int currentPos)
    {
        Vector3Int distance = _destination - currentPos;
        return distance.magnitude;
    }
    #endregion
}

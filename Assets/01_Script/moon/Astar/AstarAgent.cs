using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AstarAgent : MonoBehaviour
{
    public float moveSpeed;
    public float stoppingDistance = 0.1f;
    [SerializeField] private bool _cornerCheck = true;
    [SerializeField] private bool _lineDebug = true;

    private Vector3Int _currentPos, _destination;
    private Vector3 _worldDestination;

    #region Astar variables
    private PriorityQueue<AstarNode> _openList;
    private List<AstarNode> _closeList;
    private List<Vector3> _rountePath = new List<Vector3>();
    public List<Vector3> RoutePath => _rountePath;

    private int _currentIndex;
    #endregion

    private Agent _agent;
    private PathLineDrawer _lineDrawer;

    public void Initialize(Agent agent)
    {
        _agent = agent;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSetting : MonoBehaviour
{
    private Tilemap _floor, _collider;
    [SerializeField]MapInfoSO _mapInfoSO;
    private void Awake()
    {
        _floor = transform.Find("FloorTile").GetComponent<Tilemap>();
        _collider = transform.Find("ColliderTile").GetComponent<Tilemap>();
    }
    private void Start()
    {
        _mapInfoSO.Initialize(_floor, _collider);
    }
}

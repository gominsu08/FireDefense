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
        _floor = transform.Find("MainTile").GetComponent<Tilemap>();
        _collider = transform.Find("Wall").GetComponent<Tilemap>();
        _mapInfoSO.Initialize(_floor, _collider);
    }
}

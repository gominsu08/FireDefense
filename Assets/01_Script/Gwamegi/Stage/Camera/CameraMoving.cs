using Cinemachine;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [Header("Min / Max")]
    [SerializeField] private Transform minTransform;
    [SerializeField] private Transform maxTransform;

    [Header("")]
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _zoomAmount = 2;
    [SerializeField] private CinemachineVirtualCamera _vCam;

    [SerializeField] private float _minOrthoSize = 10f;
    [SerializeField] private float _maxOrthoSize = 30f;
    [SerializeField] private float _orthoSize, _targetOrthoSize;

    [SerializeField] private float _camereScrollSpeed = 20f;

    private void Start()
    {
        _orthoSize = _vCam.m_Lens.OrthographicSize;
    }
    private void Update()
    {
        ZoomScreen();
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(x, y).normalized;

        transform.position += (Vector3)moveDir * _moveSpeed * Time.deltaTime;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minTransform.position.x, maxTransform.position.x),
            Mathf.Clamp(transform.position.y, minTransform.position.y, maxTransform.position.y));
    }

    private void ZoomScreen()
    {
        _targetOrthoSize -= Input.mouseScrollDelta.y * _zoomAmount;
        _targetOrthoSize = Mathf.Clamp(_targetOrthoSize, _minOrthoSize, _maxOrthoSize);

        _orthoSize = Mathf.Lerp(_orthoSize, _targetOrthoSize, Time.deltaTime * _camereScrollSpeed);

        _vCam.m_Lens.OrthographicSize = _orthoSize;
    }
}

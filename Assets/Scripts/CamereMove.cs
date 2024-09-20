using UnityEngine;

public class CamereMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {   
        _camera.transform.position = _target.position + _offset;
    }
}

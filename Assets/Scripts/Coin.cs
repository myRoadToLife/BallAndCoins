using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, _speedRotation * Time.deltaTime, 0));
    }
}

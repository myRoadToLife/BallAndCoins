using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    [SerializeField] private float _forceMove = 14f;
    [SerializeField] private float _forceJump = 5f;

    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private Transform _startPosition;

    private Rigidbody _rigidbody;

    private float _xInput;
    private float _yInput;

    public int Coins { get; private set; }

    private void Awake()
    {
        InitInstance();

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UserInput();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            AddCoins();
            coin.gameObject.SetActive(false);
        }
    }
    private void InitInstance()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Move()
    {
        _rigidbody.AddForce(_xInput * _forceMove, _rigidbody.velocity.y, _yInput * _forceMove, ForceMode.Force);
    }

    private void UserInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
        }
    }

    public void AddCoins()
    {
        Coins++;
        _scoreText.text = Coins.ToString("—чет: " + "00");
    }

    public void CoinCountReset()
    {
        Coins = 0;
    }

    public void StartPositionAndVelociti()
    {
        transform.position = _startPosition.position;
        _rigidbody.velocity = new Vector3(0f, 0f, 0f);
    }

}

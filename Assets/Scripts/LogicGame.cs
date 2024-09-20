using TMPro;
using UnityEngine;

public class LogicGame : MonoBehaviour
{

    [SerializeField] private TMP_Text _timerLable;
    [SerializeField] private TMP_Text _gameOutcomeLable;
    [SerializeField] private TMP_Text _restartGameLable;
    [SerializeField] private TMP_Text _needCoinsLable;

    [SerializeField] private int _coinsCountToWin;
    [SerializeField] private float _allowedTime;

    private Coin[] _allObjectsCoin;

    private float _time;
    private float _stopPlaytime = 0.0f;
    private float _startPlaytime = 1.0f;

    private string _winText = "Вы победили!";
    private string _loseText = "Вы проиграли!";
    private string _restartGameText = "Для рестарта нажмите клавишу R";

    private void Start()
    {
        _allObjectsCoin = FindObjectsOfType<Coin>();

        _time = _allowedTime;

        _needCoinsLable.text = _coinsCountToWin.ToString("Собери: " + "00");
    }

    private void Update()
    {
        Timer();

        ConditionForVictory();
        ConditionForLosing();
        ConditionForRestartGame();
    }

    private void ConditionForRestartGame()
    {
        _restartGameLable.text = _restartGameText;

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void ConditionForVictory()
    {
        if (_time > 0 && Ball.Instance.Coins >= _coinsCountToWin)
        {
            ViewText(Color.green, _winText);
            Time.timeScale = _stopPlaytime;
        }
    }

    private void ConditionForLosing()
    {
        if (_time == 0 && Ball.Instance.Coins != _coinsCountToWin)
        {
            ViewText(Color.red, _loseText);
            Time.timeScale = _stopPlaytime;
        }
    }

    private void EnableAllObjectsCoin()
    {

        foreach (Coin obj in _allObjectsCoin)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
            }
        }
    }
    private void Timer()
    {
        _timerLable.text = _time.ToString("Время :" + " 00.00");

        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else if (_time < 0)
        {
            _time = 0;
        }
    }

    private void ViewText(Color color, string massage)
    {
        _gameOutcomeLable.color = color;
        _gameOutcomeLable.text = massage;
    }

    private void RestartGame()
    {
        EnableAllObjectsCoin();
        _time = _allowedTime;
        _timerLable.text = null;
        _gameOutcomeLable.text = null;
        Time.timeScale = _startPlaytime;
        Ball.Instance.CoinCountReset();
        Ball.Instance.StartPositionAndVelociti();
    }
}

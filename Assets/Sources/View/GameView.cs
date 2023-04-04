using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private TMP_Text _money;

    public event Action GameOver;

    public event Action TakedMoney;

    private void OnEnable()
    {
        _player.Died += PlayerDie;
        _player.TakedMoney += OnTakeMoney;
    }

    private void OnDisable()
    {
        _player.Died -= PlayerDie;
        _player.TakedMoney -= OnTakeMoney;
    }

    public void LoadMenu(string scene)
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeMoneyCount(int count)
    {
        _money.text = count.ToString();
    }

    private void PlayerDie()
    {
        GameOver?.Invoke();
    }

    private void OnTakeMoney()
    {
        TakedMoney?.Invoke();
    }
}

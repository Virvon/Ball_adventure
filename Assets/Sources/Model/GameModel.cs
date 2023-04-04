using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallAdventure.Model
{
    public class GameModel
    {
        private string _menuScene = "Assets/Scenes/Menu";

        public int Money { get; private set; }

        public event Action LoadedMenuScene;
        public event Action MoneyCoutnChanged;

        public string MenuScene => _menuScene;

        public void FinishGame()
        {
            LoadedMenuScene?.Invoke();
        }

        public void TakeMoney()
        {
            Money++;

            MoneyCoutnChanged?.Invoke();
        }
    }
}

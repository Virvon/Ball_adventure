using System;

namespace BallAdventure.Model
{
    public class GameModel
    {
        public int Money { get; private set; }

        public string MenuScene => _menuScene;

        private string _menuScene = "Assets/Scenes/Menu";

        public event Action LoadedMenuScene;

        public event Action MoneyCoutnChanged;

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

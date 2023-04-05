using BallAdventure.Model;

public class GamePresenter : IPresenter
{
    private GameView _view;
    private GameModel _model;

    public GamePresenter(GameView view, GameModel model)
    {
        _view = view;
        _model = model;
    }

    public void OnEnable()
    {
        _view.GameOver += OnGameOver;
        _view.TakedMoney += OnTakeMoney;

        _model.LoadedMenuScene += OnLoadMenuScene;
        _model.MoneyCoutnChanged += OnMoneyCountChanged;
    }

    public void OnDisable()
    {
        _view.GameOver -= OnGameOver;
        _view.TakedMoney -= OnTakeMoney;

        _model.LoadedMenuScene -= OnLoadMenuScene;
        _model.MoneyCoutnChanged -= OnMoneyCountChanged;
    }

    private void OnGameOver()
    {
        _model.FinishGame();
    }

    private void OnLoadMenuScene()
    {
        _view.LoadMenu(_model.MenuScene);
    }

    private void OnTakeMoney()
    {
        _model.TakeMoney();
    }

    private void OnMoneyCountChanged()
    {
        _view.ChangeMoneyCount(_model.Money);
    }
}

namespace SeaBatleExample;

public class GameController
{
    private GameLogicModel GameLogicModel;
    private IView View;

    public GameController(GameLogicModel gameLogicModel, IView view)
    {
        GameLogicModel = gameLogicModel;
        View = view;
    }

    public void Start()
    {
        GameLogicModel.start();
        View.Show();
    }
}
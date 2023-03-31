namespace SeaBatleExample;

public class GameLogicModel
{
    private readonly BattleField _userBattleField;
    private readonly BattleField _enemyBattleField;

    public delegate void CellChangeStateDelegate(int x, int y);

    public delegate void GameStateDelegate();

    public event CellChangeStateDelegate UserShipWoundedAction;
    public event CellChangeStateDelegate UserShipKilledAction;
    public event CellChangeStateDelegate UserMissShotAction;
    
    public event CellChangeStateDelegate EnemyShipWoundedAction;
    public event CellChangeStateDelegate EnemyShipKilledAction;
    public event CellChangeStateDelegate EnemyMissShotAction;

    public event GameStateDelegate GameEndEvent;
    public event GameStateDelegate GameStartEvent;

    public GameLogicModel(BattleField userBattleField, BattleField enemyBattleField)
    {
        _userBattleField = userBattleField;
        _enemyBattleField = enemyBattleField;
    }

    public void start()
    {
        _userBattleField.init();
        _enemyBattleField.init();
        GameStartEvent();
    }
    

    public void UserShot(int x, int y)
    {
        var ship = _enemyBattleField._Ships.Find(ship => ship.GetCell(x, y) != null);
        if (ship == null)
        {
            UserMissShotAction(x, y);
            return;
        }

        ship.Open(x, y);
        if (ship.IsDead())
        {
            UserShipKilledAction(x, y);
        }
        else
        {
            UserShipWoundedAction(x, y);
        }

        CheckEnd(_enemyBattleField);
    }

    public void EnemyShot(int x, int y)
    {
        var ship = _userBattleField._Ships.Find(ship => ship.GetCell(x, y) != null);
        if (ship == null)
        {
            EnemyMissShotAction(x, y);
            return;
        }

        ship.Open(x, y);
        if (ship.IsDead())
        {
            EnemyShipKilledAction(x, y);
        }
        else
        {
            EnemyShipWoundedAction(x, y);
        }

        CheckEnd(_userBattleField);
    }

    private void CheckEnd(BattleField battleField)
    {
        if (battleField._Ships.All(ship => ship.IsDead()))
        {
            GameEndEvent();
        }
    }
}
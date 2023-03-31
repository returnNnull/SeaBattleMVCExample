namespace SeaBatleExample;

public interface IView
{
    void UserShipWoundedAction(int x, int y);
    void UserShipKilledAction(int x, int y);
    void UserMissShotAction(int x, int y);
    void EnemyShipWoundedAction(int x, int y);
    void EnemyShipKilledAction(int x, int y);
    void EnemyMissShotAction(int x, int y);

    void GameEndEvent();
    void GameStartEvent();

    void Show();
    void Hide();
    void Close();

}
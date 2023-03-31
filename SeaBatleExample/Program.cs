// See https://aka.ms/new-console-template for more information

using SeaBatleExample;

GameLogicModel gameLogicModel = new(new BattleField(), new BattleField());
IView view = new ViewMock();

gameLogicModel.GameEndEvent += view.GameEndEvent;
gameLogicModel.GameStartEvent += view.GameStartEvent;

gameLogicModel.EnemyMissShotAction += view.EnemyMissShotAction;
gameLogicModel.EnemyShipKilledAction += view.EnemyShipKilledAction;
gameLogicModel.EnemyShipWoundedAction += view.EnemyShipWoundedAction;

gameLogicModel.UserMissShotAction += view.UserMissShotAction;
gameLogicModel.UserShipKilledAction += view.UserShipKilledAction;
gameLogicModel.UserShipWoundedAction += view.UserShipWoundedAction;

var gameController = new GameController(gameLogicModel, view);
gameController.Start();


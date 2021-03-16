using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : FSM<BattleSystem>
{
    #region PRIVATE VARIABLES

    private Player _player;

    private Creature _enemy;

    private bool _endPhase;

    private int _currentLevel = 0;

    [SerializeField] private DbEnemy _data;
    #endregion

    #region PROPERTIES
    public bool EndPahse { get => _endPhase; set => _endPhase = value; }
    public Creature Enemy { get => _enemy; }
    public Player Player { get => _player; }
    #endregion

    #region OWN METHODS

    public void Ok()
    {
        if (!_endPhase) return;

        ChangeAction(GameManager.Instance._enemyTurn);
    }
    
    public void SetPlayer(ICharacter player)
    {
        _player = (Player)player;
    }
    public void SetEnemy()
    { 
        if(_enemy == null)
        {
            _currentLevel++;

            _enemy = new Creature(_data.Enemys[0]);

            FindObjectOfType<HudController>().TextLevel(_currentLevel);
        } 
    } 
    public void DestroyEnemy()
    {
        Destroy(_enemy.Character.gameObject);
        _enemy = null;
    }
    #endregion
}

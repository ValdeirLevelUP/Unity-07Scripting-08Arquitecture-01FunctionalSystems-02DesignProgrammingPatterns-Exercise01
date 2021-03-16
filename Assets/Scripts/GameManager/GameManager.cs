using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BattleSystem _fsm;

    public Player Player;

    public BeginningPhase _beginningPhase;

    public EnemyTurn _enemyTurn;

    public PlayerTurn _playerTurn;

    public EndPhase _endPhase;

    [SerializeField] CharacterData _playerData;

    public static GameManager Instance
    {
        get => _instance;
    } 
    protected static GameManager _instance; 

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        _fsm = GetComponent<BattleSystem>(); 

        Player = new Player(_playerData);
    }

    private void Start()
    { 

        _fsm.SetPlayer(Player);

        _fsm.SetEnemy();

        _fsm.ChangeAction(_beginningPhase);
    }
    private void Update()
    {
        _fsm.UpdateAction();
    }
}

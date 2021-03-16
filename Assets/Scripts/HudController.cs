using UnityEngine;
using UnityEngine.UI;

public delegate Sprite OnSelectSkill(int value);
public class HudController : MonoBehaviour
{
    #region Player UI  

    [SerializeField] private Image _playerIcon1;

    [SerializeField] private Button _playerButton1;

    [SerializeField] private Image _playerIcon2;

    [SerializeField] private Button _playerButton2; 

    [SerializeField] private Image _playerIcon3;

    [SerializeField] private Button _playerButton3;
    #endregion

    #region Enemy UI

 
    [SerializeField] private Image _enemyIcon1; 

    [SerializeField] private Image _enemyIcon2;  

    [SerializeField] private Image _enemyIcon3;
    #endregion 

    [SerializeField] private Text _level;

    public event OnSelectSkill getSkillPlayer;

    private void Awake()
    {
        _playerButton1.onClick.AddListener(() => _playerIcon1.sprite = getSkillPlayer?.Invoke(0));

        _playerButton2.onClick.AddListener(() => _playerIcon2.sprite = getSkillPlayer?.Invoke(1));

        _playerButton3.onClick.AddListener(() => _playerIcon3.sprite = getSkillPlayer?.Invoke(2)); 
    }

    private void OnEnable()
    {
        getSkillPlayer += GameManager.Instance.Player.SelectSkills;
    }
    private void OnDisable()
    {
        getSkillPlayer -= GameManager.Instance.Player.SelectSkills; 
    }

    public void SetIconEnemy(int value, Sprite icon)
    {
        switch (value)
        {
            case 0:
                _enemyIcon1.sprite = icon;
                break;
            case 1:
                _enemyIcon2.sprite = icon;
                break;
            case 2:
                _enemyIcon3.sprite = icon;
                break;
        }
    }

    public void TextLevel(int value)
    {
        _level.text = value.ToString();
    }

}

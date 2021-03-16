using System.Collections.Generic;
using UnityEngine;

public class Creature : ICharacter
{
    #region PRIVATE VARIABLES

    private float _currentLife;

    private float _currentActionPoints;

    private SpriteRenderer _enemy;

    private bool _def;

    private CharacterData _data;

    private List<AbstractSkill> _selectedSkills = new List<AbstractSkill>(3);
    #endregion

    #region PROPERTIES
    public float Life { get => _currentLife; set => _currentLife = value; }

    public bool Def { get => _def; set => _def = value; }

    public Transform Character => _enemy.transform;

    public CharacterData Data => _data; 
    #endregion

    public Creature(CharacterData data)
    {
        _currentLife = data.MaxLife;

        _currentActionPoints = data.MaxActionPoint;

        _data = data;

        _enemy = new GameObject().AddComponent<SpriteRenderer>();

        _enemy.sprite = data.CreatureIcon;

        _enemy.transform.localScale = new Vector3(5, 5, 0);

        _enemy.transform.SetParent(GameObject.Find("EnemySpawnPosition").transform);

        while (_selectedSkills.Count < 3)
        {
            AbstractSkill skill = _data.Actions[Random.Range(0, _data.Actions.Count)];

            if (_currentActionPoints - skill.ActionPointCost > 0)
            {
                _selectedSkills.Add(skill);
            } 
        }
    }

    #region OWN METHODS 

    public void TakeDamage(float amount)
    {
        _currentLife -= (_def) ? amount / _data.Def : amount;
    }
    public List<AbstractSkill> GetSkills() => _selectedSkills;

    public Sprite SelectSkills(int value)
    { 
        if(_selectedSkills.Count == 0)
        {
            while (_selectedSkills.Count < 3)
            {
                AbstractSkill skill = _data.Actions[Random.Range(0, _data.Actions.Count)];

                if (_currentActionPoints - skill.ActionPointCost > 0)
                {
                    _selectedSkills.Add(skill);
                }
            }
        }
        return _selectedSkills[value].Icon;
    }


    #endregion
}

using System.Collections.Generic;
using UnityEngine;

public class Player : ICharacter
{
    #region PRIVATE VARIABLEs

    private float _currentLife;

    private float _currentActionPoints;

    private CharacterData _data; 

    private bool _def;

    private List<AbstractSkill> _selectedSkills = new List<AbstractSkill>();

    #endregion
    public float Life { get => _currentLife; set => _currentLife = value; }

    public bool Def { get => _def; set => _def = value; }

    public CharacterData Data => _data;  
 
    public Player(CharacterData data)
    {
        _data = data;

        _currentLife = _data.MaxLife;

        _currentActionPoints = _data.MaxActionPoint;

        while (_selectedSkills.Count < 3)
        {
            _selectedSkills.Add(_data.Actions[0]);
        }
    }

    public List<AbstractSkill> GetSkills()
    {
        return _selectedSkills;
    } 
    public void TakeDamage(float amount)
    {
        _currentLife -= (_def) ? amount / _data.Def: amount;
    }

    public Sprite SelectSkills(int value)
    { 
        for (int i = 0; i < _data.Actions.Count; i++)
        {
            if (_selectedSkills[value] == _data.Actions[i])
            {
                if (i == _data.Actions.Count - 1)
                {
                    _selectedSkills[value] = _data.Actions[0];
                }
                else
                {
                    _selectedSkills[value] = _data.Actions[i + 1];

                    _currentActionPoints -= _data.Actions[i + 1].ActionPointCost;

                    break;
                }
            }
        }
        return _selectedSkills[value].Icon;
    }
    public void ResetSkills()
    {
        _selectedSkills = new List<AbstractSkill>();
        for (int i = 0; i < 3; i++)
        {
            _selectedSkills.Add(_data.Actions[0]);
        }
    }
}

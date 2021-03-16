using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float _maxLife;

    [SerializeField] private float _maxActionPoint;

    [SerializeField] private float _def;

    [SerializeField] private float _reg;

    [SerializeField] private Sprite _creatureIcon;

    [SerializeField] private List<AbstractSkill> _actions;

    public float MaxLife { get => _maxLife; }
    public float MaxActionPoint { get => _maxActionPoint; }
    public float Def { get => _def; }
    public float Reg { get => _reg; } 
    public Sprite CreatureIcon { get => _creatureIcon; } 
    public List<AbstractSkill> Actions => _actions;
}

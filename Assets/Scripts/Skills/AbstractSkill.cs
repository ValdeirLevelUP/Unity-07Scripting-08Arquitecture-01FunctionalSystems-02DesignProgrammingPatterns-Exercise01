using UnityEngine;

public abstract class AbstractSkill : ScriptableObject, ICommand, ICon,ICost
{
    [SerializeField] bool _selfTarge;

    [SerializeField] private Sprite _icon;

    [SerializeField] private float _actionPointCost;
    public Sprite Icon => _icon; 
    public float ActionPointCost => _actionPointCost; 
    public bool SelfTarget => _selfTarge; 
    public virtual void Execute(ICharacter target)
    {
        Debug.Log($"Action {GetType().ToString()}");
    }
}

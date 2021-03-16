using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Data/Db")]
public class DbEnemy : ScriptableObject
{
    [SerializeField] private List<CharacterData> _enemyData = new List<CharacterData>();

    public List<CharacterData> Enemys { get => _enemyData; }
}

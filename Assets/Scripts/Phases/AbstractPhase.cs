using System.Collections; 
using UnityEngine;

public abstract class AbstractPhase<T> : ScriptableObject
{

    public virtual IEnumerator Enter(T fsm)  
    {
        Debug.Log($"Entrando no {GetType().ToString()}"); 
        yield break;
    }
    public abstract void Execute(T fsm);

    public virtual  IEnumerator Exit(T fsm)
    {
        Debug.Log($"Saindo do {GetType().ToString()}"); 
        yield break;
    }
}

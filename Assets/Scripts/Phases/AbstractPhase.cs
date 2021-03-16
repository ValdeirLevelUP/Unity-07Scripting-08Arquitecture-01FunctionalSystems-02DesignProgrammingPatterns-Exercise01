using System.Collections; 
using UnityEngine;

public abstract class AbstractPhase<T> : ScriptableObject
{

    public virtual IEnumerator Enter(T fsm)  
    {
        Debug.Log($"Enter {GetType().ToString()}"); 
        yield break;
    }
    public abstract void Execute(T fsm);

    public virtual  IEnumerator Exit(T fsm)
    {
        Debug.Log($"Exit {GetType().ToString()}"); 
        yield break;
    }
}

using System.Collections; 
using UnityEngine;

public abstract class FSM<T>: MonoBehaviour where T: MonoBehaviour
{    
    protected AbstractPhase<T> _currentAction;

    private T _fsm;

    private bool _transition; 

    public virtual void Awake()
    {
        _fsm = FindObjectOfType<T>();
    }

    public void ChangeAction(AbstractPhase<T> NewAction)
    {
        _transition = true;

        StartCoroutine(changeAction(NewAction));
    }

    private IEnumerator changeAction(AbstractPhase<T> action)
    {   

        if (_currentAction != null)
        { 
            yield return StartCoroutine(_currentAction.Exit(_fsm));
        }

        yield return StartCoroutine(action.Enter(_fsm));

        _currentAction = action;

        _transition = false;

    }

    public void UpdateAction()
    {
        if (!_transition)
        {
            _currentAction.Execute(_fsm);
        }
    }  
}

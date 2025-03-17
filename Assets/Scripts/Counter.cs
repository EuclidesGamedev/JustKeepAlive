using Game.States;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public UnityEvent OnCounterEnding;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
    
    public void EndCounting()
    {
        OnCounterEnding?.Invoke();
    }
}

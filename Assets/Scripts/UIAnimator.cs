using Game.States;
using UnityEngine;
using UnityEngine.Events;

public class UIAnimator : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public UnityEvent OnAnimationEnd;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
    
    public void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}

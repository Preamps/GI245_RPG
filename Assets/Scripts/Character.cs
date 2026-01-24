using UnityEngine;
using UnityEngine.AI;

public enum CharState
{
    Idle, Walk, Attack, Hit, Die
}


public abstract class Character : MonoBehaviour
{
    protected NavMeshAgent navAgent;

    protected Animator anim;
    public Animator Anim { get { return anim; } }

    [SerializeField]
    protected CharState state;
    public CharState State { get { return state; } }

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void SetState(CharState s)
    {
        state = s;
    }

}

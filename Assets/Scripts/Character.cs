using UnityEngine;
using UnityEngine.AI;

public enum CharState
{
    Idle, Walk, Attack, Hit, Die
}


public abstract class Character : MonoBehaviour
{
    protected NavMeshAgent navAgent;

    protected Animation anim;
    public Animation Anim { get { return anim; } }

    [SerializeField]
    protected CharState state;
    public CharState State { get { return state; } }

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
    }
    public void SetState(CharState s)
    {
        state = s;
    }

}

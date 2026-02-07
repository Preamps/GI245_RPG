using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    private Character character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        character = GetComponent<Character>();    
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAnimation(character);
    }

    private void ChooseAnimation(Character c)
    {
        c.Anim.SetBool("IsIdle", false);
        c.Anim.SetBool("IsWalk", false);

        switch (c.State)
        {
            case CharState.Idle:
                c.Anim.SetBool("IsIdle", true);
                break;
            case CharState.Walk:
            case CharState.WalkToEnemy:
                c.Anim.SetBool("IsWalk", true);
                break;
        }
    }
}

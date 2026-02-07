using UnityEngine;

public class AttackAI : MonoBehaviour
{
    private Character myChar;
    [SerializeField]
    private Character curEnemy;

    void Start()
    {
        myChar = GetComponent<Character>();

        if (myChar != null)
            InvokeRepeating("FindAndAttackEnemy", 0f, 1f);
    }

    void Update()
    {
        
    }


    private void FindAndAttackEnemy()
    {
        if (myChar.CurCharTarget == null)
        {
            curEnemy = Formula.FindClosestEnemyChar(myChar);
            if (curEnemy == null)
                return;

            if (myChar.IsMyEnemy(curEnemy.gameObject.tag))
                myChar.ToAttackCharacter(curEnemy);
        }
    }
}

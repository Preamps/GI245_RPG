using UnityEngine;

public static class Formula
{
    public static Character FindClosestEnemyChar(Character me)
    {
        LayerMask charLayer = LayerMask.GetMask("Character");
        Character closestTarget = null;
        float closestDist = 0f;

        RaycastHit[] hits = Physics.SphereCastAll(me.transform.position,
                                                me.FingingRange, Vector3.up, charLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            Character target = hits [i].collider.GetComponent<Character>();

            if (target == null || target.CurHP <= 0 || target == me)
                continue;
            if (!me.IsMyEnemy(target.tag))
                continue;
            float distance = Vector3.Distance(me.transform.position,hits[i].transform.position);
            if (closestTarget == null || distance < closestDist)
            {
                closestTarget = target;
                closestDist = distance;
            }
        }
        return closestTarget;
    }
}

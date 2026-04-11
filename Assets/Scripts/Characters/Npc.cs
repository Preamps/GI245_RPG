using UnityEngine;
using System.Collections.Generic;



public class Npc : Character
{
    [SerializeField]
    private List<Quest> questToGive = new List<Quest>();
    public List<Quest> QuestToGive { get => questToGive; set => questToGive = value; }

    public Quest CheckQuestList(QuestStatus status)
    {
        foreach (Quest q in questToGive)
        {
            if (q.Status == status)
                return q;
        }
        return null;
    }
}

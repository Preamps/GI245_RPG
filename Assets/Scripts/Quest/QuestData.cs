using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Objects/QuestData")]
public class QuestData : ScriptableObject
{
    public int questId;
    public QuestType type;
    public QuestStatus status;
    public string questName;
    public string questDetail;
    public int questItemId;
    public string[] questDialogue;
    public string[] answerNext;
    public string answerAccept;
    public string answerReject;
    public int rewardItemId;
    public int rewardExp;
    public string questionInProgress;
    public string answerFinish;
    public string answerNotFinish; 

}

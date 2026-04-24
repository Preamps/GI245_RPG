using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform selectionBox;
    public RectTransform SelectionBox { get { return selectionBox; } }

    [SerializeField]
    private Toggle togglePauseUnpause;

    [SerializeField]
    private Toggle[] toggleMagic;
    public Toggle[] ToggleMgic { get { return toggleMagic; } }

    [SerializeField]
    private int curToggleMagicID = -1;

    [SerializeField]
    private GameObject blackImage;

    [SerializeField]
    private GameObject inventoryPanel;

    [SerializeField] private GameObject grayImage;

    [SerializeField] private GameObject itemDialog;

    [SerializeField]
    private GameObject itemUIPrefab;

    [SerializeField]
    private GameObject[] slots;

    [SerializeField]
    private ItemDrag curItemDrag;

    [SerializeField]
    private int curSlotId;

    [SerializeField]
    private GameObject downPanel;

    [SerializeField]
    private GameObject npcDialoguePanel;

    [SerializeField]
    private Image npcImage;

    [SerializeField]
    private TMP_Text npcNameText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private int index;

    [SerializeField]
    private GameObject btnNext;

    [SerializeField]
    private TMP_Text btnNextText;

    [SerializeField]
    private GameObject btnAccept;

    [SerializeField]
    private TMP_Text btnAcceptText;

    [SerializeField]
    private GameObject btnReject;

    [SerializeField]
    private TMP_Text btnRejectText;

    [SerializeField]
    private GameObject btnFinish;

    [SerializeField]
    private TMP_Text btnFinishText;

    [SerializeField]
    private GameObject btnNotFinish;

    [SerializeField]
    private TMP_Text btnNotFinishText;

    [SerializeField]
    private Toggle[] toggleAvatar;
    public Toggle[] ToggleAvatar { get { return toggleAvatar; } set { toggleAvatar = value; } }


    public static UIManager instance;

    void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitSlots();
        MapToggleAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            togglePauseUnpause.isOn = !togglePauseUnpause.isOn;
    }

    public void ToggleAI(bool isOn)
    {
        foreach (Character member in PartyManager.instance.Members)
        {
            AttackAI ai = member.gameObject.GetComponent<AttackAI>();
            if (ai != null)
                ai.enabled = isOn;

        }
    }

    public void PauseUnpause(bool isOn)
    {
        Time.timeScale = isOn ? 0 : 1;
    }

    public void ShowMagicToggle()
    {
        if (PartyManager.instance.SelectChars.Count <= 0)
            return;
        Character hero = PartyManager.instance.SelectChars[0];

        for (int i = 0; i < hero.MagicSkills.Count; i++)
        {
            toggleMagic[i].interactable = true;
            toggleMagic[i].isOn = false;
            toggleMagic[i].GetComponentInChildren<Text>().text = hero.MagicSkills[i].Name;
            toggleMagic[i].targetGraphic.GetComponent<Image>().sprite = hero.MagicSkills[i].Icon;
        }

    }

    public void SelectMagicSkill(int i)
    {
        curToggleMagicID = i;
        PartyManager.instance.HeroSelectMagicSkills(i);

    }

    public void IsOnCurToggleMagic(bool flag)
    {
        // เช็คว่า ID ไม่ใช่ -1 และไม่เกินขนาดของ Array ที่มีอยู่
        if (curToggleMagicID >= 0 && curToggleMagicID < toggleMagic.Length)
        {
            toggleMagic[curToggleMagicID].isOn = flag;
        }
        else
        {
            Debug.LogWarning("ยังไม่ได้เลือก Magic ID หรือ ID อยู่นอกขอบเขต!");
        }
    }

    public void toggleInventoryPanel()
    {
        if (!inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(true);
            blackImage.SetActive(true);
            ShowInventory();
        }
        else
        {
            inventoryPanel.SetActive(false);
            blackImage.SetActive(false);
            clearInventory();
        }
    }

    public void clearInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount > 0)
            {
                Transform child = slots[i].transform.GetChild(0);
                Destroy(child.gameObject);
            }
        }
    }

    public void ShowInventory()
    {
        if (PartyManager.instance.SelectChars.Count <= 0)
            return;

        Character hero = PartyManager.instance.SelectChars[0];

        for (int i = 0; i < hero.InventoryItems.Length; i++)
        {
            if (hero.InventoryItems[i] != null)
            {
                GameObject itemObj = Instantiate(itemUIPrefab, slots[i].transform);
                ItemDrag itemDrag = itemObj.GetComponent<ItemDrag>();

                itemDrag.UIManager = this;

                itemDrag.Item = hero.InventoryItems[i];
                itemDrag.IconParent = slots[i].transform;
                itemDrag.Image.sprite = hero.InventoryItems[i].Icon;
            }
        }
    }

    private void InitSlots()
    {
        for (int i = 0; i < InventoryManager.MAXSLOT; i++)
        {
            slots[i].GetComponent<InventorySlot>().ID = i;
        }
    }

    public void SetCurItemInUse(ItemDrag itemDrag, int index)
    {
        curItemDrag = itemDrag;
        curSlotId = index;
    }

    public void ToggleItemDialog(bool flag)
    {
        grayImage.SetActive(flag);
        itemDialog.SetActive(flag);
    }

    public void DeleteItemIcon()
    {
        Destroy(curItemDrag.gameObject);  // ลบไอเท็มที่ถูกลากออกจาก UI
    }
    public void ClickDrinkConsumable()
    {
        InventoryManager.instance.DrinkConsumableItem(curItemDrag.Item, curSlotId);
        DeleteItemIcon();
        ToggleItemDialog(false);
    }

    private void ClearDialogueBox()
    {
        npcImage.sprite = null;

        npcNameText.text = "";
        dialogueText.text = "";

        btnNextText.text = "";
        btnNext.SetActive(false);

        btnAcceptText.text = "";
        btnAccept.SetActive(false);

        btnRejectText.text = "";
        btnReject.SetActive(false);

        btnFinishText.text = "";
        btnFinish.SetActive(false);

        btnNotFinishText.text = "";
        btnNotFinish.SetActive(false);
    }

    private void StartQuestDialougue(Quest quest)
    {
        dialogueText.text = quest.QuestDialogue[index];

        btnNext.SetActive(true);
        btnNextText.text = quest.AnswerNext[index];

        btnAccept.SetActive(false);
        btnReject.SetActive(false);
    }

    private void SetupDialoguePanel(Npc npc)
    {
        index = 0;

        npcImage.sprite = npc.AvatarPic;
        npcNameText.text = npc.CharName;

        Quest inProgressQuest = QuestManager.instance.CheckForQuest(npc, QuestStatus.InProgess);

        if (inProgressQuest != null)
        {
            Debug.Log($"in-progress : {inProgressQuest.QuestName}");
            dialogueText.text = inProgressQuest.QuestionInProgress;

            bool hasItem = QuestManager.instance.CheckIfFinishQuest();
            Debug.Log(hasItem);

            if (hasItem)
            {
                btnFinishText.text = inProgressQuest.AnswerFinish;
                btnFinish.SetActive(true);
            }
            else
            {
                btnNotFinishText.text = inProgressQuest.AnswerNotFinish;
                btnNotFinish.SetActive(true);
            }

        }
        else
        {
            Quest newQuest = QuestManager.instance.CheckForQuest(npc, QuestStatus.New);

            if (newQuest != null)
                StartQuestDialougue(newQuest);

        }
    }

    private void ToggleDialogueBox(bool flag)
    {
        grayImage.SetActive(flag);
        npcDialoguePanel.SetActive(flag);
        togglePauseUnpause.isOn = flag;
    }

    public void PrepareDialogueBox(Npc npc)
    {
        ClearDialogueBox();
        SetupDialoguePanel(npc);
        ToggleDialogueBox(true);
    }
    public void AnswerNext()
    {
        index++;
        dialogueText.text = QuestManager.instance.NextDialogue(index);
        if (QuestManager.instance.CheckLastDialogue(index))
        {
            btnNext.SetActive(false);

            btnAcceptText.text = QuestManager.instance.CurQuest.AnswerAccept;
            btnAccept.SetActive(true);


            btnRejectText.text = QuestManager.instance.CurQuest.AnswerReject;
            btnReject.SetActive(true);
        }
        else
        {
            btnNextText.text = QuestManager.instance.CurQuest.AnswerNext[index];
            btnNext.SetActive(true);

        }
    }
    public void AnswerReject()
    {
        QuestManager.instance.RejectQuest();
        ToggleDialogueBox(false);
    }

    public void AnswerAccept()
    {
        QuestManager.instance.AcceptQuest();
        ToggleDialogueBox(false);
    }

    public void AnswerFinish()
    {
        Debug.Log("Finish Quest");
        bool success = QuestManager.instance.DeliverItem();

        if (success)
        {
            if (QuestManager.instance.NpcGiveReward())
            {
                Debug.Log("Quest Complete");
                ToggleDialogueBox(false);
            }
        }
    }
    public void AnswerNotFinish()
    { 
        Debug.Log("Can't Finish Quest");
        ToggleDialogueBox(false);
    }

    public void MapToggleAvatar()
    {
        foreach (Toggle t in toggleAvatar)
            t.gameObject.SetActive(false);

        for (int i = 0; i < PartyManager.instance.SelectChars.Count; i++)
        {
            toggleAvatar[i].gameObject.SetActive(true);
        }
        toggleAvatar[0].isOn = true;

    }

    public void SelectHeroByAvatar(int i)
    {
        if (toggleAvatar[i].isOn)
        {
            PartyManager.instance.SelectSingleHero(i);
        }
        else
        {
            PartyManager.instance.UnSelectSingleHeroByToggle(i);
        }
    }
}


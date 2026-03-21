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

    [SerializeField]
    private GameObject itemUIPrefab;

    [SerializeField]
    private GameObject[] slots;


    public static UIManager instance;

    void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitSlots();
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
        curToggleMagicID = i ;
        PartyManager .instance.HeroSelectMagicSkills(i);

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
        for (int i = 0; i <slots.Length; i++)
        {
            if (slots[i] .transform.childCount > 0)
            {
                Transform child = slots[i].transform.GetChild(0);
                Destroy(child.gameObject);
            }
        }
    }

    public void ShowInventory()
    {
        if (PartyManager.instance.SelectChars.Count <=0 )
            return;

        Character hero = PartyManager.instance.SelectChars[0];

        for (int i = 0; i < hero.InventoryItems.Length; i++)
        {
            if (hero.InventoryItems[i] != null)
            {
                GameObject itemObj = Instantiate(itemUIPrefab, slots[i].transform);
                ItemDrag itemDrag = itemObj.GetComponent<ItemDrag>();

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

}


using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemPrefabs;
    public GameObject[] ItemPrefabs
    { get { return itemPrefabs; } set { itemPrefabs = value; } }

    [SerializeField]
    private ItemData[] itemData;
    public ItemData[] ItemData
    { get { return itemData; } set { itemData = value; } }

    public const int MAXSLOT = 17;

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Character character, int id)
    {
        Item item = new Item(itemData[id]);

        for (int i = 0; i < character.InventoryItems.Length; i++)
        {
            if (character.InventoryItems[i] == null)
            {
                character.InventoryItems[i] = item;
                return true;
            }
        }
        Debug.Log("Inventory Full");
        return false;
    }

    public void SaveItemInBag(int index, Item item)
    {
        if (PartyManager.instance.SelectChars.Count == 0)
            return;

        PartyManager.instance.SelectChars[0].InventoryItems[index] = item;
        switch (index)
        {
            case 16:
                PartyManager.instance.SelectChars[0].EquipShield(item);
                break;
        }
    }
    public void RemoveItemInBag(int index)
    {
        if (PartyManager.instance.SelectChars.Count == 0  )
            return;

        PartyManager.instance.SelectChars[0].InventoryItems[index] = null;

        switch (index)
        {
            case 16:
                PartyManager.instance.SelectChars[0].UnEquipShield(); 
                break;
        }
    }

    private void SpawnDropItem(Item item, Vector3 pos)
    {
        int id;

        switch (item.Type)
        {
            case ItemType.Consumable:
                id = 1;
                break;
            default: 
                id = 0;
                break;
        }

        GameObject itemObj = Instantiate (ItemPrefabs[id],pos,Quaternion.identity);
        itemObj.AddComponent<ItemPick>();

        ItemPick itemPick = itemObj.GetComponent<ItemPick>();
        itemPick.Inti(item, instance, PartyManager.instance);
    }

    public void SpawnDropInventory(Item[] items, Vector3 pos)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                // สุ่มตำแหน่งรอบๆ จุด pos ในรัศมีไม่เกิน 1 เมตร
                Vector3 randomOffset = Random.insideUnitSphere * 1f;

                // หากต้องการให้ไอเทมกระจายแค่ในแนวราบ (แกน X และ Z) ให้เซต y เป็น 0
                randomOffset.y = 0;

                Vector3 finalPos = pos + randomOffset;

                SpawnDropItem(items[i], finalPos);
            }
        }
    }

    public void DrinkConsumableItem(Item item, int slotId)
    {
        string s = string.Format("Drink: {0}", item.ItemName);
        Debug.Log(s);

        if (PartyManager.instance.SelectChars.Count > 0)
        {
            PartyManager.instance.SelectChars[0].Recover(item.Power);
            RemoveItemInBag(slotId);
        }
    }

}

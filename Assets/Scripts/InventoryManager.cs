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

    public const int MAXSLOT = 16;

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
    }
    public void RemoveItemInBag(int index)
    {
        if (PartyManager.instance.SelectChars.Count == 0  )
            return;

        PartyManager.instance.SelectChars[0].InventoryItems[index] = null;
    }
}

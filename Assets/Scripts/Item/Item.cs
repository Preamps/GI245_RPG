using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipmet,
    Shield,
    Armor,
    Weapon,
    Ammo,
    Quest,
    Other
}
[System.Serializable]
public class Item 
{
    [SerializeField]
    private int id;
    public int ID {  get { return id; } }

    [SerializeField]
    private string itemname;
    public string ItemName { get { return itemname; } }

    [SerializeField]
    private ItemType type;
    public ItemType Type { get { return type; } }

    [SerializeField]

    private Sprite icon;
    public Sprite Icon { get { return icon; } }

    [SerializeField]
    private int power;
    public int Power { get { return power; } }

    [SerializeField]
    private int prefabID;
    public int PrefabID { get { return prefabID; } }

    public Item(ItemData data)
    {
        id = data.id;
        itemname = data.name;
        type = data.type;
        icon = data.icon;
        power = data.power;
        prefabID = data.prefabID;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

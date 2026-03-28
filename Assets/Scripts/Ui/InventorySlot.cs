using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IDropHandler
{
    [SerializeField]
    private int id;
    public int ID
    { get { return id; } set { id = value; } }

    [SerializeField]
    private ItemType itemType;
    public ItemType ItemType
    { get { return itemType; } set { itemType = value; } }

    [SerializeField]
    private InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = InventoryManager.instance;
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject objA = eventData.pointerDrag;
        ItemDrag itemDragA = objA.GetComponent<ItemDrag>();
        InventorySlot slotA = itemDragA.IconParent.GetComponent<InventorySlot>();
        
        if ( itemType == ItemType.Shield)
        {
            if(itemDragA.Item.Type != itemType)
                return;
        }
  
        if (transform.childCount > 0)
        {
            GameObject objB = transform.GetChild(0).gameObject;
            ItemDrag itemDragB = objB.GetComponent<ItemDrag>();
            
            if (slotA.ItemType == ItemType.Shield)
            {
                if (itemDragB.Item.Type != slotA.ItemType)
                    return;
            }

            inventoryManager.RemoveItemInBag(slotA.ID);

            //Set ItemsB on Slot A
            itemDragB.transform.SetParent(itemDragA.IconParent);
            itemDragB.IconParent = itemDragA.IconParent;
            inventoryManager.SaveItemInBag(slotA.ID, itemDragB.Item);

            inventoryManager.RemoveItemInBag(id);
        }
        else
        {
            inventoryManager.RemoveItemInBag(slotA.ID);
        }

        itemDragA.IconParent = transform;
        inventoryManager.SaveItemInBag(id,itemDragA.Item);
    }

}

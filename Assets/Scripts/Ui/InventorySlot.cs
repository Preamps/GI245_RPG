using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IDropHandler
{
    [SerializeField]
    private int id;
    public int ID
    { get { return id; } set { id = value; } }

    [SerializeField]
    private InventoryManager inventoryManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = InventoryManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject objA = eventData.pointerDrag;
        ItemDrag itemDragA = objA.GetComponent<ItemDrag>();
        InventorySlot slotA = itemDragA.IconParent.GetComponent<InventorySlot>();

        //remove Item A form SlotA
        inventoryManager.RemoveItemInBag(slotA.ID);

        if (transform.childCount > 0)
        {
            GameObject objB = transform.GetChild(0).gameObject;
            ItemDrag itemDragB = objB.GetComponent<ItemDrag>();

            //Set ItemsB on Slot A
            itemDragB.transform.SetParent(itemDragA.IconParent);
            itemDragB.IconParent = itemDragA.IconParent;
            inventoryManager.SaveItemInBag(slotA.ID, itemDragB.Item);
        }

        itemDragA.IconParent = transform;
        inventoryManager.SaveItemInBag(id,itemDragA.Item);

  
    }

}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, 
    IBeginDragHandler, IDragHandler,IEndDragHandler,IPointerClickHandler
{
    [SerializeField]
    private Item item;
    public Item Item
    { get { return item; } set { item = value; } }

    [SerializeField]
    private Transform iconParent;
    public Transform IconParent
        { get { return iconParent; } set { iconParent = value; } }

    [SerializeField]
    private Image image;
    public Image Image
    {  get { return image; } set { image = value; } }

    private UIManager uiManager;
    public UIManager UIManager
    { get { return uiManager; } set { uiManager = value; } }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        iconParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position= Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        transform.SetParent(iconParent);
        image.raycastTarget = true;
    }

    private int FindIndexOfSlotParent()
    {
       int id = iconParent.GetComponent<InventorySlot>().ID;
         return id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right Click on Item");
            if (item.Type == ItemType.Consumable)
            {
                uiManager.SetCurItemInUse(this,FindIndexOfSlotParent());
                uiManager.ToggleItemDialog(true);
            }
           
        }
    }

}

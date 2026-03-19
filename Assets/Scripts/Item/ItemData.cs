using UnityEditor.AssetImporters;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType type;
    public Sprite icon;
    public int power;
}

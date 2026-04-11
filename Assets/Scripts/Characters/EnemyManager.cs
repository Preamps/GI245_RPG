using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> monsters;
    public List<Enemy> Monsters
        { get { return monsters; } }

    public static EnemyManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Character m in monsters)
        {
            m.charInit(VFXManager.instance, UIManager.instance, InventoryManager.instance);
        }

        InventoryManager.instance.AddItem(monsters[0], 0); //Health Potion
        InventoryManager.instance.AddItem(monsters[0], 1); //Sword
        InventoryManager.instance.AddItem(monsters[0], 2); //Shield
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

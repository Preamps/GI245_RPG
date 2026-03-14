using UnityEngine;

[System.Serializable]
public class Magic
{
    [SerializeField]
    private int id;
    public int Id { get { return id; } }

    [SerializeField]
    private string name;
    public string Name { get { return name; } }

    [SerializeField] 
    private Sprite icon;
    public Sprite Icon { get { return icon; } }

    [SerializeField]
    private float range;
    public float Range { get { return range; } }

    [SerializeField]
    private int power;
    public int Power { get { return power; } }

    [SerializeField]
    private float loadTime;
    public float LoadTime { get { return loadTime; } }

    [SerializeField]
    private float shootTime;
    public float ShootTime { get {return shootTime; } }

    [SerializeField]
    private int loadId;
    public int LoadID { get { return loadId; } }

    [SerializeField]
    private int shootId;
    public int ShootID { get {return shootId; } }
    
    public Magic (MagicData data)
    {
        id = data.id;
        name = data.name;
        icon =  data.icon;
        range = data.range;
        power = data.power;
        loadTime = data.loadTime;
        shootTime = data.shootTime;
        loadId = data.loadId;
        shootId = data.shootId;
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

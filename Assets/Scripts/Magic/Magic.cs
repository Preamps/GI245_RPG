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
    
    public Magic (int id , string name ,float range ,int power,
        float loadTime, float shootTime,int loadId,int shootId)
    {
        this.id = id;
        this.name = name;
        this.range = range;
        this.power = power;
        this.loadTime = loadTime;
        this.shootTime = shootTime;
        this.loadId = loadId;
        this.shootId = shootId;
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

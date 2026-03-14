using UnityEngine;

public class VFXManager : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject doubleringMarker;
    public GameObject DoubleRingMarker { get {  return doubleringMarker; } }

    [SerializeField]
    private GameObject[] magicVFX;
    public GameObject[] MagicVFX { get { return magicVFX; } }
    [SerializeField]
    private MagicData[] magicDatas;
    public MagicData[] MagicData { get { return magicDatas; } }
    
    public static VFXManager instance;
    void Awake()
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
    public void LoadMagic(int id, Vector3 posA, float time)
    {
        //load magic 
        if (id < 0 || id >= magicVFX.Length || magicVFX[id] == null)
        {
            Debug.LogWarning($"VFX Index {id} ไม่มีอยู่ในระบบ! เช็คจำนวนใน Inspector ด้วยครับ");
            return;
        }

        Vector3 offsetPos = posA + new Vector3(0, 1.2f, 0);

        GameObject objLoad = Instantiate(MagicVFX[id], offsetPos, Quaternion.identity);
        Destroy(objLoad,time);
    }

    public void ShootMagic(int id, Vector3 posA,Vector3 posB, float time)
    {
        //shoot magic 
        if (magicVFX[id] == null)
            return;
        GameObject objShoot = Instantiate(MagicVFX[id], posA, Quaternion.identity);
        objShoot.transform.position = Vector3.LerpUnclamped(posA,posB,time);
        Destroy(objShoot, time);
    }


}

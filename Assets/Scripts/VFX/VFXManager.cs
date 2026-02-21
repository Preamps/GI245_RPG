using UnityEngine;

public class VFXManager : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject doubleringMarker;
    public GameObject DoubleRingMarker { get {  return doubleringMarker; } }

    [SerializeField]
    private GameObject[] magicVFX;
    public GameObject[] MagicVFX { get { return magicVFX; } }
    
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
        if (magicVFX[id] == null )
            return;

        GameObject objLoad = Instantiate(MagicVFX[id], posA, Quaternion.identity);
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

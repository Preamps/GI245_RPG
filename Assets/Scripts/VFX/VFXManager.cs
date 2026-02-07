using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance;
    [SerializeField] private GameObject doubleringMarker;
    public GameObject DoubleRingMarker { get {  return doubleringMarker; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

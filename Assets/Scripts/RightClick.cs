using UnityEngine;

public class RightClick : MonoBehaviour
{
    public static RightClick instance;
    
    private Camera cam;
    private LayerMask layerMask;

    private LeftClick leftClick;

    private void Awake()
    {
        leftClick = GetComponent<LeftClick>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       instance = this;
       cam = Camera.main;
       layerMask = LayerMask.GetMask("Ground", "Character", "Building", "Item");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            TryCammand(Input.mousePosition);
        }
    }
    private void CommandtoWalk(RaycastHit hit,Character c)
    {
        if (c != null)
        {
            c.WalkToPosition(hit.point);
        }
        CreateVFX(hit.point,VFXManager.instance.DoubleRingMarker);
    }

    private void TryCammand(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Ground":
                    CommandtoWalk(hit,leftClick.CurChar); 
                    break;
                case "Enemy":
                    CommandToAttack(hit,leftClick.CurChar);
                    break;
            }
        }
    }
    private void CreateVFX(Vector3 pos , GameObject vfxPrefab)
    {
        if (vfxPrefab == null)
            return;
        Instantiate (vfxPrefab,
            pos+ new Vector3 (0f,0.1f,0f),Quaternion.identity) ;
    }
    private void CommandToAttack(RaycastHit hit, Character c)
    {
        if (c  == null) 
            return;

        Character target = hit.collider.GetComponent<Character>();
        Debug.Log("Attack :" + target);

        if (target != null)
            c.ToAttackCharacter(target);
    }

}

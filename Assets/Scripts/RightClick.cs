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
            }
        }
    }
}

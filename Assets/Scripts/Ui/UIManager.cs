using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform selectionBox;
    public RectTransform SelectionBox { get { return selectionBox; } }

    [SerializeField] 
    private Toggle togglePauseUnpause;

    public static UIManager instance;

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
        if (Input.GetKeyUp(KeyCode.Space)) 
            togglePauseUnpause.isOn = !togglePauseUnpause.isOn;
    }

    public void ToggleAI (bool isOn)
    {
        foreach (Character member in PartyManager.instance.Members)
        {
            AttackAI ai = member.gameObject.GetComponent<AttackAI>();
            if (ai != null)
                ai.enabled = isOn;

        }
    }

    public void PauseUnpause(bool isOn)
    {
        Time.timeScale = isOn ? 0 : 1;
    }
}

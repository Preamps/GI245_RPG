using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private List<Character>members = new List<Character>();
    public List<Character> Members { get { return members; } }

    [SerializeField]
    private List<Character>selectChars = new List<Character>();
    public List<Character> SelectChars { get { return selectChars; } }

    public static PartyManager instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Character c in members)
        {

            c.charInit(VFXManager.instance,UIManager.instance);
            c.MagicSkills.Add(new Magic(0, "Fireball", 10f, 30, 3f, 1f, 0, 1));
        }
        SelectSingleHero(0);

        members[0].MagicSkills.Add(new Magic(0,"Power Glow", 10f, 20, 3f, 1f, 2, 2));
        members[1].MagicSkills.Add(new Magic(0,"Fire Ball", 10f, 35, 3f, 4f, 0, 1));
        UIManager.instance.ShowMagicToggle();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            selectChars[0].IsMagicMode = true;
            selectChars[0].CurMagicCast = selectChars[0].MagicSkills[0];
        }
    }

    public void SelectSingleHero(int i)
    {
        foreach (Character c in selectChars)
            c.ToggleRingSelection(false);

        selectChars.Clear();

        selectChars.Add(members[i]);
        selectChars[0].ToggleRingSelection(true);
    }

    public void HeroSelectMagicSkills(int i)
    {
        if (selectChars.Count <= 0 )
            return;

        selectChars[0].IsMagicMode = true;
        selectChars[0].CurMagicCast = selectChars[0].MagicSkills[i];

    }
}

using UnityEngine;

//[CreateAssetMenu(menuName ="ScriptableObj/heros")]
public class ScriptableObj : ScriptableObject
{
    [SerializeField]
    private string herosName;
    [SerializeField]
    private int dmg;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int level;
    [SerializeField]
    private Sprite[] herosPic;


    public string HerosName
    {
        get
        {
            return herosName;
        }
        set
        {
            herosName = value;
        }
    }
    public int Dmg
    {
        get
        {
            return dmg;
        }
    }
    public int Hp
    {
        get
        {
            return hp;
        }
    }
    public int Level
    {
        get
        {
            return level;
        }
    }

    public Sprite[] HerosPic
    {
        get
        {
            return herosPic;
        }
    }
   
}

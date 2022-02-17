using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        
        instance = this;
        SceneManager.sceneLoaded += Load;
        DontDestroyOnLoad(gameObject);
    }

    //zasoby 
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public player player;
    public weapon weapon;
    public textManager TextManager;


    public int gold;
    public int experience;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        TextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public bool TryUpgradeWeapon()
    {
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if (gold >= weaponPrices[weapon.weaponLevel])
        {
            gold -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }
    public int CurrentLevel()
    {
        int r = 0;
        int add = 0;
        while (experience >= add)
        {
            add += xpTable[r];
            r++;
        }
        if(r == xpTable.Count)
        return r;
        return r;
    }
    public int GetXptoLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;
    }
    public void GrantExp(int exp)
    {
        int currentLevel = CurrentLevel();
        experience += exp;
        if (currentLevel < CurrentLevel())
            OnLevelUp();
    }
    public void OnLevelUp()
    {
        player.OnLevelUp();
    }
    public void Save()
    {
        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("Save", s);
    }
    public void Load(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("Save"))
            return;

        string[] data = PlayerPrefs.GetString("Save").Split('|');

        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        if(CurrentLevel() !=1)
            player.SetLevel(CurrentLevel());
        weapon.SetWeapon(int.Parse(data[3]));
    }
}

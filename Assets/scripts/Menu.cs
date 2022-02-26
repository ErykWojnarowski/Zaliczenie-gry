using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text levelText, hitpointText, goldText, upgradeText, xpText;

    private int currentCharacter = 0;
    public Image characterSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacter++;

            if (currentCharacter == GameManager.instance.playerSprites.Count)
                currentCharacter = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacter--;

            if (currentCharacter < 0)
                currentCharacter = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSprite.sprite = GameManager.instance.playerSprites[currentCharacter];
    }
    public void OnClickUpgrade()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }
    public void UpdateMenu()
    {
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeText.text = "MAX";
        else
            upgradeText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        hitpointText.text = GameManager.instance.player.hitpoints.ToString();
        goldText.text = GameManager.instance.gold.ToString();
        levelText.text = GameManager.instance.CurrentLevel().ToString() ;

        int currentLevel = GameManager.instance.CurrentLevel();
        if (currentLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + "total experience points";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int previousLevelExp = GameManager.instance.GetXptoLevel(currentLevel - 1);
            int currentLevelExp = GameManager.instance.GetXptoLevel(currentLevel);

            int difference = currentLevelExp - previousLevelExp;
            int currentExpIntoLevel = GameManager.instance.experience - previousLevelExp;

            float completionRatio = (float)currentExpIntoLevel / (float)difference;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currentExpIntoLevel.ToString() + " / " + difference;
        }
        
    }
}
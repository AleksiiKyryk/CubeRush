
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public bool collectedRareItem = false;
    public string collectedColor;
    public string skin = "red";

    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }

    public void NextLevel()
    {
        level += 1;
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            level = data.level;
            skin = data.skin;
        }

    }
}

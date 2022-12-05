using UnityEngine;
using UnityEngine.UI;

public class LoadLevels : MonoBehaviour
{
    public Player player;
    public User user;
    
    public GameObject[] btns;

    public void loadGame()
    {
        player.LoadGame();
        user.loadMyself();
    }

    public void loadLevels()
    {
        int level = player.level;
        //Debug.Log(level);
        int available_levels = btns.Length;
        if (available_levels < level)
        {
            player.level = available_levels;
            level = player.level;
        }

        for (int i = 0; i < btns.Length; i++)
        {
            int i_level = i + 1;
            if (i_level <= level)
            {
                //Debug.Log("Showing level : " + btns[i].name);
                btns[i].SetActive(true);
            }
            else
            {
                btns[i].SetActive(false);
            }

        }
    }

    public void Start()
    {
        loadGame();
        Debug.Log("Loaded player level: " + player.level);
        Debug.Log("User has been loaded");
        loadLevels();
        Debug.Log("After loading levels, player level: " + player.level);
    }
}

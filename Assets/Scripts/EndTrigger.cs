using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
	public GameManager gm;

    void OnTriggerEnter () {
        gm.CompleteLevel();
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (gm.player.level == currentLevel - 1)
        {
            gm.player.NextLevel();
        }
        
        gm.player.SaveGame();
        gm.userManager.saveMySelf();

    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameEnded = false;
	public float restartDelay = 2f;

	public GameObject completeLevelUI;

	public Player player;
	public User userManager;
				


	public void CompleteLevel () {
		userManager.loadMyself();
		player.LoadGame();
		if (FindObjectOfType<Player>().collectedRareItem == true)
        {
			Debug.Log("Collected Something cool this round: " + player.collectedColor);
			userManager.addSkin(FindObjectOfType<Player>().collectedColor);

			Debug.Log("You collected blue skin: " + userManager.BlueSkin);
			Debug.Log("You collected black skin: " + userManager.BlackSkin);
			Debug.Log("You collected green skin: " + userManager.GreenSkin);
		}
        else
        {
			Debug.Log("Didnt collect anything this round");
        }
		completeLevelUI.SetActive(true);
		
	}

	public void EndGame (){
		
		if (gameEnded == false){
			Debug.Log("GAME OVER");
			if (FindObjectOfType<Player>().collectedRareItem == true)
            {
				Debug.Log("You collected rare item but fucked up");
            }
            else
            {
				Debug.Log("You collected nothing this game anyway");

            }
			gameEnded = true;

			FindObjectOfType<Player>().collectedRareItem = false;
			Invoke("Restart", restartDelay);
		}
	} 

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	
}

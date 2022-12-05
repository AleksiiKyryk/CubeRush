using UnityEngine;

public class playerCollision : MonoBehaviour
{

	public PlayerMovement pm;
    //public Player player;
    // Start is called before the first frame update
    void OnCollisionEnter (Collision collisionInfo){
    	if (collisionInfo.collider.tag == "Obstacle"){
    		pm.enabled = false;
    		FindObjectOfType<GameManager>().EndGame();
    	}

        
    	
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            string skin = other.name;

            FindObjectOfType<Player>().collectedRareItem = true;
            FindObjectOfType<Player>().collectedColor = skin;
            Debug.Log("Collected item, finish level to get it");
            Destroy(other.gameObject);
        }
    }
}

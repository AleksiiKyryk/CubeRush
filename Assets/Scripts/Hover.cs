
using UnityEngine;

public class Hover : MonoBehaviour
{

    public float delta;
    public float maxHeight = 1.7f;
    public float minHeight = 1.3f;
    bool goingUp = true;

    public GameObject collectible;
    // Update is called once per frame
    void checkIfAboveBorder()
    {
        if (collectible.transform.position.y > maxHeight)
        {
            goingUp = false;
           
        } else if(collectible.transform.position.y < minHeight)
        {
            goingUp = true;
        }
    }
    void Update()
    {
        checkIfAboveBorder();
        

        if (goingUp == true)
        {
            Debug.Log("Goin up, position: " + collectible.transform.position.y);
            Vector3 temp = collectible.transform.position;
            temp.y += delta * Time.deltaTime;
            collectible.transform.position = temp;
        }
        else
        {
            Debug.Log("Goin down, position: " + collectible.transform.position.y);
            Vector3 temp = collectible.transform.position;
            temp.y -= delta * Time.deltaTime;
            collectible.transform.position = temp;
        }
    }
}

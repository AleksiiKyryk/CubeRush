
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    bool swiped = false;
    public float scale = 200; // 75.25
    public string currentActive = "red";
    string last = "red";
    public User user;
    public Player player;
    public GameObject green;
    public GameObject blue;
    public GameObject black;

    public void loadSkins()
    {
        user.loadMyself();
        if (user.BlueSkin)
        {
            blue.SetActive(true);
            last = "blue";
        }

        if (user.GreenSkin)
        {
            green.SetActive(true);
            last = "green";
        }

        if (user.BlackSkin)
        {
            black.SetActive(true);
            last = "black";
        }
    }

    public void setCurrentSkin()
    {
        currentActive = player.skin;
        if(currentActive == "blue")
        {
            swiped = true;
            moveSkins("left");
        } else if (currentActive == "green")
        {
            swiped = true;
            moveSkins("left");
            swiped = true;
            moveSkins("left");
        } else if (currentActive == "black"){
            swiped = true;
            moveSkins("left");
            swiped = true;
            moveSkins("left");
            swiped = true;
            moveSkins("left");
        }
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                
                if (currentActive != last)
                {
                    swiped = true;
                    moveSkins("left");
                }
                

            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                
                if (currentActive != "red")
                {
                    swiped = true;
                    moveSkins("right");
                }
            }
        }
    }

    public void checkCurrentActive()
    {
        GameObject[] skins;
        skins = GameObject.FindGameObjectsWithTag("Collectible");
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].transform.position.x >= 424 && skins[i].transform.position.x < 425)
            {
                currentActive = skins[i].name;
                break;
            }
            else
            {
                Debug.Log("skin " + skins[i].name + " is at x coordinate: " + skins[i].transform.position.x);
            }
        }
        Debug.Log("Current active Skin is: " + currentActive);
        player.skin = currentActive;
    }

    public void moveSkins(string direction)
    {
        if (swiped)
        {
            GameObject[] skins;
            skins = GameObject.FindGameObjectsWithTag("Collectible");
            if (direction == "left")
            {
                Debug.Log("moving skins");
                for (int i = 0; i < skins.Length; i++)
                {
                    Vector3 temp = skins[i].transform.position;
        
                    temp.x -= 340 / scale;
                    skins[i].transform.position = temp;
                }
                swiped = false;
            }
            else if (direction == "right")
            {
                Debug.Log("moving skins");
                for (int i = 0; i < skins.Length; i++)
                {
                    Vector3 temp = skins[i].transform.position;
                    
                    temp.x += 340 / scale;
                    skins[i].transform.position = temp;
                }
                swiped = false;
                
            }
            checkCurrentActive();
        }
        
    }

    public void savePlayer()
    {
        player.SaveGame();
    }

    public void Start()
    {
        loadSkins();
        setCurrentSkin();
    }

    public void Update()
    {
        Swipe();

    }
}

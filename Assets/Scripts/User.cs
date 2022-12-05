using UnityEngine;

public class User : MonoBehaviour
{
    public bool BlueSkin = false;
    public bool GreenSkin = false;
    public bool BlackSkin = false;

    public void addSkin(string skin)
    {
        if (skin.Equals("blue"))
        {
            BlueSkin = true;
        } else if (skin.Equals("green"))
        {
            GreenSkin = true;
        } else if (skin.Equals("black"))
        {
            BlackSkin = true;
        }
    }

    public void saveMySelf()
    {
        SaveSystem.SaveUser(this);
    }

    public void loadMyself()
    {
        UserData data = SaveSystem.LoadUser();
        if (data != null)
        {
            BlueSkin = data.BlueSkin;
            GreenSkin = data.GreenSkin;
            BlackSkin = data.BlackSkin;
        }
    }
}

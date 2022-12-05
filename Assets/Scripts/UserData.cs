

[System.Serializable]
public class UserData
{
    public bool BlueSkin;
    public bool GreenSkin;
    public bool BlackSkin;

    public UserData(User user)
    {
        BlueSkin = user.BlueSkin;
        GreenSkin = user.GreenSkin;
        BlackSkin = user.BlackSkin;
    }
}

[System.Serializable]
public class PlayerData
{
    public int level;
    public string skin;

    public PlayerData(Player player)
    {
        level = player.level;
        skin = player.skin;
    }
}

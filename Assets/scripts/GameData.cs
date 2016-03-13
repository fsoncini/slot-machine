

public class GameData {

    private static GameData instance;

    private int coins;

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }
    
    private GameData()
    {
        coins = 50;
    }

    public int getCoins()
    {
        return coins;
    }

    //public int setCoins()
    //{
    //    return coins = 100;
    //}
    ////////////////////////public void setScore(int coins)
    ////////////////////////{
    ////////////////////////    this.coins = coins;
    ////////////////////////}

    public void addCoins (int amount)
    {
        coins += amount;
    }

}

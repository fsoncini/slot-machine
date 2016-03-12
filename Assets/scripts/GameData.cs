

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

    public void setScore(int coins)
    {
        this.coins = coins;
    }



}

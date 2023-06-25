using System;
using System.Collections.Generic;

public class Packet
{
    public bool is_success;
    public string message;
}

public class adviceinfo : Packet
{
    public int adviceID;
    public int algorithm;
    public string advice;
}

public class exptierinfo : Packet
{
    public int expTierID;
    public float requireExp;
    public string imgName;
}

public class playerprofile : Packet
{
    public int playerID;
    public string playerName;
    public string playerProfile;
}

public class PlayerTable
{
    public int playerID;
    public string playerName;
    public string playerProfile;
}

public class PlayerProfiles : Packet
{
    public List<List<object>> list;

    public List<PlayerTable> GetPlayerData()
    {
        List<PlayerTable> playerData = new List<PlayerTable>();
        foreach (var item in list)
        {
            int playerID = Convert.ToInt32(item[0]);
            string playerName = Convert.ToString(item[1]);
            string playerProfile = Convert.ToString(item[2]);

            PlayerTable playerTable = new PlayerTable()
            {
                playerID = playerID,
                playerName = playerName,
                playerProfile = playerProfile
            };

            playerData.Add(playerTable);
        }

        return playerData;
    }
}

public class playersolveproblem : Packet
{
    public int playerID;
    public int problemID;
}

public class probleminfo : Packet
{
    public int playerID;
    public int problemInfoID;
    public int problemTierID;
    public int algorithm;
    public string problemName;
}

public class problemtierinfo : Packet
{
    public int problemTierID;
    public string tierName;
    public float giveExp;
    public string imgName;
}
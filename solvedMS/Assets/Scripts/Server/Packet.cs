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
public class playersolveproblem : Packet
{
    public int playerID;
    public int problemID;
}

public class probleminfo : Packet
{
    public int problemInfoID;
    public int problemTierID;
    public int algorihtm;
}

public class problemtierinfo : Packet
{
    public int problemTierID;
    public string tierName;
    public float giveExp;
    public string imgName;
}
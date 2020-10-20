
public class QuestIdentifer : IQuestIdentifer
{
    int id;
    int chainQuestID;
    int sourceID;
    public int ID
    {
        get
        {
            return id;
        }
    }

    public int ChainQuestID
    {
        get
        {
            return chainQuestID;
        }
    }

    public int SourceID
    {
        get
        {
            return sourceID;
        }
    }
}
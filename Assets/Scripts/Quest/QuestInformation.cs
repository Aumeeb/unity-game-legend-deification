
public class QuestInformation : IQuestInfomation
{
     string qname;
     string descriptionSummary;
     string hint;
     string dialog;
     int sourceID;
    int questID;
    int chainquestID;


    public string Name
    {
        get
        {
            return qname;
        }
    }
    public string DescriptionSummary
    {
        get
        {
            return descriptionSummary;
        }
    }
    public string Hint
    {
        get
        {
            return hint;
        }
    }
    public string Dialog
    {
       get { return dialog; }
    }

    public int SourceID
    {
        get
        {
            return sourceID;
        }
    }

    public int ChainquestID
    {
        get
        {
            return chainquestID;
                 
        }
    }

    public int QuestID
    {
        get
        {
            return questID;
        }
    }
}

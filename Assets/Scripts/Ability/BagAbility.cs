public class BagAbility : BaseAbility
{

    public BagAbility()
    {
        id = 10004;
        abilityName = "Bag";
        abilityDescription = "check your bag to use some thing ";
        powerRate = 10;
        cost = 0;
        type = AbilityType.Bag;
        PanelType = PanelType.Left;

    }
}
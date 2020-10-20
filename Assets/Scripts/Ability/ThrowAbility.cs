public class ThrowAbility : BaseAbility
{

    public ThrowAbility()
    {
        id = 10003;
        abilityName = "Throw";
        abilityDescription = "Throw something to your enemy";
        powerRate = 10;
        cost = 0;
        type = AbilityType.Throw;
        PanelType = PanelType.Left;
    }
}
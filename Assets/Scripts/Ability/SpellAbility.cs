public class SpellAbility : BaseAbility
{
    public SpellAbility()
    {
        id = 10005;
        abilityName = "Spell";
        abilityDescription = "Cast Spell";
        powerRate = 10;
        cost = 0;
        type = AbilityType.Spell;
        PanelType = PanelType.Left;
    }
}
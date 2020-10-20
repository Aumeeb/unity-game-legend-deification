using System.Collections.Generic;

public class BaseHero : BaseThing {


    public BaseHero()
    {
        abilities = new List<BaseAbility>(){
            new AttackAbility(),
            new GuardAbility(),
            new ThrowAbility(),
            new SpellAbility(),
            new BagAbility(),
            new RunAbility(),
        };
        spellAbilities = new List<BaseAbility>();
    }
    public List<BaseAbility> abilities;
    public List<BaseAbility> spellAbilities;

   

   


}


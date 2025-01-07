using System.Collections.Generic;

public class GlobalConstans
{
    public static readonly List<string> NonJumpableTags = new List<string> { "Enemy" };

    // hangi dövüþ stili ise ona ata
    public static Dictionary<WeaponTypes, int> WeaponTypesDic = new Dictionary<WeaponTypes, int>
    {
        { WeaponTypes.GreatSword, 0 },
        { WeaponTypes.Gauntlet, 1 },
        { WeaponTypes.Spell , 2 },
        { WeaponTypes.Sword, 3 }
    }; 

    public enum WeaponTypes
    {
        GreatSword,
        Gauntlet,
        Spell,
        Sword
    }
}

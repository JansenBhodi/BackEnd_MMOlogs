using System.ComponentModel;

namespace MMOlogs_BackEnd.Classes
{
    public enum Roleclass
    {
        Warrior = 0,
        Knight = 1,
        Fighter = 2,
        Archer = 3,
        [Description("Fire Mage")] FireMage = 4,
        Scholar = 5,
        Cleric = 6
    }
}

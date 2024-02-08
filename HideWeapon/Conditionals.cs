using SharpPluginLoader.Core;


namespace HideWeapon
{
    internal class Conditionals
    {
        public static readonly Stage[] nonCombatStages =
        [
           Stage.Astera,
           Stage.AsteraHub,
           Stage.ChamberOfFive,
           Stage.ResearchBase,
           Stage.Seliana,
           Stage.SelianaHub,
        ];

        public static readonly Dictionary<string, Int32> SubWeapon = new Dictionary<string, Int32>
        {
            { "uWp01", 0x2358},
            { "uWp02", 0x2350},
            { "uWp03", 0x2350},
            { "uWp06", 0x2358},
            { "uWp07", 0x2350},
            { "uWp09", 0x2350},
            { "uWp11", 0x2368},
        };
    }
}

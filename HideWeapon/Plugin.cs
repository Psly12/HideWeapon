using SharpPluginLoader.Core;
using SharpPluginLoader.Core.Entities;
using SharpPluginLoader.Core.Weapons;
namespace HideWeapon
{
    public class Plugin : IPlugin
    {
        public string Name => "Hide Weapon";

        private readonly Stage[] nonCombatZone = Conditionals.nonCombatStages;
        private readonly Dictionary<string, Int32> subWeapon = Conditionals.SubWeapon;

        private Weapon? subWeaponObj;

        private bool IsInNonCombatArea()
        {
            return nonCombatZone.Contains(Area.CurrentStage);
        }

        public PluginData Initialize()
        {
            return new PluginData
            {
                OnUpdate = true
            };
        }

        public void OnLoad()
        {
            Log.Info("Loaded Hide Weapon");
        }

        public void OnUpdate(float dt)
        {
            var weapon = Player.MainPlayer?.CurrentWeapon;          
            if (weapon is not null)
            {
                var weaponType = weapon.GetDti().Name;
                if (subWeapon.ContainsKey(weaponType))
                {
                    subWeaponObj = weapon.GetObject<Weapon>(subWeapon[weaponType]);
                }                
                if (IsInNonCombatArea())
                {
                    // Making the weapon invisible
                    weapon.GetRef<uint>(0x14) &= 0xFFFFFFFC; // Clear the lowest 2 bits of the integer at offset 0x14
                    if (subWeaponObj != null)
                    {
                        subWeaponObj.GetRef<uint>(0x14) &= 0xFFFFFFFC;
                    }                    
                }
                else
                {
                    // Making the weapon visible
                    weapon.GetRef<uint>(0x14) |= 3; // Set the lowest 2 bits of the integer at offset 0x14
                    if (subWeaponObj != null)
                    {
                        subWeaponObj.GetRef<uint>(0x14) |= 3;
                    }       
                }
            }
        }
    }
}
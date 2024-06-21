using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;


namespace Instant0492
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin;
        public override string Prefix => "Instant0492";
        public override string Name => "Instant0492";
        public override string Author => "[OPENSOURCE PLUGIN] [https://github.com/scp-sl-opensource-plugins]";
        public override void OnEnabled()
        {
            plugin = this;
            Exiled.Events.Handlers.Player.Died += OnDied;
            base.OnEnabled();
        }

        private void OnDied(Exiled.Events.EventArgs.Player.DiedEventArgs ev)
        {
            if (ev.Player is null || ev.Attacker is null) return;
            HashSet<Player> Scp0492Players = Player.List.Where(x => x.Role.Type == RoleTypeId.Scp0492).ToHashSet();
            if ((ev.Attacker.Role.Type == RoleTypeId.Scp049 || (ev.Attacker.Role.Type == RoleTypeId.Scp0492 && Config.EnableFor0492)) && Scp0492Players.Count < Config.Limit)
            {
                Timing.CallDelayed(0.5f, () =>
                {
                    if (ev.Player.IsDead)
                    {
                        ev.Player.Role.Set(RoleTypeId.Scp0492);
                        ev.Player.EnableEffect(EffectType.Flashed, 1);
                        ev.Player.EnableEffect(EffectType.Disabled, 5);
                    }
                });
            }
        }

        public override void OnDisabled()
        {
            plugin = null;
            Exiled.Events.Handlers.Player.Died -= OnDied;
            base.OnDisabled();
        }
    }
}

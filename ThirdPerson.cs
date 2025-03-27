using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Utils;

public class ThirdPersonPlugin : BasePlugin
{
    public override string ModuleName => "Third Person Plugin";
    public override string ModuleVersion => "1.0";

    public override void Load(bool hotReload)
    {
        Console.WriteLine("[ThirdPersonPlugin] Plugin Loaded!");

        // Tambahkan command !tp
        AddCommand("tp", "Toggle Third Person Mode", ToggleThirdPerson);
    }

    private void ToggleThirdPerson(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot)
        {
            return;
        }

        // Mengaktifkan third-person mode
        Server.ExecuteCommand($"sm_say {player.PlayerName} entered third-person mode!");
        player.ExecuteClientCommand("thirdperson");
    }
}

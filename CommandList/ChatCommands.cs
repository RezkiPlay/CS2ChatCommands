using System;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Timers;
using CounterStrikeSharp.API.Modules.Entities;
using Microsoft.Extensions.Logging;
using CounterStrikeSharp.API.Modules.Utils;

public class RestartGamePlugin : BasePlugin
{
    public override string ModuleName => "Restart Game Plugin";
    public override string ModuleVersion => "1.0";

    public override void Load(bool hotReload)
    {
        Console.WriteLine("[RestartGamePlugin] Plugin Loaded!");

        AddCommand("rr", "restartingtheround", RestartGameCommand);
        AddCommand("warmupend", "stopthewarmup", WarmUpEndCommand);
    }

    private void AddCommand(string v, Action<CCSPlayerController?, CommandInfo> restartGameCommand)
    {
        throw new NotImplementedException();
    }

    private void RestartGameCommand(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot)
        {
            return;
        }

        Server.ExecuteCommand("mp_restartgame 1");
        Server.PrintToChatAll(
            $" {ChatColors.Green} [Server] : {ChatColors.Default} Restarting round in 1 second!");
    }
    private void WarmUpEndCommand(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot)
        {
            return;
        }

        Server.ExecuteCommand("mp_warmup_end 1");
        Server.PrintToChatAll(
             $" {ChatColors.Green} [Server] : {ChatColors.Default} End Warmup....  1 second!");
    }
}

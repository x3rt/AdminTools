﻿using CommandSystem;
using NorthwoodLib.Pools;
using System;
using System.Text;

namespace AdminTools.Commands.Enums
{
    using Exiled.API.Enums;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Enums : ParentCommand
    {
        public Enums() => LoadGeneratedCommands();

        public override string Command { get; } = "enums";

        public override string[] Aliases { get; } = new string[] { "enum" };

        public override string Description { get; } = "Lists all enums AdminTools uses";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            StringBuilder listBuilder = StringBuilderPool.Shared.Rent();
            listBuilder.Append("Here are the following enums you can use in commands:\n\nBreakType: ");
            foreach (BreakType bt in Enum.GetValues(typeof(BreakType)))
            {
                listBuilder.Append(bt.ToString());
                listBuilder.Append(" ");
            }
            listBuilder.AppendLine();
            listBuilder.Append("GrenadeType: ");
            foreach (GrenadeType gt in Enum.GetValues(typeof(GrenadeType)))
            {
                listBuilder.Append(gt.ToString());
                listBuilder.Append(" ");
            }
            listBuilder.AppendLine();
            listBuilder.Append("VectorAxis: ");
            foreach (VectorAxis va in Enum.GetValues(typeof(VectorAxis)))
            {
                listBuilder.Append(va.ToString());
                listBuilder.Append(" ");
            }
            listBuilder.AppendLine();
            listBuilder.Append("PositionModifier: ");
            foreach (PositionModifier pm in Enum.GetValues(typeof(PositionModifier)))
            {
                listBuilder.Append(pm.ToString());
                listBuilder.Append(" ");
            }
            string message = listBuilder.ToString();
            StringBuilderPool.Shared.Return(listBuilder);
            response = message;
            return true;
        }
    }
}

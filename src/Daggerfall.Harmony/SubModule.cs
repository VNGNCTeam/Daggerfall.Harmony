using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using UnityEngine;

using HarmonyLib;

/*
 * Class to handle basic version checking and unpatching all methods to ensure patches loaded before Harmony are disregarded.
 * Author: Aragas (https://github.com/BUTR/Bannerlord.Harmony)
 */
namespace Daggerfall.Harmony
{

    public class SubModule : MonoBehaviour
    {
        private static string RequiredHarmonyVersion = "2.4.2.0";
        private static readonly HarmonyRef HarmonyRef = new("Daggerfall.Harmony.UnpatchAll");

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            new GameObject(initParams.Mod.Title).AddComponent<SubModule>();
        }

        private void Start()
        {
            var currentHarmonyVersion = typeof(HarmonyMethod).Assembly.GetName().Version ?? new Version(0, 0);
            var sb = new StringBuilder();

            if (RequiredHarmonyVersion.CompareTo(currentHarmonyVersion) != 0)
            {
                if (sb.Length != 0) sb.AppendLine();
                sb.AppendLine("Loaded Harmony version is wrong!");
                sb.AppendLine("Expected " + RequiredHarmonyVersion + ", but got " + currentHarmonyVersion.ToString() + "!");
                sb.AppendLine("This is not recommended. Expect issues!");
                sb.AppendLine("If your game crashes and you had this warning, please, mention it in the bug report!");
            }

            if (sb.Length > 0)
            {
                Task.Run(() => MessageBox.Show(sb.ToString(), "Warning from Daggerfall.Harmony!", MessageBoxButtons.OK));
            }

            HarmonyRef.UnpatchAll();
        }
    }
}
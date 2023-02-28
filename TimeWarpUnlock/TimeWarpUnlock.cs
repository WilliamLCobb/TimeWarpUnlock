using System;
using BepInEx;
using I2.Loc;
using KSP.Game;
using UnityEngine;
using HarmonyLib;

[BepInPlugin("TimeWarpUnlock", "Time Warp Unlock", "0.1")]

public class TimeWarpUnlock : BaseUnityPlugin
{
    private void Start()
    {
        var harmony = new Harmony("maxratepatch");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(KSP.Sim.impl.TimeWarp))]
[HarmonyPatch("GetMaxRateIndex")]
class TimeWarpPatch
{
    static void Postfix(ref int __result)
    {
        __result = PhysicsSettings.TimeWarpLevels.Length - 1;
    }
}
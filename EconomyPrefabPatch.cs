using HarmonyLib;
using Game.Prefabs;
using UnityEngine;

namespace TrafficSimulationAdjuster
{
    [HarmonyPatch(typeof(EconomyPrefab), "LateInitialize")]
    public static class EconomyPrefabPatch
    {
        [HarmonyPrefix]
        public static void Prefix(EconomyPrefab __instance)
        {
            // 读取玩家在UI中设置的值（默认是4）
            int userValue = Mod.Options?.TrafficReductionCoefficient ?? 4;

            // 将 0-10 的滑块值映射为浮点数。
            // 滑块为 4 时 -> 0.0004f (原版默认值)
            // 滑块为 10 时 -> 0.0010f (极大增加车流)
            // 滑块为 0 时 -> 0f (完全抑制车流，市民全去网购)
            float finalValue = userValue / 10000f;

            __instance.m_TrafficReduction = finalValue;

            Mod.Log.Info($"[TrafficSimulationAdjuster] 拦截 LateInitialize，已将 m_TrafficReduction 设为: {finalValue}");
        }
    }
}
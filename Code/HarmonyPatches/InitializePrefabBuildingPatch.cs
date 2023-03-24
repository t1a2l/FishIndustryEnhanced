using System;
using HarmonyLib;
using IndustriesMeetsSunsetHarbor.AI;
using IndustriesMeetsSunsetHarbor.Utils;
using Object = UnityEngine.Object;

namespace IndustriesMeetsSunsetHarbor.HarmonyPatches
{
    [HarmonyPatch(typeof(BuildingInfo), "InitializePrefab")]
    public static class InitializePrefabBuildingPatch
    {
        public static void Prefix(BuildingInfo __instance)
        {
            try
            {
                if (__instance.m_class.m_service == ItemClass.Service.Fishing && __instance.name.Contains("Fish Market 01") && __instance.GetAI() is not ResourceMarketAI)
                {
                    var oldAI = __instance.GetComponent<PrefabAI>();
                    Object.DestroyImmediate(oldAI);
                    var newAI = (PrefabAI)__instance.gameObject.AddComponent<ResourceMarketAI>();
                    PrefabUtil.TryCopyAttributes(oldAI, newAI, false);
                }
                else if (__instance.m_class.m_service == ItemClass.Service.Fishing && (__instance.name.Contains("Aqua Crops Extractor") || __instance.name.Contains("Aqua Fish Extractor")) && __instance.GetAI() is not AquacultureExtractorAI)
                {
                    var oldAI = __instance.GetComponent<PrefabAI>();
                    Object.DestroyImmediate(oldAI);
                    var newAI = (PrefabAI)__instance.gameObject.AddComponent<AquacultureExtractorAI>();
                    PrefabUtil.TryCopyAttributes(oldAI, newAI, false);
                }
                else if (__instance.m_class.m_service == ItemClass.Service.Fishing && __instance.name.Contains("Aquaculture") &&  __instance.name.Contains("Dock") && __instance.GetAI() is not AquacultureFarmAI)
                {
                    var oldAI = __instance.GetComponent<PrefabAI>();
                    Object.DestroyImmediate(oldAI);
                    var newAI = (PrefabAI)__instance.gameObject.AddComponent<AquacultureFarmAI>();
                    PrefabUtil.TryCopyAttributes(oldAI, newAI, false);
                }
                else if (__instance.m_class.m_service == ItemClass.Service.Commercial &&  __instance.name.Contains("Pizza") && __instance.GetAI() is not RestaurantAI)
                {
                    var oldAI = __instance.GetComponent<PrefabAI>();
                    Object.DestroyImmediate(oldAI);
                    var newAI = (PrefabAI)__instance.gameObject.AddComponent<RestaurantAI>();
                    PrefabUtil.TryCopyAttributes(oldAI, newAI, false);
                }
                else if (__instance.m_class.m_service == ItemClass.Service.PlayerIndustry &&  (__instance.name.Contains("Food") || __instance.name.Contains("Lemonade") || __instance.name.Contains("Bakery")) && __instance.GetAI() is not NewUniqueFactoryAI)
                {
                    var oldAI = __instance.GetComponent<PrefabAI>();
                    Object.DestroyImmediate(oldAI);
                    var newAI = (PrefabAI)__instance.gameObject.AddComponent<NewUniqueFactoryAI>();
                    PrefabUtil.TryCopyAttributes(oldAI, newAI, false);
                } 
            }
            catch (Exception e)
            {
                LogHelper.Error(e.ToString());
            }
        }

    }
}
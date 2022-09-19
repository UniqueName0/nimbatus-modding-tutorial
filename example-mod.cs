using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace example_mod
{
    [BepInProcess("Nimbatus.exe")]
    [BepInPlugin("uniquename.nimbatus.example-mod", "example-mod", "0.0.0.0")]
    public class example_mod : BaseUnityPlugin
    {

        public void Awake()
        {
            var harmony = new Harmony("uniquename.nimbatus.example-mod");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(ItemSelector), "Select")]
    public class Select_Patch
    {
        public static void Prefix(DronePart item)
        {
            Console.WriteLine("name: " + item.Name);
            Console.WriteLine("positon: " + (Vector3)Traverse.Create(item).Field("_fixedPosition").GetValue());
        }
    }
}

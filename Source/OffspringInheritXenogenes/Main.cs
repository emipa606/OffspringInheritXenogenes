using System.Reflection;
using HarmonyLib;
using Verse;

namespace OffspringInheritXenogenes;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("offspring.inherit.xenogenes").PatchAll(Assembly.GetExecutingAssembly());
    }
}
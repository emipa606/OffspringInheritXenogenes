using System;
using Mlie;
using UnityEngine;
using Verse;

namespace OffspringInheritXenogenes;

public class OffspringInheritsXenogenesMod : Mod
{
    private static string currentVersion;

    public OffspringInheritsXenogenesMod(ModContentPack content)
        : base(content)
    {
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        Config = GetSettings<Settings>();
    }

    public static Settings Config { get; private set; }

    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        var label = "OIX.EndogeneChance".Translate(Config.EndogeneChance);
        Config.EndogeneChance = listing_Standard.SliderLabeled(label, Config.EndogeneChance, 0f, 100f);
        Config.EndogeneChance = (float)Math.Round(Config.EndogeneChance, 0);
        var label2 = "OIX.XenogeneChance".Translate(Config.XenogeneChance);
        Config.XenogeneChance = listing_Standard.SliderLabeled(label2, Config.XenogeneChance, 0f, 100f);
        Config.XenogeneChance = (float)Math.Round(Config.XenogeneChance, 0);
        var label3 = "OIX.ArchiteMultiplier".Translate(Config.ArchiteMultiplier);
        Config.ArchiteMultiplier = listing_Standard.SliderLabeled(label3, Config.ArchiteMultiplier, 0f, 10f);
        Config.ArchiteMultiplier = (float)Math.Round(Config.ArchiteMultiplier, 1);
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("OIX.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        base.DoSettingsWindowContents(rect);
    }

    public override string SettingsCategory()
    {
        return "Offspring Inherit Xenogenes";
    }

    public class Settings : ModSettings
    {
        public float ArchiteMultiplier = 1f;
        public float EndogeneChance = 50f;

        public float XenogeneChance = 50f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref EndogeneChance, "endogene_chance", 50f);
            Scribe_Values.Look(ref XenogeneChance, "xenogene_chance", 50f);
            Scribe_Values.Look(ref ArchiteMultiplier, "archite_multiplier", 1f);
            base.ExposeData();
        }
    }
}
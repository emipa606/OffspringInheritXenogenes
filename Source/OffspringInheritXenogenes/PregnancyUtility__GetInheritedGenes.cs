using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace OffspringInheritXenogenes;

[HarmonyPatch(typeof(PregnancyUtility), nameof(PregnancyUtility.GetInheritedGenes),
    [typeof(Pawn), typeof(Pawn), typeof(bool)], [ArgumentType.Normal, ArgumentType.Normal, ArgumentType.Out])]
public static class PregnancyUtility__GetInheritedGenes
{
    private static readonly MethodInfo _method_calc_genes =
        AccessTools.Method(typeof(PregnancyUtility__GetInheritedGenes), nameof(CalculateGenes));

    private static float getChance(TypedGene gene)
    {
        var num = 0.5f;
        switch (gene.Type)
        {
            case GeneType.Endogene:
                num *= OffspringInheritsXenogenesMod.Config.EndogeneChance / 50f;
                break;
            case GeneType.Xenogene:
                num *= OffspringInheritsXenogenesMod.Config.XenogeneChance / 50f;
                break;
        }

        if (gene.Gene.def.biostatArc < 1)
        {
            return num;
        }

        num *= OffspringInheritsXenogenesMod.Config.ArchiteMultiplier;
        num *= 1f / (gene.Gene.def.biostatCpx + 1f);

        return num;
    }

    public static void CalculateGenes(Pawn father, Pawn mother)
    {
        PregnancyUtility.tmpGeneChances.Clear();
        PregnancyUtility.tmpGenesShuffled.Clear();
        var list = new List<TypedGene>();
        if (father?.genes != null)
        {
            list.AddRange(father.genes.endogenes.Select(delegate(Gene i)
            {
                var result4 = default(TypedGene);
                result4.Gene = i;
                result4.Type = GeneType.Endogene;
                return result4;
            }));
            list.AddRange(father.genes.xenogenes.Select(delegate(Gene i)
            {
                var result3 = default(TypedGene);
                result3.Gene = i;
                result3.Type = GeneType.Xenogene;
                return result3;
            }));
        }

        if (mother?.genes != null)
        {
            list.AddRange(mother.genes.endogenes.Select(delegate(Gene i)
            {
                var result2 = default(TypedGene);
                result2.Gene = i;
                result2.Type = GeneType.Endogene;
                return result2;
            }));
            list.AddRange(mother.genes.xenogenes.Select(delegate(Gene i)
            {
                var result = default(TypedGene);
                result.Gene = i;
                result.Type = GeneType.Xenogene;
                return result;
            }));
        }

        foreach (var item in list)
        {
            var gene = item.Gene;
            if (gene.def.endogeneCategory == EndogeneCategory.Melanin)
            {
                continue;
            }

            PregnancyUtility.tmpGeneChances.TryGetValue(gene.def, out var value);
            PregnancyUtility.tmpGeneChances[gene.def] = value + getChance(item);
            if (!PregnancyUtility.tmpGenesShuffled.Contains(gene.def))
            {
                PregnancyUtility.tmpGenesShuffled.Add(gene.def);
            }
        }
    }

    [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var list = instructions.ToList();
        var num = 0;
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i].opcode != OpCodes.Endfinally || num++ != 1)
            {
                continue;
            }

            var codeInstruction = new CodeInstruction(OpCodes.Ldarg_0);
            codeInstruction.MoveLabelsFrom(list[i + 1]);
            list.Insert(++i, codeInstruction);
            list.Insert(++i, new CodeInstruction(OpCodes.Ldarg_1));
            list.Insert(++i, new CodeInstruction(OpCodes.Call, _method_calc_genes));
            return list.AsEnumerable();
        }

        throw new Exception(
            "Could not locate the correct instruction to patch - a mod incompatibility or game update broke it.");
    }

    private struct TypedGene
    {
        public Gene Gene;

        public GeneType Type;
    }
}
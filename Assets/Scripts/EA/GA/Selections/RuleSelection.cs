using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class RuleSelection : ISelection
{
    public int MaxPopulationSize = 50;
    public override Virus[] UseSelection(Virus[] viruses, float[] fitnessValues)
    {
        List<Virus> virusSelections = new List<Virus>();
        if (viruses.Length <= MaxPopulationSize)
        {
            return viruses; 
        }
        float sumFitnessValues = 0;
        for (int i = 0; i < fitnessValues.Length; i++)
        {
            sumFitnessValues += fitnessValues[i];
        }
        while (virusSelections.Count < MaxPopulationSize)
        {
            float randSum = Random.Range(0, sumFitnessValues);
            float curFittnesSum = 0;
            for (int i = 0; i < viruses.Length; i++) 
            {
                curFittnesSum += fitnessValues[i];
                if (curFittnesSum >= randSum)
                {
                    if (!virusSelections.Contains(viruses[i]))
                        virusSelections.Add(viruses[i]);
                    break;
                }
            }
        }
        return virusSelections.ToArray();
    }
}

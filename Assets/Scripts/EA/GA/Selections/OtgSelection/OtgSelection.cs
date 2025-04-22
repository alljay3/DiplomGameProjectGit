using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OtgSelection : IOtgSelection
{



    [SerializeField] int MaxSelectionSize = 150;
    public override Virus[] UseSelection(Virus[] viruses, float[] fitnessValues)
    {
        GenAndOtgAlg genAndOtgAlg = FindAnyObjectByType<GenAndOtgAlg>();
        genAndOtgAlg.TempOtg = genAndOtgAlg.TempOtg * genAndOtgAlg.TempCoff;
        List<Virus> virusSelections = new List<Virus>();
        float avgFitness = 0;
        foreach (float values in fitnessValues) 
        {
            avgFitness += values;
        }

        avgFitness /= fitnessValues.Count();

        for (int i = 0; i < viruses.Length; i++)
        {
            if (fitnessValues[i] > avgFitness)
            {
                virusSelections.Add(viruses[i]);
            }
            else
            {
                float probability = Mathf.Exp(-(avgFitness - fitnessValues[i]) / genAndOtgAlg.TempOtg);
                // Генерируем случайное число между 0 и 1
                float randomValue = Random.Range(0f, 1f);

                // Если случайное число меньше вероятности, добавляем вирус
                if (randomValue < probability)
                {
                    virusSelections.Add(viruses[i]);
                }
            }
        }
        if (virusSelections.Count > MaxSelectionSize)
        {
            // Перемешиваем список, чтобы отбор был случайным
            virusSelections = virusSelections.OrderBy(x => Random.value).ToList();
            virusSelections = virusSelections.Take(MaxSelectionSize).ToList();
        }

        return virusSelections.ToArray();


    }
}

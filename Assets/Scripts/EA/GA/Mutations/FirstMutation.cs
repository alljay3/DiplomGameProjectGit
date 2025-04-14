using UnityEngine;

public class FirstMutation : IMutation
{
    public float MutationVirusRate;
    public float MutationAttributeRate;
    public AttributeRange MutationAttributeRange;
    public override Virus[] UseMutation(Virus[] viruses)
    {
        foreach (var virus in viruses)
        {
            if (Random.value > MutationVirusRate) 
                continue;

            if (Random.value <= MutationAttributeRate)
                virus.Attributes.ColdResistance += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.HeatResistance += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.MaxHealth += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.HealthRegeneration += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.HungerResistance += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.ThirstResistance += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.AgeImpact += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
                virus.Attributes.MovementSpeed += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            if (Random.value <= MutationAttributeRate)
            {
                virus.Attributes.ComfortTemperature += Random.value < 0.5f ? Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max) : -1 * Random.Range(MutationAttributeRange.Min, MutationAttributeRange.Max);
            }    


        }
        return viruses;
    }
}

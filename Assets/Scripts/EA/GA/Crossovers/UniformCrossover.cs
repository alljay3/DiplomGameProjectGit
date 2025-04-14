using UnityEngine;

public class UniformCrossover : ICrossover
{

    public override Virus UseCrossover(Virus parentVirus1, Virus parentVirus2, Virus virusPref)
    {

        // Создаем новый объект для атрибутов потомка
        VirusAttrubutes offspringAttributes = new VirusAttrubutes();

        offspringAttributes.ColdResistance = Random.value < 0.5f ?
            parentVirus1.Attributes.ColdResistance : parentVirus2.Attributes.ColdResistance;

        offspringAttributes.HeatResistance = Random.value < 0.5f ?
            parentVirus1.Attributes.HeatResistance : parentVirus2.Attributes.HeatResistance;

        offspringAttributes.MaxHealth = Random.value < 0.5f ?
            parentVirus1.Attributes.MaxHealth : parentVirus2.Attributes.MaxHealth;

        offspringAttributes.HealthRegeneration = Random.value < 0.5f ?
            parentVirus1.Attributes.HealthRegeneration : parentVirus2.Attributes.HealthRegeneration;

        offspringAttributes.HungerResistance = Random.value < 0.5f ?
            parentVirus1.Attributes.HungerResistance : parentVirus2.Attributes.HungerResistance;

        offspringAttributes.ThirstResistance = Random.value < 0.5f ?
            parentVirus1.Attributes.ThirstResistance : parentVirus2.Attributes.ThirstResistance;

        offspringAttributes.AgeImpact = Random.value < 0.5f ?
            parentVirus1.Attributes.AgeImpact : parentVirus2.Attributes.AgeImpact;

        offspringAttributes.MovementSpeed = Random.value < 0.5f ?
            parentVirus1.Attributes.MovementSpeed : parentVirus2.Attributes.MovementSpeed;

        offspringAttributes.ComfortTemperature = Random.value < 0.5f ?
            parentVirus1.Attributes.ComfortTemperature : parentVirus2.Attributes.ComfortTemperature;

        Virus childVirus = GameObject.Instantiate(virusPref, parentVirus1.transform.position, Quaternion.identity);
        childVirus.GetComponent<Virus>().SetParrentAttribute(offspringAttributes);
        return childVirus;
    }
}

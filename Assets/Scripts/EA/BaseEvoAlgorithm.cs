using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class BaseEvoAlgorithm : IEvoAlgorithm
{
    [SerializeField] Vector3 childSpawnByParrent = new Vector3(0,1,0);
    public override void BeginReproduction()
    {
        List<Virus> viruses = GameObject.FindObjectsByType<Virus>(FindObjectsSortMode.None).ToList();

        while (viruses.Count > 1)
        {
            int index1 = Random.Range(0, viruses.Count);
            Virus virus1 = viruses[index1];
            viruses.Remove(virus1);

            int index2 = Random.Range(0, viruses.Count);
            Virus virus2 = viruses[index2];
            viruses.Remove(virus2);

            CrossViruses(virus1, virus2);

        }

        if (viruses.Count == 1)
        {
            Debug.Log("Один вирус остался: " + viruses[0].name);
        }
    }

    private void CrossViruses(Virus virus1, Virus virus2)
    {
        // Создаем новый объект для атрибутов потомка
        VirusAttrubutes offspringAttributes = new VirusAttrubutes();

        // Устанавливаем атрибуты потомка на основе атрибутов родителей
        offspringAttributes.ColdResistance = (int)(virus1.Attributes.ColdResistance + virus2.Attributes.ColdResistance) / 2;
        offspringAttributes.HeatResistance = (int)(virus1.Attributes.HeatResistance + virus2.Attributes.HeatResistance) / 2;
        offspringAttributes.MaxHealth = (int)(virus1.Attributes.MaxHealth + virus2.Attributes.MaxHealth) / 2;
        offspringAttributes.HealthRegeneration = (int)(virus1.Attributes.HealthRegeneration + virus2.Attributes.HealthRegeneration) / 2;
        offspringAttributes.HungerResistance = (int)(virus1.Attributes.HungerResistance + virus2.Attributes.HungerResistance) / 2;
        offspringAttributes.ThirstResistance = (int)(virus1.Attributes.ThirstResistance + virus2.Attributes.ThirstResistance) / 2;
        offspringAttributes.AgeImpact = (int)(virus1.Attributes.AgeImpact + virus2.Attributes.AgeImpact) / 2;
        offspringAttributes.MovementSpeed = (int)(virus1.Attributes.MovementSpeed + virus2.Attributes.MovementSpeed) / 2;
        offspringAttributes.ComfortTemperature = (int)(virus1.Attributes.ComfortTemperature + virus2.Attributes.ComfortTemperature) / 2;

        GameObject.Instantiate(virus1, virus1.transform.position + childSpawnByParrent, Quaternion.identity);
        virus1.SetParrentAttribute(offspringAttributes);
    }

}

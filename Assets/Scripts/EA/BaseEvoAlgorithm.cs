using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class BaseEvoAlgorithm : EvoAlgorithm
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
        offspringAttributes.ColdResistance = (int)(virus1.Attrubutes.ColdResistance + virus2.Attrubutes.ColdResistance) / 2;
        offspringAttributes.HeatResistance = (int)(virus1.Attrubutes.HeatResistance + virus2.Attrubutes.HeatResistance) / 2;
        offspringAttributes.MaxHealth = (int)(virus1.Attrubutes.MaxHealth + virus2.Attrubutes.MaxHealth) / 2;
        offspringAttributes.HealthRegeneration = (int)(virus1.Attrubutes.HealthRegeneration + virus2.Attrubutes.HealthRegeneration) / 2;
        offspringAttributes.HungerResistance = (int)(virus1.Attrubutes.HungerResistance + virus2.Attrubutes.HungerResistance) / 2;
        offspringAttributes.ThirstResistance = (int)(virus1.Attrubutes.ThirstResistance + virus2.Attrubutes.ThirstResistance) / 2;
        offspringAttributes.AgeImpact = (int)(virus1.Attrubutes.AgeImpact + virus2.Attrubutes.AgeImpact) / 2;
        offspringAttributes.MovementSpeed = (int)(virus1.Attrubutes.MovementSpeed + virus2.Attrubutes.MovementSpeed) / 2;
        offspringAttributes.ComfortTemperature = (int)(virus1.Attrubutes.ComfortTemperature + virus2.Attrubutes.ComfortTemperature) / 2;

        GameObject.Instantiate(virus1, virus1.transform.position + childSpawnByParrent, Quaternion.identity);
        virus1.SetParrentAttribute(offspringAttributes);
    }

}

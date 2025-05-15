using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiffEvolution : IEvoAlgorithm
{
    public enum ParentSelectionTypes
    {
        Panmixia, // Оба родителя выбираются случайно из популяции.
        Inbreeding, // Первый родитель случайный, второй — наиболее похожий на первого.
        Outbreeding, // Первый родитель случайный, второй — наименее похожий на первого.
    }
    [SerializeField] Vector3 childSpawnByParrent = new Vector3(0, 1, 0);

    [SerializeField] ParentSelectionTypes ParentSelectionType = ParentSelectionTypes.Panmixia;
    [SerializeField] IFitnessFunction FitnessFunction;
    [SerializeField] ICrossover Crossover;
    [SerializeField] float F = 2;
    [SerializeField] int MaxPop = 100;

    private GameManager _gameManager;

    public void Awake()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }



    public override void BeginReproduction()
    {
        List<Virus> virusObjs = GameObject.FindObjectsByType<Virus>(FindObjectsSortMode.None).ToList();
        List<Virus> newViruses = virusObjs.ToList();
        Debug.Log(newViruses.Count);
        List<float> virusFitnessResults = new List<float>();

        foreach (Virus virus in virusObjs) // Подсчет функции приспособленности
        {
            virusFitnessResults.Add(FitnessFunction.UseFitnessFunction(virus));
        }

        for (int i = 0; i < virusObjs.Count / 2; i++)
        {
            if (virusObjs.Count == 1)
                return;
            if (newViruses.Count >= MaxPop)
                break;
            Virus parent1 = null;
            Virus parent2 = null;
            if (ParentSelectionType == ParentSelectionTypes.Panmixia)
            {
                int index1 = Random.Range(0, virusObjs.Count);
                int index2 = Random.Range(0, virusObjs.Count);
                while (index1 == index2)
                    index2 = Random.Range(0, virusObjs.Count);
                parent1 = virusObjs[index1];
                parent2 = virusObjs[index2];
            }
            if (ParentSelectionType == ParentSelectionTypes.Inbreeding)
            {
                int index1 = Random.Range(0, virusObjs.Count);
                parent1 = virusObjs[index1];
                float parent1Fitness = virusFitnessResults[index1];

                float minDifference = float.MaxValue;
                int similarIndex = -1;

                for (int j = 0; j < virusObjs.Count; j++)
                {
                    if (j == index1) continue;

                    float currentDifference = Mathf.Abs(virusFitnessResults[j] - parent1Fitness);
                    if (currentDifference < minDifference)
                    {
                        minDifference = currentDifference;
                        similarIndex = j;
                    }
                }

                if (similarIndex != -1)
                {
                    parent2 = virusObjs[similarIndex];
                }
                else
                {
                    continue;
                }
            }
            if (ParentSelectionType == ParentSelectionTypes.Outbreeding)
            {
                int randomIndex = Random.Range(0, virusObjs.Count);
                parent1 = virusObjs[randomIndex];
                float parent1Fitness = virusFitnessResults[randomIndex];

                float maxDifference = float.MinValue;
                int dissimilarIndex = -1;

                for (int j = 0; j < virusObjs.Count; j++)
                {
                    if (j == randomIndex) continue;

                    float currentDifference = Mathf.Abs(virusFitnessResults[j] - parent1Fitness);
                    if (currentDifference > maxDifference)
                    {
                        maxDifference = currentDifference;
                        dissimilarIndex = j;
                    }
                }

                if (dissimilarIndex != -1)
                {
                    parent2 = virusObjs[dissimilarIndex];
                }
                else
                {
                    continue;
                }
            }

            Virus childVirus = Crossover.UseCrossover(parent1, parent2, _gameManager.VirusPref);
            childVirus.transform.position += childSpawnByParrent;
            virusFitnessResults.Add(FitnessFunction.UseFitnessFunction(childVirus));
            newViruses.Add(childVirus);
        }

        List<Virus> evoViruses = new List<Virus>();
        for (int i = 0; i < newViruses.Count; i++) 
        {
            if (newViruses.Count < 4) // Минимум 3 вируса нужно для выбора
                return;

            // Создаем список индексов
            List<int> availableIndices = Enumerable.Range(0, newViruses.Count).ToList();
            availableIndices.Remove(i);

            // Выбираем случайный индекс для parrent1 и удаляем его из доступных
            int index1 = availableIndices[Random.Range(0, availableIndices.Count)];
            availableIndices.Remove(index1);
            Virus parrent1 = newViruses[index1];

            // Выбираем случайный индекс для parrent2 и удаляем его из доступных
            int index2 = availableIndices[Random.Range(0, availableIndices.Count)];
            availableIndices.Remove(index2);
            Virus parrent2 = newViruses[index2];

            // Выбираем случайный индекс для parrent3
            int index3 = availableIndices[Random.Range(0, availableIndices.Count)];
            Virus parrent3 = newViruses[index3];

            Virus mutVirus = DiffCrossover(parrent1, parrent2, parrent3);
            Virus probVirus = Crossover.UseCrossover(newViruses[i], mutVirus, _gameManager.VirusPref);
            probVirus.Stats.CurrentHealth = newViruses[i].Stats.CurrentHealth;
            probVirus.transform.position += childSpawnByParrent;
            Destroy(mutVirus.gameObject);
            if (FitnessFunction.UseFitnessFunction(probVirus) > FitnessFunction.UseFitnessFunction(newViruses[i]))
            {
                Destroy(newViruses[i].gameObject);
                newViruses[i] = probVirus;
            }
            else
            {
                Destroy(probVirus.gameObject);
            }


        }
    }

    public Virus DiffCrossover(Virus parrent1, Virus parrent2, Virus parrent3)
    {
        VirusAttrubutes offspringAttributes = new VirusAttrubutes();

        offspringAttributes.ColdResistance = parrent1.Attributes.ColdResistance + (int) (F * (float)(parrent2.Attributes.ColdResistance - parrent3.Attributes.ColdResistance));

        offspringAttributes.HeatResistance = parrent1.Attributes.HeatResistance + (int) (F * (float)(parrent2.Attributes.HeatResistance - parrent3.Attributes.HeatResistance));

        offspringAttributes.MaxHealth = parrent1.Attributes.MaxHealth + (int) (F * (float)(parrent2.Attributes.MaxHealth - parrent3.Attributes.MaxHealth));

        offspringAttributes.HealthRegeneration = parrent1.Attributes.HealthRegeneration + (int)(F * (float)(parrent2.Attributes.HealthRegeneration - parrent3.Attributes.HealthRegeneration));

        offspringAttributes.HungerResistance = parrent1.Attributes.HungerResistance + (int)(F * (float)(parrent2.Attributes.HungerResistance - parrent3.Attributes.HungerResistance));

        offspringAttributes.ThirstResistance = parrent1.Attributes.ThirstResistance + (int)(F * (float)(parrent2.Attributes.ThirstResistance - parrent3.Attributes.ThirstResistance));

        offspringAttributes.AgeImpact = parrent1.Attributes.AgeImpact + (int)(F * (float)(parrent2.Attributes.AgeImpact - parrent3.Attributes.AgeImpact));

        offspringAttributes.MovementSpeed = parrent1.Attributes.MovementSpeed + (int)(F * (float)(parrent2.Attributes.MovementSpeed - parrent3.Attributes.MovementSpeed));

        offspringAttributes.ComfortTemperature = parrent1.Attributes.ComfortTemperature + (int)(F * (float)(parrent2.Attributes.ComfortTemperature - parrent3.Attributes.ComfortTemperature));

        Virus newVir = GameObject.Instantiate(_gameManager.VirusPref, parrent1.transform.position, Quaternion.identity);
        newVir.GetComponent<Virus>().SetParrentAttribute(offspringAttributes);
        return newVir;
    }

}

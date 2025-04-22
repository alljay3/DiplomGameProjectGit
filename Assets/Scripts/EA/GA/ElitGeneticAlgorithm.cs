using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElitGeneticAlgorithm : IEvoAlgorithm
{
    public enum ParentSelectionTypes
    {
        Panmixia, // ќба родител€ выбираютс€ случайно из попул€ции.
        Inbreeding, // ѕервый родитель случайный, второй Ч наиболее похожий на первого.
        Outbreeding, // ѕервый родитель случайный, второй Ч наименее похожий на первого.
    }
    [SerializeField] Vector3 childSpawnByParrent = new Vector3(0, 1, 0);
    [SerializeField] int EliteVirusCount = 2;
    [SerializeField] ParentSelectionTypes ParentSelectionType = ParentSelectionTypes.Panmixia;
    [SerializeField] IFitnessFunction FitnessFunction;
    [SerializeField] ICrossover Crossover;
    [SerializeField] ISelection Selection;
    [SerializeField] IMutation Mutation;

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

        foreach (Virus virus in virusObjs) // ѕодсчет функции приспособленности
        {
            virusFitnessResults.Add(FitnessFunction.UseFitnessFunction(virus));
        }

        List<Virus> eliteViruses = GetEliteViruses(virusObjs, virusFitnessResults, EliteVirusCount);


        for (int i = 0; i < virusObjs.Count / 2; i++)
        {
            if (virusObjs.Count == 1)
                return;
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
        } // Crossover


        Mutation.UseMutation(newViruses.ToArray());

        List<Virus> noElitVirus = newViruses.Except(eliteViruses).ToList();

        List<float> NoElitVirusFitnessResults = new List<float>();

        foreach (Virus virus in noElitVirus) 
        {
            NoElitVirusFitnessResults.Add(FitnessFunction.UseFitnessFunction(virus));
        }

        List<Virus> selectedViruses = Selection.UseSelection(noElitVirus.ToArray(), NoElitVirusFitnessResults.ToArray()).ToList();
        selectedViruses.AddRange(eliteViruses);
        var virusesToDestroy = newViruses.Except(selectedViruses).ToList();

        foreach (var virus in virusesToDestroy)
        {
            Destroy(virus.gameObject);
        }



    }

    // ћетод дл€ выбора элитных особей
    private List<Virus> GetEliteViruses(List<Virus> viruses, List<float> fitnessResults, int eliteCount)
    {
        if (eliteCount <= 0) return new List<Virus>();

        // —ортируем вирусы по fitness (от лучшего к худшему)
        var sortedViruses = viruses
            .Select((virus, index) => new { Virus = virus, Fitness = fitnessResults[index] })
            .OrderByDescending(x => x.Fitness)
            .Take(eliteCount)
            .Select(x => x.Virus)
            .ToList();

        return sortedViruses;
    }
}

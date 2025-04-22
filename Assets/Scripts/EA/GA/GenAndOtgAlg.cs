using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenAndOtgAlg : IEvoAlgorithm
{
    public enum ParentSelectionTypes
    {
        Panmixia, // ќба родител€ выбираютс€ случайно из попул€ции.
        Inbreeding, // ѕервый родитель случайный, второй Ч наиболее похожий на первого.
        Outbreeding, // ѕервый родитель случайный, второй Ч наименее похожий на первого.
    }
    [SerializeField] Vector3 childSpawnByParrent = new Vector3(0, 1, 0);

    [SerializeField] ParentSelectionTypes ParentSelectionType = ParentSelectionTypes.Panmixia;
    [SerializeField] IFitnessFunction FitnessFunction;
    [SerializeField] ICrossover Crossover;
    [SerializeField] IOtgSelection Selection;
    [SerializeField] IMutation Mutation;
    [SerializeField] public float TempCoff = 0.90f;
    [SerializeField] public float StartTempOtg = 10000;
    [HideInInspector] public float TempOtg = 10000;
    private GameManager _gameManager;

    public void Awake()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }
    public void Start()
    {
        TempOtg = StartTempOtg;
    }

    public override void BeginReproduction()
    {
        List<Virus> virusObjs = GameObject.FindObjectsByType<Virus>(FindObjectsSortMode.None).ToList();
        List<Virus> newViruses = virusObjs.ToList();
        List<float> virusFitnessResults = new List<float>();
        Debug.Log(virusObjs.Count);

        foreach (Virus virus in virusObjs) // ѕодсчет функции приспособленности
        {
            var fitnessRes = FitnessFunction.UseFitnessFunction(virus);
            virusFitnessResults.Add(fitnessRes);
        }

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



        List<Virus> selectedViruses = Selection.UseSelection(newViruses.ToArray(), virusFitnessResults.ToArray()).ToList();
        var virusesToDestroy = newViruses.Except(selectedViruses).ToList();

        foreach (var virus in virusesToDestroy)
        {
            Destroy(virus.gameObject);
        }



    }
}

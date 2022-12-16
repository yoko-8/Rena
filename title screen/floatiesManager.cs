using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class floatiesManager : MonoBehaviour
{
    [SerializeField] private List<floaties_movement> floatiesPrefabs;
    public float floatiesTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        floatiesTimer += Time.deltaTime;
        if (floatiesTimer >= 2.5)
        {
            Spawn();
            floatiesTimer = 0;
        }
    }

    void Spawn()
    {
        var randomSet = floatiesPrefabs.OrderBy(s => Random.value).Take(5).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedFloaties = Instantiate(randomSet[i]);
        }
    }
}

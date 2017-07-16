using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public Monster monster;
    public float interval;
    public int maxMonsters;
    public Rect spawnSpace;


    public bool useDefaults = false;
    [Header("radius or rotationSpeed")]
    public Vector2 propARange = new Vector2(2,6);

    [Header("forwardSpeed or BurstSpeed")]
    public Vector2 propBRange= new Vector2(2,6);

    public string tagForSpawned = "Player";
    private List<GameObject> children;

    private Clock timer;

	void Start ()
    {
        children = new List<GameObject>();
        timer = new Clock(interval);
	}

    void Update()
    {
        if (timer.tick(Time.deltaTime))
        {
            print(children.Count);
            if (children.Count < maxMonsters)
            {
                Monster m = Instantiate(monster,transform);
                if (false == useDefaults)
                {
                    m.init(new Vector2(Random.Range(spawnSpace.xMin, spawnSpace.xMax), Random.Range(spawnSpace.yMin, spawnSpace.yMax)), new Vector2(Random.Range(propARange.x, propARange.y), Random.Range(propBRange.x, propBRange.y)), tagForSpawned);
                }
                else
                {
                    m.transform.position = new Vector2(Random.Range(spawnSpace.xMin, spawnSpace.xMax), Random.Range(spawnSpace.yMin, spawnSpace.yMax));
                }
            }
        }
    }

}

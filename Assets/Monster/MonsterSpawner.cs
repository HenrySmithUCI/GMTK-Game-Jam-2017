using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public Monster monster;
    public float interval;
    public int maxMonsters;
    public Rect spawnSpace;

    [Header("radius or rotationSpeed")]
    public Vector2 propARange = new Vector2(2,6);

    [Header("forwardSpeed or BurstSpeed")]
    public Vector2 propBRange= new Vector2(2,6);

    public string tagForSpawned = "Player";

    private int numMonsters;
    private Clock timer;

	void Start ()
    {
        numMonsters = 0;
        timer = new Clock(interval);
	}

    void Update()
    {
        if (timer.tick(Time.deltaTime))
        {
            if (numMonsters < maxMonsters)
            {
                Monster m = Instantiate(monster,transform);
                m.init(new Vector2(Random.Range(spawnSpace.xMin, spawnSpace.xMax), Random.Range(spawnSpace.yMin, spawnSpace.yMax)), new Vector2(Random.Range(propARange.x, propARange.y), Random.Range(propBRange.x, propBRange.y)), tagForSpawned);
                numMonsters += 1;
            }
        }
    }

}

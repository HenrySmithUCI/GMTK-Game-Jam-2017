using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public GameObject monster;
    public float interval;
    public int maxMonsters;
    public Rect spawnSpace;

    private int numMonsters;
    private Clock timer;

	void Start () {
        numMonsters = 0;
        timer = new Clock(interval);
	}

    void Update()
    {
        if (timer.tick(Time.deltaTime))
        {
            if (numMonsters < maxMonsters)
            {
                Monster m = Instantiate(monster, transform).GetComponent<Monster>();
                float r = Random.Range(2, 4);
                m.init(new Vector2(Random.Range(spawnSpace.xMin+r,spawnSpace.xMax-r), Random.Range(spawnSpace.yMin+r,spawnSpace.yMax-r)), r, Random.Range(2,6));
                numMonsters += 1;
            }
        }
    }

}

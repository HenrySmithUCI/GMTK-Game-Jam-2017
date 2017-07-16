using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrail : MonoBehaviour {

    public GameObjectSpawnPool particlePool;
    public float rate;
    public Color color;
    private Clock clock;
	
    void Start()
    {
        if (particlePool == null)
        {
            particlePool = GameObject.Find("ParticlePool").GetComponent<GameObjectSpawnPool>();
        }
        clock = new Clock(rate);
    }

	void Update () {
        if (clock.tick(Time.deltaTime))
        {
            SpinAndDecay particle = particlePool.getInactivePooledObject().GetComponent<SpinAndDecay>();
            particle.init((Vector2)transform.position + (Random.insideUnitCircle * 0.1f), color);
            particle.gameObject.SetActive(true);
        }
	}
}

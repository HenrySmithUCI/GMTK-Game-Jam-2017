using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    public Monster[] monsters;

    private static ProgressManager instance;
    private GameObject player;

    public int score;

    void Start ()
    {
        if (null == instance)
        {
            instance = this;
            player = GameObject.Find("Player");
        }
        else
        {
            print("Making two singleton gameobject!");
            Destroy(this.gameObject);
        }
    }

    public void increment()
    {
        if(player == null)
        {
            return;
        }
        score += 1;
        Monster m = Instantiate(monsters[Random.Range(0, monsters.Length)]);
        do
        {
            m.transform.position = Random.insideUnitCircle * Random.Range(0f, 5f);
        } while(Vector2.Distance(m.transform.position, player.transform.position) < 3);
        m.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        m.parent = true;

    }

    public static ProgressManager Instance
    {
        get { return instance; }
    }

}

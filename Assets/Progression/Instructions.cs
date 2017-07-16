using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {
    public float fadeTime;
    public AnimationCurve fade;

    Clock countdown;
    TextMesh text;
    [TextArea]
    public string[] messages;
    int messageNumber;
    int lastMessage;

	void Start () {
        text = GetComponent<TextMesh>();
        messageNumber = 0;
        countdown = new Clock(fadeTime);
        countdown.Value = fadeTime / 4;
	}
	
	void Update () {
        text.color = new Color(text.color.r, text.color.g, text.color.b, fade.Evaluate(countdown.Value / countdown.MaxValue));
        if (countdown.tick(Time.deltaTime))
        {
            messageNumber += 1;
            if (messageNumber >= 2)
            {
                if (messages.Length != 0)
                {
                    int m;
                    do{
                        m = Random.Range(0, messages.Length);
                    }while(m == lastMessage);
                    lastMessage = m;
                    text.text = messages[m];
                }
                else
                    text.text = "";
            }
            else
            {
                text.text = "Left Shift\nfor precise aim";
            }
        }
        if (false == HealthManager.Instance.playerAlive)
        {
            countdown.paused = true;
            text.text = "Space\nto restart";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        }
	}


}

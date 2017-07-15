using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour {


    public float cornerThresholdX =  2.0f;
    public float cornerThresholdY = 1.2f;
    public float cornerThreshAngle = 0.5f;

    float halfWidth;
    float halfHeight;
    Vector2[] directions = new Vector2[4];
    //Rigidbody2D mainRB;

	void Start () {
        Matrix4x4 orthoMatrix = Camera.main.projectionMatrix;
        halfWidth = (2/orthoMatrix[0]) / 2;
        halfHeight = (2 / orthoMatrix[5]) / 2;
        directions[0] = new Vector2(1, 1);
        directions[1] = new Vector2(-1, 1);
        directions[2] = new Vector2(-1, -1);
        directions[3] = new Vector2(1, -1);
        //mainRB = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
 
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector2 posNorm = transform.position;
        float normalRatio = ((posNorm.x) * (posNorm.x)) + ((posNorm.y) * (posNorm.y));
        posNorm.x = posNorm.x / normalRatio;
        posNorm.y = posNorm.y / normalRatio;
        Vector3 posTransform = new Vector3(pos.x, pos.y, pos.z);
        bool shouldTransform = false;

        if (pos.x > halfWidth)
        {
            posTransform.x = -halfWidth;
            shouldTransform = true;
        }
        else if (pos.x < -halfWidth)
        {
            posTransform.x = halfWidth;
            shouldTransform = true;
        }
        else if (pos.y > halfHeight)
        {
            posTransform.y = -halfHeight;
            shouldTransform = true;
        }
        else if (pos.y < -halfHeight)
        {
            posTransform.y = halfHeight;
            shouldTransform = true;
        }
        

        if (shouldTransform)
        {
            float pointer = Vector2.Dot(posNorm, directions[0]);
            //float pointer2 = Vector2.Dot(posNorm, directions[3]);
            //float pointer3 = Vector2.Dot(posNorm, directions[1]);
            //float pointer4 = Vector2.Dot(posNorm, directions[2]);

            if (posTransform.x < pos.x)
            {
                
                if (pointer >= cornerThreshAngle && pos.y > (halfHeight - cornerThresholdY))
                {
                    posTransform.y += halfHeight + 0.1f;
                    posTransform.x += halfHeight - pos.y;
                }
             
            }
            else if(posTransform.x > pos.x)
            {
                
            }
            else if (posTransform.y > pos.y)
            {

            }
            else if (posTransform.y < pos.y)
            {

            }
        }

        transform.position = posTransform;
        //Debug.Log(posTransform.y);
        
    }
}

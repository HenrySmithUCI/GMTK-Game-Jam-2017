using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour {


    public float cornerThresholdX =  2.0f;
    public float cornerThresholdY = 3.5f;
    public float cornerThreshAngle = 0.65f;

    float halfWidth;
    float halfHeight;
    Vector2[] directions = new Vector2[4];

	void Start () {
        Matrix4x4 orthoMatrix = Camera.main.projectionMatrix;
        halfWidth = (2/orthoMatrix[0]) / 2;
        halfHeight = (2 / orthoMatrix[5]) / 2;
        directions[0] = new Vector2(halfWidth, halfHeight);
        directions[0].Normalize();
        directions[1] = new Vector2(-halfWidth, halfHeight);
        directions[1].Normalize();
        directions[2] = new Vector2(-halfWidth, -halfHeight);
        directions[2].Normalize();
        directions[3] = new Vector2(halfWidth, -halfHeight);
        directions[3].Normalize();
        directions[0] = new Vector2(1, 1);
        directions[1] = new Vector2(-1, 1);
        directions[2] = new Vector2(-1, -1);
        directions[3] = new Vector2(1, -1);
    }
	

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector2 posNorm = transform.up;
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
            float pointer2 = Vector2.Dot(posNorm, directions[3]);
            float pointer3 = Vector2.Dot(posNorm, directions[1]);
            float pointer4 = Vector2.Dot(posNorm, directions[2]);

            if (posTransform.x < pos.x)
            {
                if (pointer >= cornerThreshAngle && pos.y > (halfHeight - cornerThresholdY))
                {
                    posTransform.y = -halfHeight + 0.1f;
                    posTransform.x += halfHeight - pos.y;
                }
                else if((pointer2 >= cornerThreshAngle) && (pos.y < (cornerThresholdY - halfHeight)))
                {
                    posTransform.y = halfHeight - 0.1f;
                    posTransform.x += pos.y + halfHeight;
                }
            }
            else if(posTransform.x > pos.x)
            {
                if (pointer3 >= cornerThreshAngle && pos.y > (halfHeight - cornerThresholdY))
                {
                    posTransform.y = -halfHeight + 0.1f;
                    posTransform.x -= (halfHeight - pos.y);
                }
                else if ((pointer4 >= cornerThreshAngle) && (pos.y < (cornerThresholdY - halfHeight)))
                {
                    posTransform.y = halfHeight - 0.1f;
                    posTransform.x -= pos.y + halfHeight;
                }
            }
            else if (posTransform.y < pos.y)
            {
                
                if (pointer >= cornerThreshAngle && pos.x > (halfWidth - cornerThresholdX))
                {
                    posTransform.y += halfWidth - pos.x;
                    posTransform.x = -halfWidth + 0.1f;
                }
                else if ((pointer3 >= cornerThreshAngle) && (pos.x < ((-halfWidth) + cornerThresholdX)))
                {
                    posTransform.y += pos.x + halfWidth;
                    posTransform.x = (halfWidth - 0.1f);
                }
            }
            else if (posTransform.y > pos.y)
            {
                if (pointer2 >= cornerThreshAngle && pos.x > (halfWidth - cornerThresholdX))
                {
                    posTransform.y -= (halfWidth - pos.x);
                    posTransform.x = -halfWidth + 0.1f;
                }
                else if ((pointer4 >= cornerThreshAngle) && (pos.x < ((-halfWidth) + cornerThresholdX)))
                {
                    posTransform.y -= pos.x + halfWidth;
                    posTransform.x = (halfWidth - 0.1f);
                }
            }
        }

        transform.position = posTransform;        
    }
}

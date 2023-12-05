using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Movement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    public Camera myCam;

    public GameObject botFocusTarget;
    private Vector3 targetPosition;
    


    [SerializeField] public float maxViewportDistance = 0.55f;
    [SerializeField] public float FarMaxViewportDistance = 0.9f;

    
    void FixedUpdate()
    {
      
        myCam.transform.position = CalculateCameraPos();
    }

    private Vector3 CalculateTargetPostion()
    {
        

        if (ObjectSpawnManager.gameObjectsInPlay.Count != 0)
        {
            Vector3 dist = botFocusTarget.transform.position -
                           ObjectSpawnManager.gameObjectsInPlay.Last().transform.position;
            return botFocusTarget.transform.position + (dist * 0.5f);
        }
    
        return botFocusTarget.transform.position;
    }

    private Vector3 CalculateCameraPos()
    {
        Vector2 botViewport = this.myCam.WorldToViewportPoint(botFocusTarget.transform.position);
        Vector2 lastObjViewport;
        if (ObjectSpawnManager.gameObjectsInPlay.Count > 0)
        {
            lastObjViewport = this.myCam.WorldToViewportPoint(ObjectSpawnManager.gameObjectsInPlay.Last().transform.position);  
        }
        else
        { 
            lastObjViewport = this.myCam.WorldToViewportPoint(botFocusTarget.transform.position);
            
        }

        float viewportDistance = Vector2.Distance(botViewport, lastObjViewport);

        if (myCam.transform.position.y >= 5f)
        {
            maxViewportDistance = FarMaxViewportDistance;
        }

        if (viewportDistance > maxViewportDistance)
        {
            float camX = myCam.transform.position.x;
            float camY = -CalculateTargetPostion().y;
            float camZ = myCam.transform.position.z;
            camZ -= 0.1f;

            return new Vector3(camX, camY, camZ);
        }

        return myCam.transform.position;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Movement;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ObjectSpawnManager : MonoBehaviour
{
    public GameObject playerCube;
    public GameObject playerCylinder;
    public GameObject playerSphere;

    public static List<GameObject> gameObjects;
    public static List<GameObject> gameObjectsInPlay;

    public static bool isAllowedToSpawn = true;

    public static UnityEvent spawnObjEvent;
    public static UnityEvent isAllowdToSpawnTrueEvent;
    public static UnityEvent isAllowdToSpawnFalseEvent;
    public static UnityEvent gameIsResetEvent;
    
    private void Update()
    {
        if (gameObjectsInPlay.Count == 0)
        {
            SpawnNewObj();
        }
    }

    private void IsAllowdToSpawnSetTrue()
    {
        isAllowedToSpawn = true;
    }

    private void IsAllowdToSpawnSetFalse()
    {
        isAllowedToSpawn = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (gameObjects == null)
        {
            gameObjects = new List<GameObject>();
            InitGameObjList(gameObjects);
        }

        if (gameObjectsInPlay == null)
        {
            gameObjectsInPlay = new List<GameObject>();
            SpawnNewObj();
        }

        spawnObjEvent ??= new UnityEvent();
        isAllowdToSpawnTrueEvent ??= new UnityEvent();
        isAllowdToSpawnFalseEvent ??= new UnityEvent();
        gameIsResetEvent ??= new UnityEvent();

        spawnObjEvent.AddListener(SpawnNewObj);
        isAllowdToSpawnTrueEvent.AddListener(IsAllowdToSpawnSetTrue);
        isAllowdToSpawnFalseEvent.AddListener(IsAllowdToSpawnSetFalse);
        gameIsResetEvent.AddListener(ResetGameObjInPlayList);
    }

    private void SpawnNewObj()
    {
        if (isAllowedToSpawn)
        {
            GameObject obj = GetRandomObj();
            obj.transform.position = setObjectPosition();
            gameObjectsInPlay.Add(obj);
            Instantiate(gameObjectsInPlay.Last());
        }
    }

    private GameObject GetRandomObj()
    {
        if (gameObjectsInPlay.Count == 0)
        {
            return this.playerCube;
        }

        int randomIndex = Random.Range(0, gameObjects.Count);
        Debug.Log("Random index: " + randomIndex);
        return gameObjects[randomIndex];
    }

    private Vector3 setObjectPosition()
    {
        float highestObj = PlayerMoveStateManager.highestPlacedHeight;
        Vector3 myVector = new Vector3(1, highestObj + 5, 0);
        return myVector;
    }

    void ResetGameObjInPlayList()
    {
        gameObjectsInPlay.Clear();
    }
    
    private void InitGameObjList(List<GameObject> obj)
    {
        obj.Add(playerCube);
        obj.Add(playerCylinder);
        obj.Add(playerSphere);
    }
}
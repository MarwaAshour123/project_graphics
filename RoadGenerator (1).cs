using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject[] Roads;
    public GameObject[] hurdles;
    float LengthOfRoad = 9.81f;
    public float RoadGeneratorTime;

    // Use this for initialization
    void Start()
    {
        SpawnRoad();
        spawnhurdles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator generator()
    {
        yield return new WaitForSeconds(RoadGeneratorTime);
        SpawnRoad();
    }

    void SpawnRoad()
    {
        int randomRoad = UnityEngine.Random.Range(0, Roads.Length - 1);
        float playerxPos = playerPosition.position.x + LengthOfRoad;
        
        Instantiate(Roads[randomRoad], new Vector2(playerxPos, -0.65f), Roads[randomRoad].transform.rotation);
        
        StartCoroutine(generator());

    }
    IEnumerator spawnHurdles()
    {
        yield return new WaitForSeconds(3);
        spawnhurdles();

    }

    void spawnhurdles()
    {
        int randomHurdles = UnityEngine.Random.Range(0, hurdles.Length-1);
        float playerxPos = playerPosition.position.x + LengthOfRoad-4;
        Instantiate(hurdles[randomHurdles],new Vector2(playerxPos, hurdles[randomHurdles].transform.position.y), hurdles[randomHurdles].transform.rotation);
        StartCoroutine(spawnHurdles());
    }





}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    public int OpponentsCount;
    public float OpponentMinSpeed;
    public float OpponentMaxSpeed;
    public float PlayerSpeed;
    public Vector3 StartPos;
    public Vector3 FinishPos;
    public float DistanceBetweenOpponents;

    public GameObject PlayerPrefab;
    public GameObject OpponentPrefab;
}
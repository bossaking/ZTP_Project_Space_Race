using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    private GameObject mPlayerPrefab;

    public GameObject playerInstantiationPoint;

    void Start()
    {
        mPlayerPrefab = Resources.Load<GameObject>("Prefabs/PlayerShip");
        InstantiatePlayer();
    }

    //PlayerInstantiation
    private void InstantiatePlayer()
    {
        Instantiate(mPlayerPrefab, playerInstantiationPoint.transform.position, Quaternion.identity);
    }

}

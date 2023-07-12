using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Crewmate crewmatePrefab;
    [SerializeField] private Crewmate recentCrewmate;
    // Start is called before the first frame update
    void Start()

    {
        recentCrewmate = Instantiate(crewmatePrefab);
       // ship.successfulCrewmates.Add()
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField] public int maxCrew = 10;
    public List<Crewmate> successfulCrewmates = new List<Crewmate>();

    public string GetRandomHobbyFromCrew()
    {
        int randomIndex = Random.Range(0, successfulCrewmates.Count);
        //crewmates from  list to array
        Crewmate[] crewmatesArray = successfulCrewmates.ToArray();
        //Finding random crewmate
        Crewmate randomCrewmate = crewmatesArray[randomIndex];
        //Returning hobby
        return randomCrewmate.hobby;
    }
    public string GetRandomHobbyFrom(string[] hobbies)
    {
        int randomIndex = Random.Range(0, hobbies.Length);
        return hobbies[randomIndex];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField] public int maxCrew = 10;
    public List<Crewmate> successfulCrewmates = new List<Crewmate>();

}

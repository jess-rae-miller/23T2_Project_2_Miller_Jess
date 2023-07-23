using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int maxCrew = 10;
    public List<Crewmate> successfulCrewmates = new List<Crewmate>();

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

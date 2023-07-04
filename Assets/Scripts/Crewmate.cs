using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField] public string hobby;
    [SerializeField] public bool isAlien;

    public int maxCrew = 10;

    //Human hobbies
    private string[] humanHobbies = { "Reading", "Writing", "Painting", "Sport", "Cooking", "Film"};
    //Alien hobbies
    private string[] alienHobbies = { "Assimilating", "Synthesizing", "Breathing", "Smelling", "Taxidermy", "Devouring"};

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        if (maxCrew < 10);
        {
            GenerateCrewmate();
        }
    }

    private void GenerateCrewmate()
    {
        string name = GenerateRandomName();
        string hobby;
        // 1/4 chance of being an alien????
        bool isAlien = Random.value < 0.25f; 

        if (isAlien)
        {
            hobby = GetRandomHobbyFrom(alienHobbies);
        }
        else
        {
            hobby = GetRandomHobbyFrom(humanHobbies);
        }
    }

    private string GetRandomHobbyFrom(string[] hobbies)
    {
        int randomIndex = Random.Range(0, hobbies.Length);
        return hobbies[randomIndex];
    }

    private void GenerateRandomName()
    {
        //???????
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

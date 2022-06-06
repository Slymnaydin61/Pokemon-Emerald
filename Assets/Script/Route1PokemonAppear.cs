using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route1PokemonAppear : MonoBehaviour
{
    PlayerMovement playerMovement;

    [SerializeField] GameObject pokemonCatchCanvas;

    void Awake()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
     if (collision.gameObject.tag == "Grass" && playerMovement.pokemonSearchTime < 0&&playerMovement.isWalking)
     {
       FindPokemon();
     }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement.pokemonSearchTime = Random.Range(0.5f,2);
    }


    void FindPokemon()
    {
        float pokemonApperChance = Random.Range(0, 101);
        while(playerMovement.isSearchingPokemon)
        {
            if (pokemonApperChance < 50)
            {
                Debug.Log("A wild Ratata Appeared");
                playerMovement.isSearchingPokemon = false;
                playerMovement.pokemonSearchTime = Random.Range(3, 7);
                pokemonCatchCanvas.SetActive(true);
                playerMovement.enabled = false;
            }
            else
            {
                Debug.Log("A wild Pidgey Appeared");
                playerMovement.isSearchingPokemon=false;
                playerMovement.pokemonSearchTime = Random.Range(3, 7);
                pokemonCatchCanvas.SetActive(true);
                playerMovement.enabled = false;
            }
            
        }
    }
 
}

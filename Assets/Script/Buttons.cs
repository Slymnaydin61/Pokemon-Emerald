using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject pokemonCatchCanvas;
     void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }
    public void AvoidFight()
    {
        playerMovement.isSearchingPokemon = true;
        pokemonCatchCanvas.SetActive(false);
        playerMovement.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePokemonCatch : MonoBehaviour
{
    Route1PokemonAppear Route1PokemonAppear;
    void Start()
    {
        Route1PokemonAppear = FindObjectOfType<Route1PokemonAppear>();
        ActivateScript();
    }
    void ActivateScript()
    {
        if(gameObject.name=="Route1")
        {
            Route1PokemonAppear.enabled = true;
        }
    }


}

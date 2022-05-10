using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TokensText : MonoBehaviour
{
    [SerializeField] private Token tokenType;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.text = tokenType switch
        {
            Token.Basic => AbilityResources.BasicTokens.ToString(),
            Token.Advanced => AbilityResources.AdvancedTokens.ToString(),
            Token.Ultimate => AbilityResources.UltimateTokens.ToString(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private enum Token
    {
        Basic,
        Advanced,
        Ultimate
    }
}
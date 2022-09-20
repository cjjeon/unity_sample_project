using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetInventory
{
    private IDictionary<string, int> alphabet = new Dictionary<string, int>();

    public void AddAlphabet(string character)
    {
        int count;
        alphabet.TryGetValue(character, out count);
        alphabet[character] = count + 1;
    }

    public int GetAlphabet(string character)
    {
        int count;
        alphabet.TryGetValue(character, out count);
        return count;
    }
}

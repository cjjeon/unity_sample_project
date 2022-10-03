using UnityEngine;


public enum ItemType
{
    Alphabet
}

public class ItemObject : ScriptableObject
{
    public ItemType type;
    public Sprite image;
    public string description;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameItem",menuName ="Game Items/Create Game Item",order =1)]
public class ItemScriptableObject : ScriptableObject
{
    public string title;
    public Sprite icon;
    public int increaseValue;
    public Type type;


    public enum Type
    {
        Health,
        Mana
    }
}

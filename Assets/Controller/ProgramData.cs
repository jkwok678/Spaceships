using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProgramData", menuName = "Program Data", order = 51)]
public class ProgramData : ScriptableObject {
    [SerializeField] public int id {get;set;}
    [SerializeField] public string currentName {get;set;}
    [SerializeField] public int currentHighScore {get;set;}
}




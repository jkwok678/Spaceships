using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramData : ScriptableObject {
    private Profile currentProfile {get;set;}
}

class Profile {
    string name {get;set;}
    DateTime lastPlayed{get;set;}

}


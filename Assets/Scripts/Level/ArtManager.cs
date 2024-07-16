using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        NONE,
        TYPE_01,
        TYPE_02,
        TYPE_03
    }

    public List<ArtSetup> artSetups = new List<ArtSetup>();
    public ArtSetup GetSetupByType(ArtType artType)
    {
        return artSetups.Find(setup => setup.artType == artType);
    }

}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;

}
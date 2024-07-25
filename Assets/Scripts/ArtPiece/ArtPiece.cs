using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject currentArt;


    public void ChangePiece(GameObject newPiece)
    {
        if (currentArt != null) { Destroy(currentArt); }
        currentArt = Instantiate(newPiece, transform);
        //currentArt.transform.localPosition = Vector3.zero;
        currentArt.GetComponent<Renderer>().material = ColorManager.Instance.materials[1];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera;

    
    // Start is called before the first frame update
    void Start()
    {

        if (virtualCamera != null)
        {
            virtualCamera.LookAt = PlayerController.Instance.transform;
            virtualCamera.Follow = PlayerController.Instance.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame()
    {
        PlayerController.Instance.StartGame();
    }

}

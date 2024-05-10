using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollectable : ItemCollectableBase
{

    //public Collider collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    protected override void OnCollect()
    {
        //base.OnCollect();
        GetComponent<Collider>().enabled = false;
        collect = true;
        //PlayerController.Instance.Bounce();
    }



    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                base.OnCollect();
            }
        }
    }


}
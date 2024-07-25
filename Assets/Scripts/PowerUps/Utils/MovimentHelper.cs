using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;
    public float duration = 1.0f;
    private int _index = 0;

    private void NextIndex()
    {
        _index++;
        if ( _index >= positions.Count ) { _index = 0; }
    }

    IEnumerator StartMoviment()
    {
        float time = 0;

        while (true)
        {
            var currentPostion = transform.position;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPostion, positions[_index].transform.position, time/duration) ;
                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;

        }
    }

    private void Init()
    {
        transform.position = positions[0].transform.position;
        StartIndex();
    }

    private void StartIndex()
    {
        _index = Random.Range( 0, positions.Count );
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
        StartCoroutine(StartMoviment());    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

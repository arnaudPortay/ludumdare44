using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DanceManager : MonoBehaviour
{
    bool danceStarted;
    public GameObject player;

    public List<DanceMove> danceMoves;

    public GameObject crowdManager;

    // Start is called before the first frame update
    void Start()
    {
        danceStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class DanceMove
{
    List<KeyCode> keyCombination;
    string        name;

}
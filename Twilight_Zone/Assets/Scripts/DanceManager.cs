using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DanceManager : MonoBehaviour
{
    bool danceStarted;
    public GameObject player;

    public List<DanceMove> danceMoves;

    public GameObject crowdManager;

    public Sound_Manager lSoundManager;

    int currentMove;
    int currentStep;

    int cooldown;

    // Start is called before the first frame update
    void Start()
    {
        danceStarted = false;
        currentMove = 0;
        currentStep = 0;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown --;
        }
        
    }

    void FixedUpdate() {
        player.GetComponent<Player_Behaviour>().dancing = danceStarted;
    }

    void OnGUI()
    {
        Event m_Event = Event.current;

        if (m_Event.type == EventType.KeyDown && cooldown==0)
        {
             Debug.Log("Cooldown added"); 
            cooldown = 5;
            if (! danceStarted)
            {
                for (int i = 0; i < danceMoves.Count; i++)
                {
                    if (m_Event.Equals(Event.KeyboardEvent(danceMoves[i].keyCombination[0].ToString())))
                    {
                        Debug.Log("DanceStarted"); 
                        danceStarted = true;
                        currentMove = i;
                        currentStep = 1;
                        break;
                    }                
                }
            }
            else
            {
                DanceMove lMove = danceMoves[currentMove];
                Debug.Log("Dance continued :" + lMove);
                 if (m_Event.Equals(Event.KeyboardEvent(lMove.keyCombination[currentStep].ToString())))
                    {
                        Debug.Log("Dance continued for real"); 
                        currentStep++;
                        if 
                            (currentStep == lMove.keyCombination.Count)
                        {
                            Debug.Log("FInished"); 
                            danceStarted = false;
                            currentMove = 0;
                            currentStep = 0;
                            player.GetComponent<Animator>().SetTrigger(lMove.DanceName);
                            
                            lSoundManager.startMusic(lMove.DanceName);
                        }
                    }
                    else
                    {
                        danceStarted = false;
                        currentMove = 0;
                        currentStep = 0;
                    }
            }
            
        }
    }
}
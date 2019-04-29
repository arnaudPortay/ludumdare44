using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DanceManager : MonoBehaviour
{
    bool danceStarted;
    public bool dancefinished = false;
    public GameObject player;

    public List<DanceMove> danceMoves;

    public GameObject crowdManager;
    public GameObject danceCamera;
    public GameObject mainCamera;
    public Sound_Manager lSoundManager;

    int currentMove;
    int currentStep;
    DanceMove currentFinishedDance;
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

    }

    void OnGUI()
    {
        Event m_Event = Event.current;

        if (m_Event.type == EventType.KeyDown && cooldown==0)
        {
            cooldown = 5;
            if (! danceStarted)
            {
                if (dancefinished)
                {
                    //stop when the dance move has ended
                    if(!player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(currentFinishedDance.DanceName) || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                    {
                        dancefinished = false;
                    }
                }
                else
                {
                    if (m_Event.Equals(Event.KeyboardEvent(KeyCode.F.ToString())))
                    {
                        Debug.Log("Started"); 
                        danceStarted = true;
                    }
                }

            }
            else
            {
                if (currentStep == 0)
                {
                    for (int i = 0; i < danceMoves.Count; i++)
                    {
                        if (m_Event.Equals(Event.KeyboardEvent(danceMoves[i].keyCombination[0].ToString())))
                        {
                            //Debug.Log("DanceStarted"); 
                            currentMove = i;
                            currentStep = 1;
                            break;
                        }                
                    }
                    if 
                        (currentStep == 0)
                    {
                        danceStarted = false;
                    }
                }
                else
                {
                    DanceMove lMove = danceMoves[currentMove];
                    Debug.Log("Dance continued :" + lMove);
                    if (m_Event.Equals(Event.KeyboardEvent(lMove.keyCombination[currentStep].ToString())))
                    {
                        //Debug.Log("Dance continued for real"); 
                        currentStep++;
                        if 
                            (currentStep == lMove.keyCombination.Count)
                        {
                            //Debug.Log("FInished"); 
                            danceStarted = false;
                            dancefinished = true;
                            currentFinishedDance = lMove;
                            currentMove = 0;
                            currentStep = 0;
                            //player.GetComponent<Animator>().SetTrigger(lMove.DanceName);
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
            bool dancing = danceStarted || dancefinished;
            danceCamera.SetActive(dancing);
            mainCamera.SetActive(!dancing);
            player.GetComponent<Animator>().SetBool(currentFinishedDance.DanceName,dancefinished);
            player.GetComponent<Player_Behaviour>().dancing = dancing;
            if (!dancefinished)
            {
                currentFinishedDance = null;
            }
            
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DanceManager : MonoBehaviour
{
    bool danceStarted;
    public bool dancefinished = false;
    public GameObject player;

    public List<DanceMove> danceMoves;

    public GameObject crowdManager;
    public GameObject danceCamera;
    public GameObject mainCamera;
    public Sound_Manager soundManager;

    public GameObject enterDanceModeUI;

    public GameObject danceUIContainer;

    public GameController gameController;

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

        // Dynamically populate ui for dance moves
        if (danceUIContainer != null)
        {
            GameObject lTemplate = danceUIContainer.transform.GetChild(0).gameObject;

            // Iterate through dance moves
            for (int i = 0; i < danceMoves.Count; i++)
            {
                // Copy template
                GameObject lClone = Instantiate(lTemplate, lTemplate.transform.position, lTemplate.transform.rotation);
                lClone.transform.SetParent(danceUIContainer.transform,false);
                // Set name
                lClone.GetComponentInChildren<TextMeshProUGUI>().text = danceMoves[i].DanceName;
                
                if (danceMoves[i].keyImages.Count > 0)
                {
                    // Set first image
                    Image lBaseImage = lClone.GetComponentInChildren<Image>();
                    lBaseImage.sprite = danceMoves[i].keyImages[0];

                    //Iterate through remaining images
                    for (int j = 1; j < danceMoves[i].keyImages.Count; j++)
                    {
                        // Clone image
                        GameObject lImageClone = Instantiate(lBaseImage.gameObject, lBaseImage.gameObject.transform.position, lBaseImage.gameObject.transform.rotation);
                        lImageClone.transform.SetParent(lClone.transform,false);
                        // Set correct sprite
                        lImageClone.GetComponent<Image>().sprite = danceMoves[i].keyImages[j];
                        // Reposition image
                        lImageClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(lImageClone.GetComponent<RectTransform>().anchoredPosition.x + 70*j, 
                                                                                                 lImageClone.GetComponent<RectTransform>().anchoredPosition.y);
                    }
                }

                // Reposition clone
                lClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(lClone.GetComponent<RectTransform>().anchoredPosition.x, 
                                                                                    lClone.GetComponent<RectTransform>().anchoredPosition.y + 70*i);
            }

            //Deleting template
            Destroy(lTemplate);            
        }
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
        if (gameController.gameStarted)
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
                                soundManager.startMusic(lMove.DanceName);
                                player.GetComponent<ParticleSystem>().Play();
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
                refreshStatus();
                
            }
            else if (m_Event.type == EventType.MouseDown)
            {       
                danceStarted = false;
                dancefinished = false;
                refreshStatus();
            }            
        }
    }

    void refreshStatus()
    {
        bool dancing = danceStarted || dancefinished;
        danceCamera.SetActive(dancing);
        mainCamera.SetActive(!dancing);
        if
            (currentFinishedDance)
        {
            player.GetComponent<Animator>().SetBool(currentFinishedDance.DanceName,dancefinished);            
        }
        Player_Behaviour lBehaviour = player.GetComponent<Player_Behaviour>();
        lBehaviour.dancing = dancing;
        lBehaviour.distanceWeapon.SetActive(!dancing);
        lBehaviour.meleeWeapon.SetActive(!dancing);
        if (enterDanceModeUI != null)
        {
            enterDanceModeUI.SetActive(!dancing);
        }

        if (danceUIContainer != null)
        {
            danceUIContainer.SetActive(dancing);
        }

        if (!dancing)
        {
            player.GetComponent<ParticleSystem>().Stop();            
        }
        
        if (!dancefinished)
        {
            currentFinishedDance = null;
        }
    }
}
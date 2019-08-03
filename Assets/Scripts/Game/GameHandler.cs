using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;



public class GameHandler : MonoBehaviour
{
    public static float slowdownFactor = 1;
    public static string lvl = "-1";
    [SerializeField] Image processingImage;
    [SerializeField] Slider slowDownSlider;

    public Fungus.Flowchart lvl4Flowchart;

    bool isConsoleHacked = false;

    //[SerializeField] Animator animator;

    Color processingEnabledColor = new Color(0f, 119f, 255f, 0.8f);
    Color processingDisabledColor = new Color(0f, 119f, 255f, 0f);

    bool IsSlowedDown = false;
    bool isSlowAllowed = true;

    public static List<ITimeScalable> interfaceScripts = new List<ITimeScalable>();

    //public RainSimulation rainSimulation;
    public Fungus.Flowchart fungusBlock;

    //[SerializeField] Animator secondDoorAnimator;
    //IEnumerator sliderDecreaseCo;
    //IEnumerator sliderIncreaseCo;

    Coroutine slowDownStart;
    bool IsFirstTimeTrigger = true;


    private void Start()
    {
       
        //sliderDecreaseCo = DecreaseSlider(slowDownSlider);
        //sliderIncreaseCo = IncreaseSlider(slowDownSlider);
    }

    private void Update()
    {
        Debug.Log(lvl);
        if (Input.GetButtonDown("Fire1") && !IsSlowedDown && isSlowAllowed)
        {

            SlowDown();

        }
        else if (Input.GetButtonDown("Fire1") && isSlowAllowed)
        {
            if (IsSlowedDown)
            {
                ResetNormalSpeed();
            }
        }


    }

    void SlowDown()
    {
        if (slowDownStart != null)
            StopCoroutine(slowDownStart);
        slowdownFactor = 0.25f;
        foreach (var obj in interfaceScripts)
        {
            if (obj != null)
                obj.SlowDown();
        }
        //secondDoorAnimator.speed = slowdownFactor;
        //rainSimulation.SlowDownRain();
        slowDownStart = StartCoroutine(DecreaseSlider(slowDownSlider));
        processingImage.color = processingEnabledColor;
        IsSlowedDown = true;
        
    }


    void ResetNormalSpeed()
    {
        if (slowDownStart != null)
            StopCoroutine(slowDownStart);
        slowdownFactor = 1;
        foreach (var obj in interfaceScripts)
        {
            if(obj != null)
                obj.ResetSpeed();
        }
        //secondDoorAnimator.speed = 3f;
        slowDownStart = StartCoroutine(IncreaseSlider(slowDownSlider));
        slowDownSlider.value = 100;
        //rainSimulation.ResetRainSpeed();
        processingImage.color = processingDisabledColor;
        IsSlowedDown = false;
        

    }

    IEnumerator DecreaseSlider(Slider slider)
    {

        if (slider != null)
        {
            float timeSlice = (100 / 10);
            while (slider.value >= 0)
            {
                slider.value -= timeSlice;
                yield return new WaitForSeconds(1);
                if (slider.value <= 0)
                {
                    //timeSlice = (100 / 5);
                    ResetNormalSpeed();

                }

            }
        }
        yield return null;
    }

    IEnumerator IncreaseSlider(Slider slider)
    {
        if (slider != null)
        {
            float timeSlice = (100 / 5);
            while (slider.value <= 100)
            {
                slider.value += timeSlice;
                yield return new WaitForSeconds(1);
                if (slider.value >= 100)
                {
                    if(IsFirstTimeTrigger && lvl.Equals("-1"))
                    {
                        IsFirstTimeTrigger = false;
                        fungusBlock.SendFungusMessage("TriggerContinue");
                    }
                    break;
                }

            }

        }
        yield return null;
    }

    public void EnableSlowDown()
    {
        isSlowAllowed = true;
    }

    public void DisableSlowDown()
    {
        isSlowAllowed = false;
    }

    void FirstTimePowerTrigger()
    {
        SlowDown();
        processingImage.color = processingEnabledColor;
        IsSlowedDown = true;
        slowdownFactor = 0.5f;
        //rainSimulation.SlowDown();
    }


    public void SetIsLvl4ConsoleHackable(bool isHackable)
    {
        lvl4Flowchart.SetBooleanVariable("Hackable", isHackable);
    }
}

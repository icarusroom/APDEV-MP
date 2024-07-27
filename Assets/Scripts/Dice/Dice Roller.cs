using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    public GameObject dice;
    public float shakeThreshold = 2.0f;
    public float shakeTimeout = 1.0f;

    private Vector3 acceleration;
    private float lastShakeTime;
    private DiceFaceDetector diceFaceDetector;
    private bool hasRolled;
    private bool adWatched;

    [SerializeField] private GameObject finishButton;
    [SerializeField] private GameObject shakeText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text resultValueText;
    [SerializeField] private GameObject adsButton;
    [SerializeField] private NPC_TapReceiver npcTapReceiver;

    void Start()
    {
        diceFaceDetector = dice.GetComponent<DiceFaceDetector>();
        hasRolled = false;
        adWatched = false;
        finishButton.SetActive(false);
        shakeText.SetActive(true);
        adsButton.SetActive(false);
    }

    void Update()
    {
        if (!hasRolled)
        {
            acceleration = Input.acceleration;

            if (acceleration.sqrMagnitude >= shakeThreshold * shakeThreshold && Time.time >= lastShakeTime + shakeTimeout)
            {
                lastShakeTime = Time.time;
                RollDice();
                shakeText.SetActive(false);
            }
        }
    }

    void RollDice()
    {
        Rigidbody rb = dice.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(Random.onUnitSphere * 5.0f, ForceMode.Impulse);
            rb.AddTorque(Random.onUnitSphere * 10.0f, ForceMode.Impulse);
        }

        if (diceFaceDetector != null)
        {
            diceFaceDetector.StartRolling();
        }

        hasRolled = true;

        if (hasRolled)
        {
            StartCoroutine(Result());

            finishButton.SetActive(true);
        }
    }

    private IEnumerator Result()
    {
        int playerStat = PlayerPrefs.GetInt(RequirementProperties.playerOpt, 0);
        int diceBonus = 0;

        Debug.Log($"Option Chosen: {RequirementProperties.OptionChosen}");
        Debug.Log($"Player Stat: {playerStat}");
        Debug.Log($"Dialogue Option Requirement: {RequirementProperties.statsRequirement}");

        yield return new WaitForSeconds(7f);
        int diceRoll = DiceRollProperties.DiceRollResult;

        if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_SUCCEED)
        {
            resultText.text = "SUCCESS";
            resultValueText.text = diceRoll.ToString();
            Debug.Log("SUCCESS (FORCED SUCCESS)");
        }
        else if (DeveloperProperties.DiceRoll == EDiceRoll.DICE_ROLL_FAIL)
        {
            FailedRoll(diceRoll);
            Debug.Log("FAILED (FORCED FAIL)");
        }
        else
        {
            if (RequirementProperties.OptionChosen == 1)
            {
                if (playerStat >= DialogueStats.Option1)
                {
                    diceBonus = playerStat > 10 ? playerStat - 10 : 0;
                    Debug.Log($"Dice Bonus: {diceBonus}");

                    if ((diceRoll + diceBonus) >= DialogueStats.Option1)
                    {
                        resultText.text = "SUCCESS";
                        resultValueText.text = diceRoll.ToString();
                        Debug.Log("SUCCESS (DICE SCENE RESULT)");
                    }
                    else
                    {
                        FailedRoll(diceRoll);
                    }
                }
                else
                {
                    if (diceRoll >= DialogueStats.Option1 + 1)
                    {
                        resultText.text = "SUCCESS";
                        resultValueText.text = diceRoll.ToString();
                        Debug.Log("SUCCESS (DICE SCENE RESULT)");
                    }
                    else
                    {
                        FailedRoll(diceRoll);
                    }
                }
            }
            else if (RequirementProperties.OptionChosen == 2)
            {
                if (playerStat >= DialogueStats.Option2)
                {
                    diceBonus = playerStat > 10 ? playerStat - 10 : 0;
                    Debug.Log($"Dice Bonus: {diceBonus}");

                    if ((diceRoll + diceBonus) >= DialogueStats.Option2)
                    {
                        resultText.text = "SUCCESS";
                        resultValueText.text = diceRoll.ToString();
                        Debug.Log("SUCCESS (DICE SCENE RESULT)");
                    }
                    else
                    {
                        FailedRoll(diceRoll);
                    }
                }
                else
                {
                    if (diceRoll >= DialogueStats.Option2 + 1)
                    {
                        resultText.text = "SUCCESS";
                        resultValueText.text = diceRoll.ToString();
                        Debug.Log("SUCCESS (DICE SCENE RESULT)");
                    }
                    else
                    {
                        FailedRoll(diceRoll);
                    }
                }
            }
        }
    }

    private void FailedRoll(int diceRoll)
    {
        resultText.text = "FAILED";
        resultValueText.text = diceRoll.ToString();
        if (adWatched == false)
        {
            adsButton.SetActive(true);
        }
        Debug.Log("FAILED (DICE SCENE RESULT)");
    }

    public void ResetDiceRoll()
    {
        hasRolled = false;
        adWatched = true;
        finishButton.SetActive(false);
        shakeText.SetActive(true);
        adsButton.SetActive(false);
        resultText.text = "";
        resultValueText.text = "";
    }
}

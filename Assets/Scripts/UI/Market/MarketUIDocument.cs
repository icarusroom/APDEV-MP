using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MarketUIDocument : MonoBehaviour
{
    private VisualElement _root;
    private VisualElement _dialogueBox;
    private Button _option1;
    private Button _option2;
    private Button _option3;
    private Button _option4;

    private void Start()
    {
        this._root = GetComponent<UIDocument>().rootVisualElement;
        this._dialogueBox = this._root.Q<VisualElement>("DialogueBoxContainer");
        this._option1 = this._root.Q<Button>("Option_1");
        this._option2 = this._root.Q<Button>("Option_2");
        this._option3 = this._root.Q<Button>("Option_3");
        this._option4 = this._root.Q<Button>("Option_4");

        this._option1.clicked += this.OnOption1Clicked;
        this._option2.clicked += this.OnOption2Clicked;
        this._option3.clicked += this.OnOption3Clicked;
        this._option4.clicked += this.OnOption4Clicked;

        this.HideDialogueBox();

        EventBroadcaster.Instance.AddObserver(EventNames.NPC_Dialogue_Events.ON_NPC_TAPPED, this.ShowDialogueBox);
        EventBroadcaster.Instance.AddObserver(EventNames.NPC_Dialogue_Events.ON_NPC_NOT_IN_RANGE, this.HideDialogueBox);

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.NPC_Dialogue_Events.ON_NPC_TAPPED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.NPC_Dialogue_Events.ON_NPC_NOT_IN_RANGE);
    }

    private void OnOption1Clicked()
    {
        Debug.Log("Option_1 Clicked");
    }

    private void OnOption2Clicked()
    {
        Debug.Log("Option_2 Clicked");
    }

    private void OnOption3Clicked()
    {
        Debug.Log("Option_3 Clicked");
    }

    private void OnOption4Clicked()
    {
        this.HideDialogueBox();
    }

    private void HideDialogueBox()
    {
        this._dialogueBox.style.visibility = Visibility.Hidden;
    }

    private void ShowDialogueBox()
    {
        this._dialogueBox.style.visibility = Visibility.Visible;
    }
}

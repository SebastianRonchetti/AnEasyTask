using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour {
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;
    private DialogueUI _dialogueUI;
    private ResponseEvent[] responseEvents;

    List<GameObject> tempResponseButtons = new List<GameObject>();

    public void addResponseEvents(ResponseEvent[] _responseEvents) {
        responseEvents = _responseEvents;
    }
    private void Start() {
        _dialogueUI = DialogueUI.Instance;
    }

    //Displays the responses provided on function call
    public void ShowResponses(Response[] responses) {
        float responseBoxHeight = 0f;
        for (int i = 0; i < responses.Length; i++) {
            Response response = responses[i];
            int responseIndex = i;

            //Creates a response button for current listed response in the response array based on a template
            //button
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.responseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));
            
            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    //Called when a response is picked from the available responses associated with displayed dialogue
    void OnPickedResponse(Response response, int responseIndex) {
        //Destroys the response boxes and resets the base response button values
        responseBox.gameObject.SetActive(false);

        foreach(GameObject button in tempResponseButtons){
            Destroy(button);
        }

        tempResponseButtons.Clear();

        //if there are any events associated with the picked response invoke them
        if(responseEvents != null && responseIndex <= responseEvents.Length) {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        responseEvents = null;
        if(response.DObject){
            _dialogueUI.ShowDialogue(response.DObject);
        } else {
            _dialogueUI.CloseDialogueBox();
        }
    }
}
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
    public void ShowResponses(Response[] responses) {
        float responseBoxHeight = 0f;

        for (int i = 0; i < responses.Length; i++) {
            Response response = responses[i];
            int responseIndex = i;

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

    void OnPickedResponse(Response response, int responseIndex) {
        responseBox.gameObject.SetActive(false);

        foreach(GameObject button in tempResponseButtons){
            Destroy(button);
        }

        tempResponseButtons.Clear();

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
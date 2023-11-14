using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ArticleUI : SingletonClass<DialogueUI> {
    [SerializeField] private GameObject ArticlePopUp;
    [SerializeField] private List<TMP_Text> paragraphs;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Vector2[] _ImageLocations;
    public bool IsOpen {get; private set;}

    private void Awake() {
        _instantiate();
    }

    void showArticle(){
        IsOpen = true;
        ArticlePopUp.SetActive(true);
    }

    public void CloseDialogueBox() {
        IsOpen = false;
        title.text = string.Empty;
        foreach(TMP_Text para in paragraphs){
            para.text = string.Empty;
        }
        ArticlePopUp.SetActive(false);
    }
}
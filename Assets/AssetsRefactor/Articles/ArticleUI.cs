using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ArticleUI : SingletonClass<DialogueUI> {
    [SerializeField] private GameObject ArticlePopUp;
    [SerializeField] private List<TMP_Text> paragraphs;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Image[] _Images;
    [SerializeField] private TMP_Text pageIndex;
    [SerializeField] private Button backBtn, nextBtn, exitBtn;
    int activePageIndex;
    public bool IsOpen {get; private set;}

    ArticleSO CurrentlyActiveArticle;

    private void Awake() {
        _instantiate();
    }

    private void Start() {
        ManagerToOutMiddle.OnShowArticleAction += openArticle;
    }

    void showArticleUI(){
        IsOpen = true;
        ArticlePopUp.SetActive(true);
    }

    public void CloseArticle() {
        IsOpen = false;
        title.text = string.Empty;
        foreach(TMP_Text para in paragraphs){
            para.text = string.Empty;
        }
        ArticlePopUp.SetActive(false);
        CurrentlyActiveArticle = null;
    }

    void openArticle(ArticleSO Article) {
        showArticleUI();
        CurrentlyActiveArticle = Article;
        title.text = Article.Title;
        SetPage(CurrentlyActiveArticle.Pages[0]);
    }
    void SetPage(ArticlePageSO page){
        SetPageContent(page);
        SetPageIndex(page);
        SetInteractables();
    }

    void SetPageContent(ArticlePageSO page){
        for(int i = 0; i < page.Paragraphs.Length; i++){
            paragraphs[i].text = page.Paragraphs[i];
        }

        for(int i = 0; i < page.ArticleImages.Length; i++){
            _Images[i] = page.ArticleImages[i];
        }
    }
    void SetPageIndex(ArticlePageSO page){
        for(int i = 0; i < CurrentlyActiveArticle.Pages.Length; i++){
            if(CurrentlyActiveArticle.Pages[i] == page){
                activePageIndex = i;
                pageIndex.text = string.Format($"{activePageIndex} / {CurrentlyActiveArticle.Pages.Length}");
            }
        }
    }

    void previousPage(){
        if(activePageIndex - 1 > 0) {
            activePageIndex --;
            SetPage(CurrentlyActiveArticle.Pages[activePageIndex]);
        }
    }
    void nextPage() {
        if(activePageIndex + 1 < CurrentlyActiveArticle.Pages.Length) {
            activePageIndex ++;
            SetPage(CurrentlyActiveArticle.Pages[activePageIndex]);
        }
    }

    void SetInteractables(){
        nextBtn.onClick.AddListener(this.nextPage);
        backBtn.onClick.AddListener(this.previousPage);
        exitBtn.onClick.AddListener(this.CloseArticle);
        
        if(activePageIndex < CurrentlyActiveArticle.Pages.Length){
            nextBtn.enabled = true;
        } else {
            nextBtn.enabled = false;
        }

        if(activePageIndex - 1 > 0){
            backBtn.enabled = true;
        } else {
            backBtn.enabled = false;
        }
    }
}
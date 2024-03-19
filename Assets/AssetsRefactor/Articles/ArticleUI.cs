using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

// Manager for article UI

// TROUBLESHOOTING:
//  - Article header must auto fit.
public class ArticleUI : SingletonClass<ArticleUI> {
    [SerializeField] private GameObject ArticlePopUp;
    /* [SerializeField] private List<TMP_Text> paragraphs; */
    [SerializeField] private TMP_Text paragraph;
    [SerializeField] private TMP_Text title;
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
        SetInteractables();
        CloseArticle();
    }
//Displays article interface
    void showArticleUI(){
        IsOpen = true;
        ArticlePopUp.SetActive(true);
    }
// Closes article interface and set it's components to empty.
    public void CloseArticle() {
        IsOpen = false;
        title.text = string.Empty;
        paragraph.text = string.Empty;
        paragraph.gameObject.SetActive(false);
        /* foreach(TMP_Text para in paragraphs){
            para.text = string.Empty;
            para.gameObject.SetActive(false);
        } */
        ArticlePopUp.SetActive(false);
        CurrentlyActiveArticle = null;
    }

// Displays UI and triggers set up for the first page.
    void openArticle(ArticleSO Article) {
        showArticleUI();
        CurrentlyActiveArticle = Article;
        title.text = Article.Title;
        SetPage(CurrentlyActiveArticle.Pages[0]);
    }
// Sets page text contets to the one inputted.
    void SetPage(string content){
        paragraph.text = content; 
        for(int i = 0; i < CurrentlyActiveArticle.Pages.Length; i++){
            if(content == CurrentlyActiveArticle.Pages[i]){
                activePageIndex = i;
                pageIndex.text = string.Format($"{activePageIndex + 1} / {CurrentlyActiveArticle.Pages.Length}");
            }
        }
        updateInteractables();
    } 
/* 
    void SetPage(ArticlePageSO page){
        SetPageContent(page);
        SetPageIndex(page);
        updateInteractables();
    }
*/
// Fills out the paragraph text boxes with the page content
/*     
    void SetPageContent(ArticlePageSO page){
        for(int i = 0; i < page.Paragraphs.Length; i++){
            paragraphs[i].text = page.Paragraphs[i];
            paragraphs[i].gameObject.SetActive(true);
        }
    } */


// Sets index page 
 /*    void SetPageIndex(ArticlePageSO page){
        for(int i = 0; i < CurrentlyActiveArticle.Pages.Length; i++){
            if(CurrentlyActiveArticle.Pages[i] == page){
                activePageIndex = i;
                pageIndex.text = string.Format($"{activePageIndex + 1} / {CurrentlyActiveArticle.Pages.Length}");
            }
        }
    } */

    void previousPage(){
        if(activePageIndex > 0) {
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
        nextBtn.onClick.AddListener(() => nextPage());
        backBtn.onClick.AddListener(() => previousPage());
        exitBtn.onClick.AddListener(() => CloseArticle());
    }
// Checks for amount of pages before and after the displayed page and allows interaction of UI elements.
    void updateInteractables(){
        if(activePageIndex < CurrentlyActiveArticle.Pages.Length){
            nextBtn.enabled = true;
        } else {
            nextBtn.enabled = false;
        }

        if(activePageIndex > 0){
            backBtn.enabled = true;
        } else {
            backBtn.enabled = false;
        }
    }
}


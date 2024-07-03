using UnityEngine;
using System.Collections.Generic;

public class ArticleManager : MonoBehaviour
{
    [SerializeField] ArticleStorySO[] _listOfArticles;
    [SerializeField] ArticleStorySO[] _listOfStories;
    public ArticleStorySO[] ListOfArticles => _listOfArticles;
    public ArticleStorySO[] ListOfStories => _listOfStories;
    public void ActivateRandomArticle(){
        if(_listOfArticles.Length == 1) {
            OpenArticle(_listOfArticles[0]);
        } else {
            int rand = Mathf.RoundToInt(Random.Range(1, _listOfArticles.Length + 1)) - 1;
            OpenArticle(_listOfArticles[rand]);
        }
    }

    
    public void ActivateRandomStory(){
        if(_listOfStories.Length == 1) {
            OpenArticle(_listOfStories[0]);
        } else {
            int rand = Mathf.RoundToInt(Random.Range(1, _listOfStories.Length + 1)) - 1;
            OpenArticle(_listOfStories[rand]);
        }
    }

    void OpenArticle(ArticleStorySO articleToOpen){
        ManagerToOutMiddle.OnShowArticleAction(articleToOpen);
    }
}

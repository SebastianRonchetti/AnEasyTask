using UnityEngine;
using System.Collections.Generic;

public class ArticleManager : MonoBehaviour
{
    [SerializeField] ArticleSO[] _listOfArticles;
    public ArticleSO[] ListOfArticles => _listOfArticles;
    public void ActivateRandomArticle(){
        if(_listOfArticles.Length == 1) {
            OpenArticle(_listOfArticles[0]);
        } else {
            int rand = Mathf.RoundToInt(Random.Range(1, _listOfArticles.Length + 1)) - 1;
            OpenArticle(_listOfArticles[rand]);
        }
    }

    void OpenArticle(ArticleSO articleToOpen){
        ManagerToOutMiddle.OnShowArticleAction(articleToOpen);
    }
}

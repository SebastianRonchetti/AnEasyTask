using UnityEngine;
using System.Collections.Generic;

public class ArticleManager : MonoBehaviour
{
    [SerializeField] ArticleSO[] _listOfArticles;
    public ArticleSO[] ListOfArticles => _listOfArticles;
    public void ActivateRandomArticle(){
        Debug.Log("Received");
        if(_listOfArticles.Length == 1) {
            OpenArticle(_listOfArticles[0]);
        } else {
            int rand = Mathf.RoundToInt(Random.Range(0, _listOfArticles.Length));
            OpenArticle(_listOfArticles[rand]);
        }
    }

    void OpenArticle(ArticleSO articleToOpen){
        Debug.Log("Script active, Article received");
        ManagerToOutMiddle.OnShowArticleAction(articleToOpen);
    }
}

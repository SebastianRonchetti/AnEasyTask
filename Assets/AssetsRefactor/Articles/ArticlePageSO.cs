using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ArticlePageSO", menuName = "AnEasyTaskv0.1/ArticlePageSO", order = 1)]
public class ArticlePageSO : ScriptableObject {
    [SerializeField] private string[] _paragraphs;
    [SerializeField] private Sprite[] _articleImages;

    public string[] Paragraphs => _paragraphs;
    public Sprite[] ArticleImages => _articleImages;
}
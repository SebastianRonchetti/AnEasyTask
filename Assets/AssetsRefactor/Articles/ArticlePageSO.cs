using UnityEngine;
using UnityEngine.UI;

public class ArticlePageSO : ScriptableObject {
    [SerializeField] private string[] _paragraphs;
    [SerializeField] private Image[] _articleImages;

    public string[] Paragraphs => _paragraphs;
    public Image[] ArticleImages => _articleImages;
}
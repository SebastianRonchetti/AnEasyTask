using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "ArticleSO", menuName = "AnEasyTaskv0.1/ArticleSO", order = 0)]
public class ArticleSO : ScriptableObject {
    [SerializeField] private List<string> _articleParagraphs;
    [SerializeField] private string _title;
    [SerializeField] private Image[] _articlePictures;
    public List<string> ArticleParagraphs => _articleParagraphs;
    public string Title => _title;
    public Image[] ArticlePictures => _articlePictures;
}
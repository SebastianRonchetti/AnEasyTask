using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "ArticleStorySO", menuName = "AnEasyTaskv0.1/ArticleStorySO", order = 0)]
public class ArticleStorySO : ScriptableObject {
    [SerializeField] private string[] _pages;
    [SerializeField] private string _title;
    public string Title => _title;
    public string[] Pages => _pages;
}
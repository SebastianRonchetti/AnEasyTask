using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "ArticleSO", menuName = "AnEasyTaskv0.1/ArticleSO", order = 0)]
public class ArticleSO : ScriptableObject {
    [SerializeField] private string[] _pages;
    [SerializeField] private string _title;
    public string Title => _title;
    public string[] Pages => _pages;
}
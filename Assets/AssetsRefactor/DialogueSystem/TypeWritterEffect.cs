using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class TypeWritterEffect : MonoBehaviour {

    float writingSpeed = 50f;
    public bool isRunning {get; private set;}
    private readonly List<Punctuation> punctuations = new List<Punctuation>() {
        new Punctuation(new HashSet<char>(){'!', '.', '?'}, 0.6f),
        new Punctuation(new HashSet<char>(){',', ';', ':'}, 0.3f)
    };

    Coroutine typingCoroutine;
    public void Run(string textToType, TMP_Text meshText) {
        typingCoroutine = StartCoroutine(TypeoutText(textToType, meshText));
    }

    public void Stop() {
        StopCoroutine(typingCoroutine);
        isRunning = false;
    }

    private IEnumerator TypeoutText(string textToType, TMP_Text meshText) {
        float t = 0;
        int charIndex = 0;
        isRunning = true;

        meshText.text = string.Empty;

        while(charIndex < textToType.Length) {
            int lastCharacterIndex = charIndex;

            t += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for(int i = lastCharacterIndex; i < charIndex; i++){
                bool isLast = i >= textToType.Length - 1;
                meshText.text = textToType.Substring(0, i + 1);

                if(IsPunctuation(textToType[i], out float waitTime) 
                    && !isLast && IsPunctuation(textToType[i + 1], out float _)) {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        isRunning = false;
    }

    private bool IsPunctuation (char character, out float waitTime){
        foreach(Punctuation punctuationCategory in punctuations){
            if(punctuationCategory.punctuations.Contains(character)){
                waitTime = punctuationCategory.waitTime;
                return true;
            }
        }
        waitTime = default;
        return false;
    }
    public readonly struct Punctuation {
        public readonly HashSet<char> punctuations;
        public readonly float waitTime;

        public Punctuation (HashSet<char> _punctuations, float _waitTime){
            punctuations = _punctuations;
            waitTime = _waitTime;
        }
    }
}
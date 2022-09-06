using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoreanTyper;
using UnityEngine.UI;
using KoreanTyper;

public class KoreanTyperDemo_Auto : MonoBehaviour {
    public Text[] TestTexts;

    private void Start() {
        StartCoroutine(TypingText());
    }

    public IEnumerator TypingText() {
        while (true) {
            string[] strings = new string[3]{ "20XX년 X월 X일 X요일 오후 HH시 MM분",
                                              "유니티 한글 타이퍼 오토 타이핑 데모 씬",
                                              "이 데모는 자동으로 작성되고 있습니다." };
            foreach (Text t in TestTexts)
                t.text = "";

            for (int t = 0; t < TestTexts.Length && t < strings.Length; t++) {
                int strTypingLength = strings[t].GetTypingLength();

                for (int i = 0; i <= strTypingLength; i++) {
                    TestTexts[t].text = strings[t].Typing(i);
                    yield return new WaitForSeconds(0.03f);
                }
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}


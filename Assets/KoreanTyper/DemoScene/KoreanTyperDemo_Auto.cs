using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                                  // Add KoreanTyper namespace | 네임 스페이스 추가

//===================================================================================================================
//  Auto Demo
//  자동으로 글자가 입력되는 데모
//===================================================================================================================
public class KoreanTyperDemo_Auto : MonoBehaviour {
    public Text[] TestTexts;

    private void Start() {
        StartCoroutine(TypingText());
    }

    public IEnumerator TypingText() {
        while (true) {
            //=======================================================================================================
            // Initializing | 초기화
            //=======================================================================================================
            string[] strings = new string[3]{ "20XX년 X월 X일 X요일 오후 HH시 MM분",
                                              "유니티 한글 타이퍼 오토 타이핑 데모 씬",
                                              "이 데모는 자동으로 작성되고 있습니다." };
            foreach (Text t in TestTexts)
                t.text = "";
            //=======================================================================================================


            //=======================================================================================================
            //  Typing effect | 타이핑 효과
            //=======================================================================================================
            for (int t = 0; t < TestTexts.Length && t < strings.Length; t++) {
                int strTypingLength = strings[t].GetTypingLength();

                for (int i = 0; i <= strTypingLength; i++) {
                    TestTexts[t].text = strings[t].Typing(i);
                    yield return new WaitForSeconds(0.03f);
                }
                // Wait 1 second per 1 sentence | 한 문장마다 1초씩 대기
                yield return new WaitForSeconds(1f);
            }
            // Wait 1 second at the end | 마지막에 1초 추가 대기함
            yield return new WaitForSeconds(1f);
        }
    }
}


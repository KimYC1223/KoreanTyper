using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                                  // Add KoreanTyper namespace | 네임 스페이스 추가

//===================================================================================================================
//  Simple  Demo
//  간단한 데모
//===================================================================================================================
public class KoreanTyperDemo_Simple : MonoBehaviour {
    public Text TestText;
    public Slider TestSldier;

    //===============================================================================================================
    // Initializing | 초기화
    //===============================================================================================================
    private void Start() {
        OnTestSliderChange();
    }

    //===============================================================================================================
    // On Test Slider Change | 테스트 슬라이드가 변경 될 때 마다 호출되는 함수
    //===============================================================================================================
    public void OnTestSliderChange() {
        TestText.text = "2022년 어느 한 여름날.\n난 그 날을 잊을 수 없다.".Typing(TestSldier.value);
    }
}

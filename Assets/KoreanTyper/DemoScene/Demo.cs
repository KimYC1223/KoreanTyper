using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoreanTyper;
using UnityEngine.UI;

public class Demo : MonoBehaviour {
    public Text TestText;
    public Slider TestSldier;

    public void OnTestSliderChange() {
        TestText.text = "동해물과 백두산이 마르고 닳도록 하느님이 보우하사 우리 나라만세".Typing(TestSldier.value);
    }
}

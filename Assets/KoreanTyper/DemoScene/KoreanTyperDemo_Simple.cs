using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoreanTyper;
using UnityEngine.UI;

public class KoreanTyperDemo_Simple : MonoBehaviour {
    public Text TestText;
    public Slider TestSldier;

    private void Start() {
        OnTestSliderChange();
    }

    public void OnTestSliderChange() {
        TestText.text = "2022년 어느 한 여름날.\n난 그 날을 잊을 수 없다.".Typing(TestSldier.value);
    }
}

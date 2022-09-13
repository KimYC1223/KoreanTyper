![logo Image](https://github.com/KimYC1223/KoreanTyper/blob/main/DocImage/Title.png?raw=true)

# Korean Typer

C# string class 키보드 한글 입력 효과 Extension

![](https://img.shields.io/github/stars/KimYC1223/KoreanTyper)  ![](https://img.shields.io/github/forks/KimYC1223/KoreanTyper) ![](https://img.shields.io/github/issues/KimYC1223/KoreanTyper) 

---

## 1. 소개

![Demo GIF](https://github.com/KimYC1223/KoreanTyper/blob/main/DocImage/KoreanTyperGif.gif?raw=true)

한글은 알파벳이나 한자와는 다르게 초성, 중성, 종성으로 이루어진 음절 단위를 사용합니다.

또한, string class의 가장 작은 기본 단위는 음절이기 때문에,

string의 각 원소를 하나씩 출력하게 된다면, 키보드로 입력하는 것이 아닌 정말 한 음절씩 나타나는 모습을 볼 수 있습니다.

이 패키지는 그러한 문제를 해결하기 위해

주어진 string 입력을 **마치 실제 키보드로 입력하는 것 처럼 보이는 효과를 주는** string class Extension입니다.

이 에셋은 Unity 엔진에서 사람이 문자열을 직접 타이핑 하는 듯 한 느낌을 스크립트로 쉽게 구현 할 수 있도록 도와줍니다.

| 플랫폼 |                             버전                             |
| :----: | :----------------------------------------------------------: |
| Unity  | <img src="https://img.shields.io/badge/Version-2017.1.0f3 ↑-orange" align="left"> |

<br>

<a href="https://github.com/KimYC1223/KoreanTyper/blob/main/LICENSE"><img src="https://img.shields.io/github/license/KimYC1223/KoreanTyper"></a> <a href="mailto:kau_esc@naver.com"><img src="https://img.shields.io/badge/Contact-kau_esc@naver.com-blue?logo=gmail&logoColor=white"></a> <a href="https://KimYC1223.github.io/"><img src="https://img.shields.io/badge/blog-GitBlog-red?logo=github&logoColor=white"></a>

<br>

---

<br>

## 2. 사용법

**KoreanTyper**는 아주 간단하게 사용 할 수 있습니다.


먼저, ```KoreanTyper``` 네임 스페이스를 사용한다는 코드를 스크립트의 상단에 배치합니다.

```C#
using KoreanTyper;
```

원하는 ```string```에 ```Typing()``` 함수를 사용합니다.

```
Debug.Log("안녕하세요".Typing(7));		// 출력 결과 : 안녕ㅎ
```

**이게 끝 입니다.** 참 쉽죠?

<br>

---

<br>

## 3. 더 자세한 사용법

**KoreanTyper**는 다음 3가지의 ```string Class Extension```을 제공합니다: 

- ```public int GetTypingLength()```
- ```public string Typing(int count)```
- ```public string Typing(float percent)```

<br>

### 3.1 ```public int GetTypingLength()```

해당 문장이 총 몇번의 타이핑으로 입력 할 수 있는지 반환하는 함수입니다.

예를 들어, ```"동해물과 백두산이 마르고 닳도록"```이라는 스트링은

총 ```22```회의 키보드 누름으로 입력할 수 있습니다.

|   동   |  해  |   물   |   과   | (띄움) |   백   |  두  |   산   |  이  |
| :----: | :--: | :----: | :----: | :----: | :----: | :--: | :----: | :--: |
| ㄷㅗㅇ | ㅎㅐ | ㅁㅜㄹ | ㄱㅗㅏ |   -    | ㅂㅐㄱ | ㄷㅜ | ㅅㅏㄴ | ㅇㅣ |
|   3    |  2   |   3    |   3    |   1    |   3    |  2   |   3    |  2   |

```public int GetTypingLength()```는 이 횟수를 리턴하는 함수입니다.

영어, 숫자, 특수 문자, 한글 자음, 쌍자음과 모음은 1회 입력으로 간주하고

```ㄳ```, ```ㄶ``` 와 같이 두 자음이 합쳐져 있거나

```ㅙ```, ```ㅞ```, ```ㅚ``` 와 같이 두 모음이 합쳐져 있는 경우는 2회 입력으로 간주합니다.

```C#
Debug.Log("동해물과 백두산이".GetTypingLength());		// 출력 결과 : 22
```

<br>

### 3.2 ```public string Typing(int count)```

```count```횟수 만큼 키보드를 눌렀을 때, 해당 문자가 어디까지 입력되는지 계산하고 이를 반환하는 함수입니다.

```count```가 ```0```이하면 ```""```을 리턴하고,

```count```가 해당 문자열의 ```GetTypingLength()```이상이면 해당 문자열을 그대로 리턴합니다.

```"안녕하세요"``` 라는 문자열을 예로 들면, 다음과 같습니다.

|                     |   안   |   녕   |  하  |  세  |  요  |
| ------------------: | :----: | :----: | :--: | :--: | :--: |
|                조합 | ㅇㅏㄴ | ㄴㅕㅇ | ㅎㅏ | ㅅㅔ | ㅇㅛ |
|      필요 타이핑 수 |   3    |   3    |  2   |  2   |  2   |
| 누적 필요 타이핑 수 |   3    |   6    |  8   |  10  |  12  |


| ```count``` 값 | ```"안녕하세요".Typing(count)``` 계산 결과 | 출력 결과  |
| :------------: | :----------------------------------------- | :--------- |
|       0        |                                            |            |
|       1        | ㅇ                                         | ㅇ         |
|       2        | ㅇㅏ                                       | 아         |
|       3        | ㅇㅏㄴ                                     | 안         |
|       4        | ㅇㅏㄴㄴ                                   | 안ㄴ       |
|       5        | ㅇㅏㄴㄴㅕ                                 | 안녀       |
|       6        | ㅇㅏㄴㄴㅕㅇ                               | 안녕       |
|       7        | ㅇㅏㄴㄴㅕㅇㅎ                             | 안녕ㅎ     |
|       8        | ㅇㅏㄴㄴㅕㅇㅎㅏ                           | 안녕하     |
|       9        | ㅇㅏㄴㄴㅕㅇㅎㅏㅅ                         | 안녕하ㅅ   |
|       10       | ㅇㅏㄴㄴㅕㅇㅎㅏㅅㅔ                       | 안녕하세   |
|       11       | ㅇㅏㄴㄴㅕㅇㅎㅏㅅㅔㅇ                     | 안녕하세ㅇ |
|       12       | ㅇㅏㄴㄴㅕㅇㅎㅏㅅㅔㅇㅛ                   | 안녕하세요 |

위 함수를 ```Update```함수나 ```Coroutine```안에 집어 넣어,

일정 시간마다 한 음절씩 입력되도록 구현하면 됩니다.

```
Debug.Log("안녕하세요".Typing(9));		// 출력 결과 : 안녕하ㅅ
```

<br>

### 3.3 ```public string Typing(float percent)```

몇 번에 걸쳐 진행 될 지 모르겠다면, 그냥  0~1 사이의 진행률로 입력해도 됩니다.

```percent```가 ```0```이하면 ```""```을 리턴하고,

```percent```가 ```1```이상이면 해당 문자열을 그대로 리턴합니다.

```percent```가 ```0```보다 크고, ```1```보다 작다면 진행률에 맞는 문자열을 리턴합니다.

```C#
Debug.Log("안녕하세요".Typing(0.845f));		// 출력 결과 : 안녕하세
```

<br>

---

<br>

## 4. 간단한 데모

본 코드는 ```Text``` UI에 문자열을 타이핑하는 효과를 주는 아주 간단한 예제입니다.

```C#
using KoreanTyper;			// Korean Typer 네임 스페이스 추가
using UnityEngine;
using UnityEngine.UI;

//======================================================================================
//  Simple  Demo
//  간단한 데모
//======================================================================================
public class KoreanTyperDemo : MonoBehaviour {
    public Text TestText;

    //==================================================================================
    // Initializing | 초기화
    //==================================================================================
    private void Start() {
        StartCoroutine(TypingCoroutine("동해물과 백두산이 마르고 닳도록"));
    }

    //==================================================================================
    // TypingCoroutine | 데모 코루틴
    //==================================================================================
    public IEnumerator TypingCoroutine(string str) {
        TestText.text = "";                                   // 초기화
        yield return new WaitForSeconds(1f);                  // 1초 대기
        
        int strTypingLength = str.GetTypingLength();          // 최대 타이핑 수 구함
        for(int  i = 0 ; i <= strTypingLength ; i ++ ) {      // 반복문
        	TestText.text = str.Typing(i);                    // 타이핑
        	yield return new WaitForSeconds(0.03f);           // 0.03초 대기
        }
    }
}

```

<br>

---

<br>

## 5.  NOTICE

이때, for문과 함께 **Korean Typer** 패키지를 사용할 땐

반드시 ```str.GetTypingLength()```보다 **같거나 작을 때**까지 반복하도록 해야합니다.

만약 4번 데모에서 ```i <= strTypingLength``` 가 아닌

```i < strTypingLength```으로 했다면, 마지막 한 글자가 제대로 나오지 않을겁니다.

<br>
<br>
<br>

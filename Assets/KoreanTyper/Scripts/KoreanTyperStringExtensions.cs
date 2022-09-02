using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoreanTyper {
	public static class stringExtensions  {
        private static char[] Korean1stWordList = { 'ㄱ','ㄲ','ㄴ','ㄷ','ㄸ',
                                                    'ㄹ','ㅁ','ㅂ','ㅃ','ㅅ',
                                                    'ㅆ','ㅇ','ㅈ','ㅉ','ㅊ',
                                                    'ㅋ','ㅌ','ㅍ','ㅎ' };

        private static char[] Korean2ndWordList = { 'ㅏ','ㅐ','ㅑ','ㅒ','ㅓ',
                                                    'ㅔ','ㅕ','ㅖ','ㅗ','ㅘ',
                                                    'ㅙ','ㅚ','ㅛ','ㅜ','ㅝ',
                                                    'ㅞ','ㅟ','ㅠ','ㅡ','ㅢ',
                                                    'ㅣ' };
        private static char[] Korean3rdWordList = { ' ','ㄱ','ㄲ','ㄳ','ㄴ',
                                                    'ㄵ','ㄶ','ㄷ','ㄹ','ㄺ',
                                                    'ㄻ','ㄼ','ㄽ','ㄾ','ㄿ',
                                                    'ㅀ','ㅁ','ㅂ','ㅄ','ㅅ',
                                                    'ㅆ','ㅇ','ㅈ','ㅊ','ㅋ',
                                                    'ㅌ','ㅍ','ㅎ' };

        public static int GetTypingLength (this string str) {
            int result = 0;
            for (int index = 0; index < str.Length; index++) {
                if ((int)str[index] < (int)'가' || (int)str[index] > (int)'힣') {
                    result++; continue;
                }

                int wordIntValue = (int)str[index] - (int)'가';
                int korean2ndWord = ( wordIntValue ) / Korean3rdWordList.Length;
                int korean3rdWord = ( wordIntValue ) % Korean3rdWordList.Length;

                switch (korean2ndWord) {
                    case 9: case 10: case 11: case 14: case 15: case 16: case 19:
                        result += 2; break;
                    default:
                        result += 1; break;
                }
                switch (korean3rdWord) {
                    case 3: case 5: case 6: case 9: case 10: case 11:
                    case 12: case 13: case 14: case 15: case 18:
                        result += 2; break;
                    case 0: break;
                    default:
                        result += 1; break;
                }
            }
            return result;
        }

        public static string Typing(this string str, float percent) {
            if (percent >= 1f) return str;
            if (percent <= 0f) return "";

            int maxLength = str.GetTypingLength();
            Debug.Log((int)( maxLength * percent ));
            return str.Typing((int)(maxLength * percent ));
        }

        public static string Typing(this string str, int count) {
            if (count <= 0) return "";
            int maxLength = str.GetTypingLength();
            if (count >= maxLength) return str;

            string result_string = "";

            int index = 0;
            for (index = 0; index < str.Length && count > 0; index++) {
                if ((int)str[index] < (int)'가' || (int)str[index] > (int)'힣') {
                    count --; continue;
                }

                int wordIntValue = (int)str[index] - (int)'가';
                int korean2ndWord = ( wordIntValue ) / Korean3rdWordList.Length;
                int korean3rdWord = ( wordIntValue ) % Korean3rdWordList.Length;

                int wordDrawcount = 1; // 몇번에 걸쳐 타이핑 될지 기억하는 함수
                switch( korean2ndWord ) {
                    case 9: case 10: case 11: case 14: case 15: case 16: case 19:
                        wordDrawcount += 2; break;
                    default:
                        wordDrawcount += 1; break;
                }
                switch( korean3rdWord ) {
                    case 3: case 5: case 6: case 9: case 10: case 11:
                    case 12:case 13:case 14:case 15:case 18:
                        wordDrawcount += 2; break;
                    case 0: break;
                    default:
                        wordDrawcount += 1; break;
                }
                count -= wordDrawcount;
                if (count < 0) {
                    int korean1stWord = ( wordIntValue ) / ( Korean3rdWordList.Length * Korean2ndWordList.Length );

                    if(wordDrawcount + count == 1) {
                        result_string += Korean1stWordList[korean1stWord];
                    } else{
                        int new_word_index = (int)'가' + ( korean1stWord  * Korean3rdWordList.Length * Korean2ndWordList.Length );
                        if (wordDrawcount + count == 2) {
                            switch( korean2ndWord ) {
                                case 9: case 10: case 11:
                                    new_word_index += 8 * Korean3rdWordList.Length; break;
                                case 14: case 15: case 16:
                                    new_word_index += 13 * Korean3rdWordList.Length; break;
                                case 19:
                                    new_word_index += 18 * Korean3rdWordList.Length; break;
                                default:
                                    new_word_index += korean2ndWord * Korean3rdWordList.Length; break;
                            }
                        } else if (wordDrawcount + count == 3) {
                            bool flag = false;
                            switch( korean2ndWord ) {
                                case 9: case 10: case 11: case 14: case 15: case 16:case 19:
                                    flag = true; break;
                                default: break;
                            }
                            if(flag) new_word_index += korean2ndWord * Korean3rdWordList.Length;
                            else {
                                switch( korean3rdWord ) {
                                    case 3:
                                        new_word_index += 1; break;
                                    case 5: case 6:
                                        new_word_index += 4; break;
                                    case 9: case 10: case 11: case 12: case 13: case 14: case 15:
                                        new_word_index += 8; break;
                                    case 18:
                                        new_word_index += 17; break;
                                    default:
                                        new_word_index += korean3rdWord; break;
                                }
                            }
                        } else if (wordDrawcount + count == 4) {
                            bool flag = false;
                            switch( korean2ndWord ) {
                                case 9: case 10: case 11: case 14: case 15: case 16:case 19:
                                    flag = true; break;
                                default: break;
                            }
                            if(!flag) new_word_index += korean3rdWord;
                            else {
                                switch( korean3rdWord ) {
                                    case 3:
                                        new_word_index += 1; break;
                                    case 5: case 6:
                                        new_word_index += 4; break;
                                    case 9: case 10: case 11: case 12: case 13: case 14: case 15:
                                        new_word_index += 8; break;
                                    case 18:
                                        new_word_index += 17; break;
                                    default:
                                        new_word_index += 1; break;
                                }
                            }
                        } else if (wordDrawcount + count == 5) {
                            new_word_index += korean3rdWord;
                        }
                        Debug.Log("ㄷ : " + (int)'ㄷ' + ", 도 : " + (int)'도' + ", ㅎ : " + (int)'ㅎ' + ", 해 : " + (int)'해'   );
                        Debug.Log("resultChar : " + (int)resultChar);
                        Debug.Log("new_word_index : " + (int)new_word_index);
                        Debug.Log("resultChar + new_word_index : " + (resultChar + new_word_index));
                        result_string += (char)(new_word_index);
                    }

                } else {
                    result_string += str[index];
                }
            }

            return result_string;
		}
	}
}

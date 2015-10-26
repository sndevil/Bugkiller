using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public enum gamestatus {paused, running};

public enum enemystatus {spawned, killed};
	
public class Classes {





}

public static class Unixtime
{
	public static int Now()
	{
		var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		int timestamp =(int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
		return timestamp;
	}
}


public class FarsiConvertor
{
	private char[,] characterMap = new char[47, 4];
	private short[] characterGuide;
	private bool[] NumericGuide;
	
	public FarsiConvertor()
	{
		characterMap[0 , 0] = 'ﺂ';
		characterMap[0 , 1] = 'ﺁ';
		characterMap[0 , 2] = 'ﺂ';
		characterMap[0 , 3] = 'ﺁ';
		
		characterMap[1 , 0] = 'ﺎ';
		characterMap[1 , 1] = 'ﺍ';
		characterMap[1 , 2] = 'ﺎ';
		characterMap[1 , 3] = 'ﺍ';
		
		characterMap[2 , 0] = 'ﺒ';
		characterMap[2 , 1] = 'ﺑ';
		characterMap[2 , 2] = 'ﺐ';
		characterMap[2 , 3] = 'ﺏ';
		
		characterMap[3 , 0] = 'ﭙ';
		characterMap[3 , 1] = 'ﭘ';
		characterMap[3 , 2] = 'ﭗ';
		characterMap[3 , 3] = 'ﭖ';
		
		characterMap[4 , 0] = 'ﺘ';
		characterMap[4 , 1] = 'ﺗ';
		characterMap[4 , 2] = 'ﺖ';
		characterMap[4 , 3] = 'ﺕ';
		
		characterMap[5 , 0] = 'ﺜ';
		characterMap[5 , 1] = 'ﺛ';
		characterMap[5 , 2] = 'ﺚ';
		characterMap[5 , 3] = 'ﺙ';
		
		characterMap[6 , 0] = 'ﺠ';
		characterMap[6 , 1] = 'ﺟ';
		characterMap[6 , 2] = 'ﺞ';
		characterMap[6 , 3] = 'ﺝ';
		
		characterMap[7 , 0] = 'ﭽ';
		characterMap[7 , 1] = 'ﭼ';
		characterMap[7 , 2] = 'ﭻ';
		characterMap[7 , 3] = 'ﭺ';
		
		characterMap[8 , 0] = 'ﺤ';
		characterMap[8 , 1] = 'ﺣ';
		characterMap[8 , 2] = 'ﺢ';
		characterMap[8 , 3] = 'ﺡ';
		
		characterMap[9 , 0] = 'ﺨ';
		characterMap[9 , 1] = 'ﺧ';
		characterMap[9 , 2] = 'ﺦ';
		characterMap[9 , 3] = 'ﺥ';
		
		characterMap[10, 0] = 'ﺪ';
		characterMap[10, 1] = 'ﺩ';
		characterMap[10, 2] = 'ﺪ';
		characterMap[10, 3] = 'ﺩ';
		
		characterMap[11, 0] = 'ﺬ';
		characterMap[11, 1] = 'ﺫ';
		characterMap[11, 2] = 'ﺬ';
		characterMap[11, 3] = 'ﺫ';
		
		characterMap[12, 0] = 'ﺮ';
		characterMap[12, 1] = 'ﺭ';
		characterMap[12, 2] = 'ﺮ';
		characterMap[12, 3] = 'ﺭ';
		
		characterMap[13, 0] = 'ﺰ';
		characterMap[13, 1] = 'ﺯ';
		characterMap[13, 2] = 'ﺰ';
		characterMap[13, 3] = 'ﺯ';            
		
		characterMap[14, 0] = 'ﮋ';
		characterMap[14, 1] = 'ﮊ';
		characterMap[14, 2] = 'ﮋ';
		characterMap[14, 3] = 'ﮊ';
		
		characterMap[15, 0] = 'ﺴ';
		characterMap[15, 1] = 'ﺳ';
		characterMap[15, 2] = 'ﺲ';
		characterMap[15, 3] = 'ﺱ';
		
		characterMap[16, 0] = 'ﺸ';
		characterMap[16, 1] = 'ﺷ';
		characterMap[16, 2] = 'ﺶ';
		characterMap[16, 3] = 'ﺵ';
		
		characterMap[17, 0] = 'ﺼ';
		characterMap[17, 1] = 'ﺻ';
		characterMap[17, 2] = 'ﺺ';
		characterMap[17, 3] = 'ﺹ';
		
		characterMap[18, 0] = 'ﻀ';
		characterMap[18, 1] = 'ﺿ';
		characterMap[18, 2] = 'ﺾ';
		characterMap[18, 3] = 'ﺽ';
		
		characterMap[19, 0] = 'ﻄ';
		characterMap[19, 1] = 'ﻃ';
		characterMap[19, 2] = 'ﻂ';
		characterMap[19, 3] = 'ﻁ';
		
		characterMap[20, 0] = 'ﻈ';
		characterMap[20, 1] = 'ﻇ';
		characterMap[20, 2] = 'ﻆ';
		characterMap[20, 3] = 'ﻅ';
		
		characterMap[21, 0] = 'ﻌ';
		characterMap[21, 1] = 'ﻋ';
		characterMap[21, 2] = 'ﻊ';
		characterMap[21, 3] = 'ﻉ';
		
		characterMap[22, 0] = 'ﻐ';
		characterMap[22, 1] = 'ﻏ';
		characterMap[22, 2] = 'ﻎ';
		characterMap[22, 3] = 'ﻍ';
		
		characterMap[23, 0] = 'ﻔ';
		characterMap[23, 1] = 'ﻓ';
		characterMap[23, 2] = 'ﻒ';
		characterMap[23, 3] = 'ﻑ';
		
		characterMap[24, 0] = 'ﻘ';
		characterMap[24, 1] = 'ﻗ';
		characterMap[24, 2] = 'ﻖ';
		characterMap[24, 3] = 'ﻕ';
		
		characterMap[25, 0] = 'ﻜ';
		characterMap[25, 1] = 'ﻛ';
		characterMap[25, 2] = 'ﻚ';
		characterMap[25, 3] = 'ﻙ';
		
		characterMap[26, 0] = 'ﮕ';
		characterMap[26, 1] = 'ﮔ';
		characterMap[26, 2] = 'ﮓ';
		characterMap[26, 3] = 'ﮒ';
		
		characterMap[27, 0] = 'ﻠ';
		characterMap[27, 1] = 'ﻟ';
		characterMap[27, 2] = 'ﻞ';
		characterMap[27, 3] = 'ﻝ';
		
		characterMap[28, 0] = 'ﻤ';
		characterMap[28, 1] = 'ﻣ';
		characterMap[28, 2] = 'ﻢ';
		characterMap[28, 3] = 'ﻡ';
		
		characterMap[29, 0] = 'ﻨ';
		characterMap[29, 1] = 'ﻧ';
		characterMap[29, 2] = 'ﻦ';
		characterMap[29, 3] = 'ﻥ';
		
		characterMap[30, 0] = 'ﻮ';
		characterMap[30, 1] = 'ﻭ';
		characterMap[30, 2] = 'ﻮ';
		characterMap[30, 3] = 'ﻭ';
		
		characterMap[31, 0] = 'ﻬ';
		characterMap[31, 1] = 'ﻫ';
		characterMap[31, 2] = 'ﻪ';
		characterMap[31, 3] = 'ﻩ';
		
		characterMap[32, 0] = 'ﻴ';
		characterMap[32, 1] = 'ﻳ';
		characterMap[32, 2] = 'ﻰ';
		characterMap[32, 3] = 'ﻯ';
		
		characterMap[33, 0] = 'ﺌ';
		characterMap[33, 1] = 'ﺋ';
		characterMap[33, 2] = 'ﺊ';
		characterMap[33, 3] = 'ﺉ';
		
		characterMap[34, 0] = 'ﺆ';
		characterMap[34, 1] = 'ﺅ';
		characterMap[34, 2] = 'ﺆ';
		characterMap[34, 3] = 'ﺅ';
		
		characterMap[35, 0] = '۱';
		characterMap[36, 0] = '۲';
		characterMap[37, 0] = '۳';
		characterMap[38, 0] = '۴';
		characterMap[39, 0] = '۵';
		characterMap[40, 0] = '۶';
		characterMap[41, 0] = '۷';
		characterMap[42, 0] = '۸';
		characterMap[43, 0] = '۹';
		characterMap[44, 0] = '۰';
		characterMap [45, 0] = '-';
		characterMap [46, 0] = '+';
		
	}
	
	public string Reverse(string toConvert)
	{
		characterGuide = new short[toConvert.Length + 2];
		NumericGuide = new bool[toConvert.Length+2];
		characterGuide[0] = 0;
		characterGuide[toConvert.Length + 1] = 0;
		char[] Tempchararray = new char[toConvert.Length + 2];
		char[] TempChararray1 = new char[toConvert.Length + 2];
		
		Tempchararray = toConvert.ToCharArray ();
		TempChararray1 = toConvert.ToCharArray ();
		for (int i = 0; i < toConvert.Length; i++)
		{
			switch (Tempchararray[i])
			{
			case 'ّ': characterGuide[i + 1] = 2; break;
			case 'ً': characterGuide[i + 1] = 2; break;
			case 'ٌ': characterGuide[i + 1] = 2; break;
			case 'ٍ': characterGuide[i + 1] = 2; break;
			case 'َ': characterGuide[i + 1] = 2; break;
			case 'ُ': characterGuide[i + 1] = 2; break;
			case 'ِ': characterGuide[i + 1] = 2; break;
			case 'ـ': characterGuide[i + 1] = 4; break;
			case 'آ': characterGuide[i + 1] = 2; break;
			case 'ا': characterGuide[i + 1] = 2; break;
			case 'ب': characterGuide[i + 1] = 4; break;
			case 'پ': characterGuide[i + 1] = 4; break;
			case 'ت': characterGuide[i + 1] = 4; break;
			case 'ث': characterGuide[i + 1] = 4; break;
			case 'ج': characterGuide[i + 1] = 4; break;
			case 'چ': characterGuide[i + 1] = 4; break;
			case 'ح': characterGuide[i + 1] = 4; break;
			case 'خ': characterGuide[i + 1] = 4; break;
			case 'د': characterGuide[i + 1] = 2; break;
			case 'ذ': characterGuide[i + 1] = 2; break;
			case 'ر': characterGuide[i + 1] = 2; break;
			case 'ز': characterGuide[i + 1] = 2; break;
			case 'ژ': characterGuide[i + 1] = 2; break;
			case 'س': characterGuide[i + 1] = 4; break;
			case 'ش': characterGuide[i + 1] = 4; break;
			case 'ص': characterGuide[i + 1] = 4; break;
			case 'ض': characterGuide[i + 1] = 4; break;
			case 'ط': characterGuide[i + 1] = 4; break;
			case 'ظ': characterGuide[i + 1] = 4; break;
			case 'ع': characterGuide[i + 1] = 4; break;
			case 'غ': characterGuide[i + 1] = 4; break;
			case 'ف': characterGuide[i + 1] = 4; break;
			case 'ق': characterGuide[i + 1] = 4; break;
			case 'ک': characterGuide[i + 1] = 4; break;
			case 'گ': characterGuide[i + 1] = 4; break;
			case 'ل': characterGuide[i + 1] = 4; break;
			case 'م': characterGuide[i + 1] = 4; break;
			case 'ن': characterGuide[i + 1] = 4; break;
			case 'و': characterGuide[i + 1] = 2; break;
			case 'ه': characterGuide[i + 1] = 4; break;
			case 'ی': characterGuide[i + 1] = 4; break;
			case 'ئ': characterGuide[i + 1] = 4; break;
			case 'ؤ': characterGuide[i + 1] = 2; break;
			default : characterGuide[i + 1] = 0; break;
			}
		}
		
		for (int j = 0; j < toConvert.Length; j++)
		{
			switch (Tempchararray[j])
			{
			case 'آ': replaceToWorseChar(Tempchararray, j, 0 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ا': replaceToWorseChar(Tempchararray, j, 1 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ب': replaceToWorseChar(Tempchararray, j, 2 , toConvert.Length); NumericGuide[j] = false; break;
			case 'پ': replaceToWorseChar(Tempchararray, j, 3 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ت': replaceToWorseChar(Tempchararray, j, 4 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ث': replaceToWorseChar(Tempchararray, j, 5 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ج': replaceToWorseChar(Tempchararray, j, 6 , toConvert.Length); NumericGuide[j] = false; break;
			case 'چ': replaceToWorseChar(Tempchararray, j, 7 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ح': replaceToWorseChar(Tempchararray, j, 8 , toConvert.Length); NumericGuide[j] = false; break;
			case 'خ': replaceToWorseChar(Tempchararray, j, 9 , toConvert.Length); NumericGuide[j] = false; break;
			case 'د': replaceToWorseChar(Tempchararray, j, 10, toConvert.Length); NumericGuide[j] = false; break;
			case 'ذ': replaceToWorseChar(Tempchararray, j, 11, toConvert.Length); NumericGuide[j] = false; break;
			case 'ر': replaceToWorseChar(Tempchararray, j, 12, toConvert.Length); NumericGuide[j] = false; break;
			case 'ز': replaceToWorseChar(Tempchararray, j, 13, toConvert.Length); NumericGuide[j] = false; break;
			case 'ژ': replaceToWorseChar(Tempchararray, j, 14, toConvert.Length);  NumericGuide[j] = false;break;
			case 'س': replaceToWorseChar(Tempchararray, j, 15, toConvert.Length); NumericGuide[j] = false; break;
			case 'ش': replaceToWorseChar(Tempchararray, j, 16, toConvert.Length); NumericGuide[j] = false; break;
			case 'ص': replaceToWorseChar(Tempchararray, j, 17, toConvert.Length); NumericGuide[j] = false; break;
			case 'ض': replaceToWorseChar(Tempchararray, j, 18, toConvert.Length); NumericGuide[j] = false; break;
			case 'ط': replaceToWorseChar(Tempchararray, j, 19, toConvert.Length); NumericGuide[j] = false; break;
			case 'ظ': replaceToWorseChar(Tempchararray, j, 20, toConvert.Length); NumericGuide[j] = false; break;
			case 'ع': replaceToWorseChar(Tempchararray, j, 21, toConvert.Length); NumericGuide[j] = false; break;
			case 'غ': replaceToWorseChar(Tempchararray, j, 22, toConvert.Length); NumericGuide[j] = false; break;
			case 'ف': replaceToWorseChar(Tempchararray, j, 23, toConvert.Length); NumericGuide[j] = false; break;
			case 'ق': replaceToWorseChar(Tempchararray, j, 24, toConvert.Length); NumericGuide[j] = false; break;
			case 'ک': replaceToWorseChar(Tempchararray, j, 25, toConvert.Length); NumericGuide[j] = false; break;
			case 'گ': replaceToWorseChar(Tempchararray, j, 26, toConvert.Length); NumericGuide[j] = false; break;
			case 'ل': replaceToWorseChar(Tempchararray, j, 27, toConvert.Length); NumericGuide[j] = false; break;
			case 'م': replaceToWorseChar(Tempchararray, j, 28, toConvert.Length); NumericGuide[j] = false; break;
			case 'ن': replaceToWorseChar(Tempchararray, j, 29, toConvert.Length); NumericGuide[j] = false; break;
			case 'و': replaceToWorseChar(Tempchararray, j, 30, toConvert.Length); NumericGuide[j] = false; break;
			case 'ه': replaceToWorseChar(Tempchararray, j, 31, toConvert.Length); NumericGuide[j] = false; break;
			case 'ی': replaceToWorseChar(Tempchararray, j, 32, toConvert.Length); NumericGuide[j] = false; break;
			case 'ئ': replaceToWorseChar(Tempchararray, j, 33, toConvert.Length); NumericGuide[j] = false; break;
			case 'ؤ': replaceToWorseChar(Tempchararray, j, 34, toConvert.Length); NumericGuide[j] = false; break;
			case '1': replaceToWorseChar(Tempchararray, j, 35, toConvert.Length); NumericGuide[j] = true; break;
			case '2': replaceToWorseChar(Tempchararray, j, 36, toConvert.Length); NumericGuide[j] = true; break;
			case '3': replaceToWorseChar(Tempchararray, j, 37, toConvert.Length); NumericGuide[j] = true; break;
			case '4': replaceToWorseChar(Tempchararray, j, 38, toConvert.Length); NumericGuide[j] = true; break;
			case '5': replaceToWorseChar(Tempchararray, j, 39, toConvert.Length); NumericGuide[j] = true; break;
			case '6': replaceToWorseChar(Tempchararray, j, 40, toConvert.Length); NumericGuide[j] = true; break;
			case '7': replaceToWorseChar(Tempchararray, j, 41, toConvert.Length); NumericGuide[j] = true; break;
			case '8': replaceToWorseChar(Tempchararray, j, 42, toConvert.Length); NumericGuide[j] = true; break;
			case '9': replaceToWorseChar(Tempchararray, j, 43, toConvert.Length); NumericGuide[j] = true; break;
			case '0': replaceToWorseChar(Tempchararray, j, 44, toConvert.Length); NumericGuide[j] = true; break;
			case '-': replaceToWorseChar(Tempchararray, j, 45, toConvert.Length); NumericGuide[j] = true; break;
			case '+': replaceToWorseChar(Tempchararray, j, 46, toConvert.Length); NumericGuide[j] = true; break;
			}
		}
		
		for (int i =toConvert.Length-1; i >=0; i--) {
			TempChararray1[i] = Tempchararray[toConvert.Length-1-i];
		}
		
		toConvert = new string (TempChararray1);
		return toConvert;
	}
	
	public string Convert(string toConvert)
	{
		characterGuide = new short[toConvert.Length + 2];
		NumericGuide = new bool[toConvert.Length+2];
		characterGuide[0] = 0;
		characterGuide[toConvert.Length + 1] = 0;
		char[] Tempchararray = new char[toConvert.Length + 2];
		char[] TempChararray1 = new char[toConvert.Length + 2];
		
		Tempchararray = toConvert.ToCharArray ();
		TempChararray1 = toConvert.ToCharArray ();
		for (int i = 0; i < toConvert.Length; i++)
		{
			switch (Tempchararray[i])
			{
			case 'ّ': characterGuide[i + 1] = 2; break;
			case 'ً': characterGuide[i + 1] = 2; break;
			case 'ٌ': characterGuide[i + 1] = 2; break;
			case 'ٍ': characterGuide[i + 1] = 2; break;
			case 'َ': characterGuide[i + 1] = 2; break;
			case 'ُ': characterGuide[i + 1] = 2; break;
			case 'ِ': characterGuide[i + 1] = 2; break;
			case 'ـ': characterGuide[i + 1] = 4; break;
			case 'آ': characterGuide[i + 1] = 2; break;
			case 'ا': characterGuide[i + 1] = 2; break;
			case 'ب': characterGuide[i + 1] = 4; break;
			case 'پ': characterGuide[i + 1] = 4; break;
			case 'ت': characterGuide[i + 1] = 4; break;
			case 'ث': characterGuide[i + 1] = 4; break;
			case 'ج': characterGuide[i + 1] = 4; break;
			case 'چ': characterGuide[i + 1] = 4; break;
			case 'ح': characterGuide[i + 1] = 4; break;
			case 'خ': characterGuide[i + 1] = 4; break;
			case 'د': characterGuide[i + 1] = 2; break;
			case 'ذ': characterGuide[i + 1] = 2; break;
			case 'ر': characterGuide[i + 1] = 2; break;
			case 'ز': characterGuide[i + 1] = 2; break;
			case 'ژ': characterGuide[i + 1] = 2; break;
			case 'س': characterGuide[i + 1] = 4; break;
			case 'ش': characterGuide[i + 1] = 4; break;
			case 'ص': characterGuide[i + 1] = 4; break;
			case 'ض': characterGuide[i + 1] = 4; break;
			case 'ط': characterGuide[i + 1] = 4; break;
			case 'ظ': characterGuide[i + 1] = 4; break;
			case 'ع': characterGuide[i + 1] = 4; break;
			case 'غ': characterGuide[i + 1] = 4; break;
			case 'ف': characterGuide[i + 1] = 4; break;
			case 'ق': characterGuide[i + 1] = 4; break;
			case 'ک': characterGuide[i + 1] = 4; break;
			case 'گ': characterGuide[i + 1] = 4; break;
			case 'ل': characterGuide[i + 1] = 4; break;
			case 'م': characterGuide[i + 1] = 4; break;
			case 'ن': characterGuide[i + 1] = 4; break;
			case 'و': characterGuide[i + 1] = 2; break;
			case 'ه': characterGuide[i + 1] = 4; break;
			case 'ی': characterGuide[i + 1] = 4; break;
			case 'ئ': characterGuide[i + 1] = 4; break;
			case 'ؤ': characterGuide[i + 1] = 2; break;
			default : characterGuide[i + 1] = 0; break;
			}
		}
		
		for (int j = 0; j < toConvert.Length; j++)
		{
			switch (Tempchararray[j])
			{
			case 'آ': replaceToWorseChar(Tempchararray, j, 0 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ا': replaceToWorseChar(Tempchararray, j, 1 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ب': replaceToWorseChar(Tempchararray, j, 2 , toConvert.Length); NumericGuide[j] = false; break;
			case 'پ': replaceToWorseChar(Tempchararray, j, 3 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ت': replaceToWorseChar(Tempchararray, j, 4 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ث': replaceToWorseChar(Tempchararray, j, 5 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ج': replaceToWorseChar(Tempchararray, j, 6 , toConvert.Length); NumericGuide[j] = false; break;
			case 'چ': replaceToWorseChar(Tempchararray, j, 7 , toConvert.Length); NumericGuide[j] = false; break;
			case 'ح': replaceToWorseChar(Tempchararray, j, 8 , toConvert.Length); NumericGuide[j] = false; break;
			case 'خ': replaceToWorseChar(Tempchararray, j, 9 , toConvert.Length); NumericGuide[j] = false; break;
			case 'د': replaceToWorseChar(Tempchararray, j, 10, toConvert.Length); NumericGuide[j] = false; break;
			case 'ذ': replaceToWorseChar(Tempchararray, j, 11, toConvert.Length); NumericGuide[j] = false; break;
			case 'ر': replaceToWorseChar(Tempchararray, j, 12, toConvert.Length); NumericGuide[j] = false; break;
			case 'ز': replaceToWorseChar(Tempchararray, j, 13, toConvert.Length); NumericGuide[j] = false; break;
			case 'ژ': replaceToWorseChar(Tempchararray, j, 14, toConvert.Length);  NumericGuide[j] = false;break;
			case 'س': replaceToWorseChar(Tempchararray, j, 15, toConvert.Length); NumericGuide[j] = false; break;
			case 'ش': replaceToWorseChar(Tempchararray, j, 16, toConvert.Length); NumericGuide[j] = false; break;
			case 'ص': replaceToWorseChar(Tempchararray, j, 17, toConvert.Length); NumericGuide[j] = false; break;
			case 'ض': replaceToWorseChar(Tempchararray, j, 18, toConvert.Length); NumericGuide[j] = false; break;
			case 'ط': replaceToWorseChar(Tempchararray, j, 19, toConvert.Length); NumericGuide[j] = false; break;
			case 'ظ': replaceToWorseChar(Tempchararray, j, 20, toConvert.Length); NumericGuide[j] = false; break;
			case 'ع': replaceToWorseChar(Tempchararray, j, 21, toConvert.Length); NumericGuide[j] = false; break;
			case 'غ': replaceToWorseChar(Tempchararray, j, 22, toConvert.Length); NumericGuide[j] = false; break;
			case 'ف': replaceToWorseChar(Tempchararray, j, 23, toConvert.Length); NumericGuide[j] = false; break;
			case 'ق': replaceToWorseChar(Tempchararray, j, 24, toConvert.Length); NumericGuide[j] = false; break;
			case 'ک': replaceToWorseChar(Tempchararray, j, 25, toConvert.Length); NumericGuide[j] = false; break;
			case 'گ': replaceToWorseChar(Tempchararray, j, 26, toConvert.Length); NumericGuide[j] = false; break;
			case 'ل': replaceToWorseChar(Tempchararray, j, 27, toConvert.Length); NumericGuide[j] = false; break;
			case 'م': replaceToWorseChar(Tempchararray, j, 28, toConvert.Length); NumericGuide[j] = false; break;
			case 'ن': replaceToWorseChar(Tempchararray, j, 29, toConvert.Length); NumericGuide[j] = false; break;
			case 'و': replaceToWorseChar(Tempchararray, j, 30, toConvert.Length); NumericGuide[j] = false; break;
			case 'ه': replaceToWorseChar(Tempchararray, j, 31, toConvert.Length); NumericGuide[j] = false; break;
			case 'ی': replaceToWorseChar(Tempchararray, j, 32, toConvert.Length); NumericGuide[j] = false; break;
			case 'ئ': replaceToWorseChar(Tempchararray, j, 33, toConvert.Length); NumericGuide[j] = false; break;
			case 'ؤ': replaceToWorseChar(Tempchararray, j, 34, toConvert.Length); NumericGuide[j] = false; break;
			case '1': replaceToWorseChar(Tempchararray, j, 35, toConvert.Length); NumericGuide[j] = true; break;
			case '2': replaceToWorseChar(Tempchararray, j, 36, toConvert.Length); NumericGuide[j] = true; break;
			case '3': replaceToWorseChar(Tempchararray, j, 37, toConvert.Length); NumericGuide[j] = true; break;
			case '4': replaceToWorseChar(Tempchararray, j, 38, toConvert.Length); NumericGuide[j] = true; break;
			case '5': replaceToWorseChar(Tempchararray, j, 39, toConvert.Length); NumericGuide[j] = true; break;
			case '6': replaceToWorseChar(Tempchararray, j, 40, toConvert.Length); NumericGuide[j] = true; break;
			case '7': replaceToWorseChar(Tempchararray, j, 41, toConvert.Length); NumericGuide[j] = true; break;
			case '8': replaceToWorseChar(Tempchararray, j, 42, toConvert.Length); NumericGuide[j] = true; break;
			case '9': replaceToWorseChar(Tempchararray, j, 43, toConvert.Length); NumericGuide[j] = true; break;
			case '0': replaceToWorseChar(Tempchararray, j, 44, toConvert.Length); NumericGuide[j] = true; break;
			case '-': replaceToWorseChar(Tempchararray, j, 45, toConvert.Length); NumericGuide[j] = true; break;
			case '+': replaceToWorseChar(Tempchararray, j, 46, toConvert.Length); NumericGuide[j] = true; break;
			}
		}
		
		for (int i =toConvert.Length-1; i >=0; i--) {
			//Debug.Log("i:"+i.ToString()+ " : "+ Tempchararray[i]);
			//Debug.Log(NumericGuide[toConvert.Length-1-i].ToString());
			if (!NumericGuide[toConvert.Length -1 - i])
				TempChararray1[i] = Tempchararray[toConvert.Length-1-i];
			else
			{
				int j = i-1;
				//Debug.Log(j.ToString());
				if (j>0)
					while(NumericGuide[j] && j>0)
						j--;
				
				int start = toConvert.Length-1 - i;
				int length = i-j;
				
				if (NumericGuide[0] && j==0)
					length++;
				i-=length-1;
				for (int k = start; k<start+length;k++)
				{
					TempChararray1[i+k-start] = Tempchararray[k];//-start];
				}
			}
		}
		
		toConvert = new string (TempChararray1);
		return toConvert;
	}
	
	public string SmartConvert(string toConvert)
	{
		int blockstart = -1, blockend = -1;
		Regex regex = new Regex("^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]+$");
		char[] Tempchararray = new char[toConvert.Length + 2];
		char[] temp;
		Tempchararray = toConvert.ToCharArray ();
		for (int i = 0; i < toConvert.Length;i++)
		{
			if (regex.IsMatch(Tempchararray[i].ToString()))
			{
				blockstart = i;
				while ((regex.IsMatch(Tempchararray[i].ToString())|| Tempchararray[i] == ' ' || Tempchararray[i] == '!' || Tempchararray[i] == '.' || Tempchararray[i] == '،') && i< toConvert.Length-1)
					i++;
				blockend = i-1;
				if (blockend == toConvert.Length -2)
					blockend = toConvert.Length-1;
				temp = new char[blockend - blockstart + 1];
				for (int j = blockstart;j <= blockend; j++)
					temp[j-blockstart] = Tempchararray[j];
				
				var tempstring = Convert(new string(temp));
				temp = tempstring.ToCharArray();
				
				for (int j = blockstart;j<=blockend; j++)
					Tempchararray[j] = temp[j-blockstart];
				//i -= 1;
			}
			else if (Tempchararray[i] >= '0' && Tempchararray[i] <= '9')
			{
				var dif = Tempchararray[i] - '0';
				char newchar = (char)( dif + '۰');
				Tempchararray[i] = newchar;
			}
			
		}
		
		toConvert = new string (Tempchararray);
		return toConvert;
	}
	
	private void replaceToWorseChar(char[] pPassage, int pNo, int pNChar, int pLength)
	{
		if (pNChar > 34) {
			pPassage[pNo] = characterMap[pNChar,0];
		} else {
			if (pNo != pLength - 1)
				if (characterGuide [pNo] != 0 && characterGuide [pNo + 2] != 0)
				switch (characterGuide [pNo]) {
					case  2:
					pPassage [pNo] = characterMap [pNChar, 1];
					break;
					case  4:
					pPassage [pNo] = characterMap [pNChar, 0];
					break;
					default:
					break;
				}
			else
				if (characterGuide [pNo] != 0 && characterGuide [pNo + 2] == 0)
				switch (characterGuide [pNo]) {
					case  2:
					pPassage [pNo] = characterMap [pNChar, 3];
					break;
					case  4:
					pPassage [pNo] = characterMap [pNChar, 2];
					break;
					default:
					break;
				}
			else
				if (characterGuide [pNo] == 0 && characterGuide [pNo + 2] != 0)
					pPassage [pNo] = characterMap [pNChar, 1];
			else
				pPassage [pNo] = characterMap [pNChar, 3];
			else
			switch (characterGuide [pNo]) {
				case  2:
				pPassage [pNo] = characterMap [pNChar, 3];
				break;
				case  4:
				pPassage [pNo] = characterMap [pNChar, 2];
				break;
				default:
				pPassage [pNo] = characterMap [pNChar, 3];
				break;
			}
		}
	}
}

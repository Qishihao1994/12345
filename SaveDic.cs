using System;
using System.Collections;
using System.Collections.Generic;
namespace FileOperation
{
	public class SaveDic
	{
		public static void ParseVersionFile(string content, Dictionary<string,string> dict)
		{
			if (content == null || content.Length == 0) {
				return; 
			}
			string[] items = content.Split(new char[] {'\n'}); 
			foreach (string item in items)
			{
				string[] info = item.Split(new char[]{','}); 
				if (info != null && info.Length == 2)
				{
					dict.Add(info[0], info[1]); 
				}
			} 
		}
	}
}


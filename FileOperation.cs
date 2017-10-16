using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace FileOperation
{
	public class FileOperation
	{
		public static void  WriteFile(){
			FileStream fs = null;//文件流
			StreamWriter writer = null;//文件写入器
			string path = "test.txt";

			if (!File.Exists (path)) {
				fs = File.Create (path);
				Console.WriteLine ("新建一个文件:{0}", path);
			} else {
				fs = File.Open (path, FileMode.Open);
				Console.WriteLine ("文件已经存在，直接打开");
			}

			writer = new StreamWriter (fs);
			writer.WriteLine ("测试文本");
			writer.Flush ();
			writer.Close ();

			fs.Close ();

		}

		public static void directoryOpe(){
			string dirPath = Directory.GetCurrentDirectory()+"/MyDir";
			Console.WriteLine (dirPath);
			string filePath = string.Format ("{0}/{1}",dirPath,"hello.txt");
			if (!Directory.Exists (dirPath)) {
				Directory.CreateDirectory (dirPath);
				Console.WriteLine ("创建一个目录");
			} else {
				Console.WriteLine ("存在目录");
			}
			FileInfo file = new FileInfo (filePath);
			if (!file.Exists) {
				file.Create ();
				Console.WriteLine ("创建一个文件");
			}else{
				Console.WriteLine ("存在");

		}
	}

		public static void FindAllText(){
			string[] files = Directory.GetFiles (
				"/Users/a/Projects/FileOperation",
				"*",SearchOption.AllDirectories);
			StringBuilder builder = new StringBuilder ();
			Console.WriteLine (files.Length);
			for (int i = 0, len = files.Length; i < len; i++) { 
				string filePath = files [i];
				builder.Append (filePath).Append (",").Append ("123").Append ("\n");
				Console.WriteLine (filePath);
			}
			FileStream stream = new FileStream("version1.txt", FileMode.Create);  
			byte[] data = Encoding.UTF8.GetBytes(builder.ToString());  
			stream.Write(data, 0, data.Length);  
			stream.Flush();  
			stream.Close();  
		}

		public static void TestStream(){
			string filePath="test.txt";

			using (FileStream fileStream = File.Open (filePath, FileMode.OpenOrCreate)) {
				string msg = "HelloWorld";
				byte[] msgByteArray = Encoding.Default.GetBytes (msg);
				Console.WriteLine ("开始写入文件");
				fileStream.Write (msgByteArray,0,msgByteArray.Length);
				fileStream.Seek (0,SeekOrigin.Begin);
				Console.WriteLine ("写入文件的数据为");
				byte[] bytesFromFile=new byte[msgByteArray.Length];

				fileStream.Read (bytesFromFile,0,msgByteArray.Length);

				Console.WriteLine (Encoding.Default.GetString(bytesFromFile));

			}


		}

		public static void TestWriter(){
			string filePath="test.txt";

			using (FileStream fileStream = File.Open (filePath, FileMode.OpenOrCreate)) {
				string msg = "HelloWorld";
				StreamWriter streamWriter = new StreamWriter (fileStream);
				Console.WriteLine ("开始写入文件");
				streamWriter.Write (msg);
				Console.WriteLine ("写入文件的数据为");

				StreamReader streamReader = new StreamReader (fileStream);
				string str = streamReader.ReadToEnd ();

				Console.WriteLine (str);
				streamWriter.Close ();
				streamReader.Close ();

			}
		}

		public static void TestDic(){
			Dictionary<string,string> dic = new 
				Dictionary<string,string> ();
			string content =File.ReadAllText ("version1.txt");
			SaveDic.ParseVersionFile (content,dic);

			foreach (var item in dic) {
				Console.WriteLine ("{0}:{1}",
					item.Key,item.Value);
			}
		}

		public static void TestAsync(){
			FileStream fileStream = null;
			string filePath="test.txt";
			FileInfo fileInfo = new FileInfo (filePath);
			if (!fileInfo.Exists) {
				fileStream = File.Create (filePath);
				fileStream.Close ();
			} else {

			}

			fileStream = new FileStream (filePath,FileMode.Open,FileAccess.Write,
				FileShare.None,4096,true);
			Console.WriteLine ("开启异步操作{0}",fileStream.IsAsync);
			string msg="helloworlsddddd";
			byte[] buffer = Encoding.Default.GetBytes (msg);

			//开始异步操作
			IAsyncResult asyncResult = fileStream.BeginWrite (buffer,0,buffer.Length,
				new AsyncCallback(EndWriteCallback),fileStream);
//			for (int i = 0; i < 1000; i++) {
//				Console.Write (i);
//			}

		}
		//异步完成之后的回调函数
		public static void EndWriteCallback(IAsyncResult asyncResult){
			Console.WriteLine ("aaa");
			FileStream stream = asyncResult.AsyncState as FileStream;
			if (stream != null) {
				stream.EndWrite (asyncResult);
				stream.Close ();
			}
			Console.WriteLine ("异步完毕");
		}
}
}


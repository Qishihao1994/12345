using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
namespace FileOperation
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//FileOperation.WriteFile ();
		//FileOperation.directoryOpe ();

			//FileOperation.FindAllText ();
		//FileOperation.TestStream ();

			//FileOperation.TestWriter ();
			//FileOperation.TestDic ();

			FileOperation.TestAsync ();
			/*
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
				
			*/
			/*
			FileStream fs = new FileStream("test.txt",FileMode.OpenOrCreate);  
			byte[] data = new byte[fs.Length];  
			Console.WriteLine("read data...");  
			fs.Read(data, 0, data.Length);  
			fs.Position = 0;  
			AsyncCallback callBack = new AsyncCallback(OnWriteCompletion);  
			fs.BeginWrite(data,0,data.Length,callBack,null);  
			Console.WriteLine("write data ...");  
			*/
			for (int i = 0; i < 1000; i++)  
			{  
				Console.WriteLine("count is :{0}",i);  
			}  
			//fs.Close();  
		}

		static void OnWriteCompletion(IAsyncResult ar)  
		{  
			Console.WriteLine("write operation completed!!!");  
		} 
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

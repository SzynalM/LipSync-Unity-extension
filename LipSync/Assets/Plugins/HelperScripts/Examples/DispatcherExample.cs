using UnityEngine;
using UnityEditor;
using System.Threading;

public static class DispatcherExample {
	
	[MenuItem("Examples/Dispatcher with ThreadPool")]
	public static void DispatcherWithThreadPool()
	{
		ThreadPool.QueueUserWorkItem(delegate(object state) {
			ApplicationThread ();
		});
	}
	
	[MenuItem("Examples/Dispatcher with Thread")]
	public static void DispatcherWithThread()
	{
		new Thread(ApplicationThread).Start();
	}
	
	private static void ApplicationThread()
	{
		Dispatcher.Dispatch((System.Action<string>)UnityThread, string.Format ("Called by ApplicationThread {0}", Thread.CurrentThread.ManagedThreadId));
	}
	
	private static void UnityThread(string message)
	{
		Debug.Log (string.Format ("Unity Thread {0}: UnityThread function called with message '{1}'", Thread.CurrentThread.ManagedThreadId, message));
	}
}

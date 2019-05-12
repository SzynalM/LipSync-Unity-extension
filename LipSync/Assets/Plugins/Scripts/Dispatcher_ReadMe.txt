-------------------------------------------------------------------------------
- Editor Thread Dispatcher
- 
- Copyright © 2013 Popbox Studio
- http://www.popboxstudio.com
-------------------------------------------------------------------------------

  Editor Thread Dispatcher is a simple utility class that provides a means of
dispatching code to a Unity Editor owned thread.

  This class is only accessible through the Unity Editor and is not meant to be 
used by the Unity Player.

-------------------------------------------------------------------------------
- API
-------------------------------------------------------------------------------
/// <summary>
/// Dispatches the specified action delegate.
/// </summary>
/// <param name='function'>
/// The function delegate being requested
/// </param>
public static void Dispatcher.Dispatch (Action function);
	
/// <summary>
/// Dispatches the specified function delegate with the desired delegates
/// </summary>
/// <param name='function'>
/// The function delegate being requested
/// </param>
/// <param name='arguments'>
/// The arguments to be passed to the function delegate
/// </param>
/// <exception cref='System.NotSupportedException'>
/// Is thrown when this method is called from the Unity Player
/// </exception>
public static void Dispatcher.Dispatch (Delegate function, params object[] arguments);
	
/// <summary>
/// Clears the queued tasks
/// </summary>
/// <exception cref='System.NotSupportedException'>
/// Is thrown when this method is called from the Unity Player
/// </exception>
public static void Dispatcher.ClearTasks ();

-------------------------------------------------------------------------------
- Example
-------------------------------------------------------------------------------
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Threading;

public static class DispatcherExample {
	
	[MenuItem("Examples/Dispatcher with ThreadPool")]
	public static void DispatcherWithThreadPool()
	{
		Debug.Log (string.Format ("Unity Thread {0}: DispatcherWithThreadPool function called", Thread.CurrentThread.ManagedThreadId));
		ThreadPool.QueueUserWorkItem(delegate(object state) {
			ApplicationThread ();
		});
	}
	
	[MenuItem("Examples/Dispatcher with Thread")]
	public static void DispatcherWithThread()
	{
		Debug.Log (string.Format ("Unity Thread {0}: DispatcherWithThread function called", Thread.CurrentThread.ManagedThreadId));
		new Thread(ApplicationThread).Start();
	}
	
	private static void ApplicationThread()
	{
		Debug.Log (string.Format ("Application Thread {0}: ApplicationThread function called", Thread.CurrentThread.ManagedThreadId));
		Dispatcher.Dispatch((System.Action<string>)UnityThread, string.Format ("Called by ApplicationThread {0}", Thread.CurrentThread.ManagedThreadId));
	}
	
	private static void UnityThread(string message)
	{
		Debug.Log (string.Format ("Unity Thread {0}: UnityThread function called with message '{1}'", Thread.CurrentThread.ManagedThreadId, message));
	}
}

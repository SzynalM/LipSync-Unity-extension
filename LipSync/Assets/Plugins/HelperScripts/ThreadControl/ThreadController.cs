using System;
using System.Collections.Generic;
using UnityEditor;

namespace LipsyncUtility.ThreadControl
{
    [InitializeOnLoad]
    public static class ThreadController
    {
        private static Queue<Action> operationQueue = new Queue<Action>();

        static ThreadController()
        {
            EditorApplication.update += DispatchAllOperations;
        }

        public static void AddOperation(Action function)
        {
            lock (operationQueue)
            {
                operationQueue.Enqueue(function);
            }
        }

        private static void DispatchAllOperations()
        {
            if (operationQueue.Count > 0)
            {
                lock (operationQueue)
                {
                    foreach (Action operation in operationQueue)
                    {
                        operation.DynamicInvoke();
                    }
                    operationQueue.Clear();
                }
            }
        }

        public static void ClearTasks()
        {
            if (operationQueue.Count > 0)
            {
                lock (operationQueue)
                {
                    operationQueue.Clear();
                }
            }
        }
    }
}
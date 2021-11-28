using System;
using UnityEngine;
namespace Hydra
{
    namespace Parsing
    {
        public class StringParser : MonoBehaviour
        {
            public static StringParser instance;

            private void Awake()
            {
                if (instance == null)
                {
                    instance = this;
                }
            }
            public object StringToInstance(string className)
            {
                object obj = Activator.CreateInstance(Type.GetType(className));
                return obj;
            }
        }
    }
}

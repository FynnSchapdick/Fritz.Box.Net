﻿using System;

namespace FritzBox.Net.Fritz
{
    [Serializable]
    public class FritzDeviceException : Exception
    {
        public FritzDeviceException()
        {
        }

        public FritzDeviceException(string message) : base(message)
        {
        }

        public FritzDeviceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FritzDeviceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
using System;
using System.Collections.Generic;
using GIFTed.Models;

namespace GIFTed.Data
{
    public class ReceiverData
    {
        static private Dictionary<int, Receivers> Receivers = new Dictionary<int, Receivers>();

        public static IEnumerable<Receivers> GetAll()
        {
            return Receivers.Values;
        }

        public static void Add(Receivers newReceiver)
        {
            Receivers.Add(newReceiver.Id, newReceiver);
        }

        public ReceiverData()
        {
        }
    }
}

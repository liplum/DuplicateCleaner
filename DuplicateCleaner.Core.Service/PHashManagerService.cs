using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DuplicateCleaner.Core;
using DuplicateCleaner.Core.Interfaces;
using DuplicateCleaner.Core.Models;

namespace DuplicateCleaner.Services
{
    public class PHashManagerService : IPHashManagerService
    {

        private Dictionary<Photogragh, PHash> PHashs { get; init; } = new();

        public PHash GetPHash(Photogragh photogragh)
        {
            if (PHashs.TryGetValue(photogragh, out var phash))
            {
                return phash;
            }
            throw new HaveNoPHashException(photogragh.FileName);
        }

        public void SetOrAddPHash(Photogragh photogragh, PHash pHash)
        {
            PHashs[photogragh] = pHash;
        }

        public Task SaveData()
        {
            return null;
        }

        public bool HasPHash(Photogragh photogragh)
        {
            return PHashs.ContainsKey(photogragh);
        }

        public void ClearAll()
        {
            PHashs.Clear();
        }
    }


    [Serializable]
    public class HaveNoPHashException : Exception
    {
        public HaveNoPHashException()
        {
        }
        public HaveNoPHashException(string message) : base(message) { }
        public HaveNoPHashException(string message, Exception inner) : base(message, inner) { }
        protected HaveNoPHashException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

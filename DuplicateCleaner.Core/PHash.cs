using Shipwreck.Phash;

namespace DuplicateCleaner.Core
{
    public class PHash
    {
        public Digest Value
        {
            get; init;
        }
        public PHash(Digest value)
        {
            Value = value;
        }
    }
}

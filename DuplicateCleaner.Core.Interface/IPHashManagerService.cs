using System.Threading.Tasks;
using DuplicateCleaner.Core.Models;
using Shipwreck.Phash;

namespace DuplicateCleaner.Core.Interfaces
{
    public interface IPHashManagerService
    {
        /// <summary>
        /// Gets a PHash of the photogragh
        /// </summary>
        /// <param name="photogragh"></param>
        /// <returns>The PHash</returns>
        public PHash GetPHash(Photogragh photogragh);

        public Task SaveData();

        public void SetOrAddPHash(Photogragh photogragh, PHash pHash);

        public bool HasPHash(Photogragh photogragh);

        public void ClearAll();
    }
}

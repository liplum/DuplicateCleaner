using DuplicateCleaner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuplicateCleaner.Core.Interfaces
{
    public interface IImageService
    {
        /// <summary>
        /// Groups a list of photograghs having computed PHash by <see cref="IPHashService"/>.
        /// </summary>
        /// <param name="photos">All photograghs with PHash</param>
        /// <returns>A list of photograghs grouped by similarity</returns>
        public Task<IEnumerable<IEnumerable<Photogragh>>> GroupSimilarPhotograghs(IEnumerable<Photogragh> photograghs);
    }
}

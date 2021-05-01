using DuplicateCleaner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuplicateCleaner.Core.Interfaces
{
    public interface IPHashService
    {
        /// <summary>
        /// Computes photogragh's <see cref="Photogragh.PHash"/>
        /// </summary>
        /// <param name="photogragh"></param>
        /// <returns></returns>
        public Task<PHash> ComputePHash(Photogragh photogragh);

        /// <summary>
        /// Computes photograghs' <see cref="Photogragh.PHash"/>
        /// </summary>
        /// <param name="photograghs"></param>
        /// <returns></returns>
        public Task<IEnumerable<PHash>> ComputePHashs(IEnumerable<Photogragh> photograghs);

    }
}

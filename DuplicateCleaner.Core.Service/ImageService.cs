using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuplicateCleaner.Core;
using DuplicateCleaner.Core.Interfaces;
using DuplicateCleaner.Core.Models;
using Shipwreck.Phash;

namespace DuplicateCleaner.Services
{
    public class ImageService : IImageService
    {

        private readonly IPHashManagerService _dataBaseService;

        public ImageService(IPHashManagerService pHashService)
        {
            _dataBaseService = pHashService;
        }

        public float SimilarityLimit
        {
            set; get;
        } = 0.95f;

        public float Instance(PHash a, PHash b) => ImagePhash.GetCrossCorrelation(a.Value, b.Value);

        public async Task<IEnumerable<IEnumerable<Photogragh>>> GroupSimilarPhotograghs(IEnumerable<Photogragh> photos)
        {
            return await Task.Run(() =>
            {
                return GroupSimilarPhotograghsFunc(photos);
            });

            IEnumerable<Photogragh> GetSimilarGroup(IEnumerable<Photogragh> photos, Photogragh target) =>
                from p in photos where Instance(p, target).Result.CompareTo(SimilarityLimit) >= 0 select p;

            IEnumerable<IEnumerable<Photogragh>> GroupSimilarPhotograghsFunc(IEnumerable<Photogragh> photos)
            {
                var result = new List<IEnumerable<Photogragh>>();
                for (IEnumerable<Photogragh> cur = photos, step = null; cur.Any(); result.Add(step))
                {
                    step = GetSimilarGroup(cur, cur.First());
                    cur = cur.Except(step);
                }
                return result;
            }
        }
    }
}

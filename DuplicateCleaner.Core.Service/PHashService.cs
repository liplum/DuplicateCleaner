using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using DuplicateCleaner.Core;
using DuplicateCleaner.Core.Interfaces;
using DuplicateCleaner.Core.Models;
using Shipwreck.Phash;
using Shipwreck.Phash.PresentationCore;

namespace DuplicateCleaner.Services
{
    public class PHashService : IPHashService
    {

        public async Task<PHash> ComputePHash(Photogragh photogragh)
        {
            return await Task.Run(() =>
            {
                return new PHash(photogragh.ComputePHash());
            });
        }

        public async Task<IEnumerable<PHash>> ComputePHashs(IEnumerable<Photogragh> photograghs)
        {
            return await Task.Run(() =>
            {
                var list = new BlockingCollection<PHash>();
                Parallel.ForEach(photograghs, photo =>
                {
                    var phash = new PHash(photo.ComputePHash());
                    list.Add(phash);
                });
                list.CompleteAdding();
                return list;
            }
            );
        }
    }
    internal static class ImageHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="photogragh"></param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public static Digest ComputePHash(this Photogragh photogragh) => ImagePhash.ComputeDigest(photogragh.Path.ReadBitmap().GetImageSource().ToLuminanceImage());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        private static Bitmap ReadBitmap(this string ImagePath)
        {
            using Image img = Image.FromFile(ImagePath);
            return new Bitmap(img);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bitmap"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static WriteableBitmap GetImageSource(this Bitmap Bitmap)
        {
            IntPtr hBitmap = Bitmap.GetHbitmap();
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
            bitmapSource.Freeze();

            return new WriteableBitmap(bitmapSource);
        }
    }
}

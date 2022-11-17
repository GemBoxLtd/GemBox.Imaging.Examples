using GemBox.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImagingXamarin.Models
{
    public class RotateFlipViewModel
    {
        public ICollection<RotateFlipOption> RotateFlipOptions { get; set; }

        public RotateFlipViewModel()
        {
            // Filling the collection for picker with possible RotateFlipTypes.
            RotateFlipOptions = Enum.GetNames(typeof(RotateFlipType))
                .Select(x =>
                {
                    // Ordering by degrees and flippings
                    var flipIndex = x.IndexOf("Flip");
                    return new
                    {
                        Text = x,
                        Rotation = int.TryParse(x.Substring("Rotate".Length, flipIndex - "Rotate".Length), out var rotation) ? rotation : 0,
                        Flip = x.Substring(flipIndex)
                    };
                })
                .OrderBy(x => x.Rotation)
                .ThenBy(x => x.Flip)
                .Select(x => new RotateFlipOption
                {
                    Text = x.Text,
                    Type = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), x.Text)
                }).ToList();
        }
    }
}

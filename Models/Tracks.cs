using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WedMarch9.Models
{
    public class Tracks
    {
        public int Id { get; set; }
        [Display (Name="Artist Name")]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string FileType { get; set; }
        public string File { get; set; }
    }
}
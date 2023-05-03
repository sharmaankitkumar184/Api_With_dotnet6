using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_With_dotnet6.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorAvatar { get; set; }
        public string? Blogtitle { get; set; }
        public string? Description { get; set; }
        public string? AssetType { get; set; }
        public string? ThumbnailText { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public string? ImageUrl { get; set; }
    }
}

namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using Microsoft.AspNetCore.Http;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class CreateSneakerVM /*: IMapFrom<Sneaker>*/
    {
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        //public List<MovieCategoryVM> Categories { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [MaxLength(250, ErrorMessage = "Description must be shorter than 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Field is required")]
        //[FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Allowed extensions are: jpg, jpeg and png")]
        public IFormFile PosterImage { get; set; }

        public RatingVM Rating { get; set; }

        public List<SneakerKeywordVM> Keywords { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string KeywordsString { get; set; }

    }
}
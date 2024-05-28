using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.ViewModels
{
    public class PostAddVm
    {
        [Required(ErrorMessage = "نام الزامی است .")]
        public string Title { get; set; }
        [Required(ErrorMessage = "محتوا الزامی است .")]
        public string Content { get; set; }
    }
}

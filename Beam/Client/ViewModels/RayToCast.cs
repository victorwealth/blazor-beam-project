using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beam.Client.ViewModels
{
    public class RayToCast
    {
        [Required(ErrorMessage = "You can't send an empty Ray!")]
        public string Text { get; set; } = "";
    }
}

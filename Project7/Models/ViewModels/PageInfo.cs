using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Models.ViewModels
{
    public class PageInfo
    {
        public int totalNumBooks { get; set; }
        public int booksPerPage { get; set; }
        public int currentPage { get; set; }

        // determine number of needed pages 
        public int totalPages => (int) Math.Ceiling((double) totalNumBooks / booksPerPage);
    }
}

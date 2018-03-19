using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler.Models
{
    public class ClassifyViewModel
    {
        public ClassifyViewModel()
        {
            DetailClassify = new List<DetailClassifyViewModel>();
        }
        public string ClassifyName { get; set; }
        public List<DetailClassifyViewModel> DetailClassify { get; set; }
    }
    public class DetailClassifyViewModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

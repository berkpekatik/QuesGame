using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noname
{
    public class QuestionModel
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string success { get; set; }
        public string failed { get; set; }
    }
}

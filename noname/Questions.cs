using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace noname
{
    public class Questions
    {
        WebClient client = new WebClient();
        public List<QuestionModel> GetAll()
        {
            try
            {
                var question = client.DownloadString("http://berkpekatik.com/questions.json");
                var model = JsonConvert.DeserializeObject<List<QuestionModel>>(question);
                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}

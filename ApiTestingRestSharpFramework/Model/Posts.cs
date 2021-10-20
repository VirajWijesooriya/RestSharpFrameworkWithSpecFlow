using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingRestSharpFramework.Model
{
    public class Posts
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public Posts()
        {

        }

        public Posts(int id, string title, string author)
        {
            this.id = id;
            this.title = title;
            this.author = author;
        }
    
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Menus
    {
        public int Id { get; set; }
        public int PId { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
        public string Remark { get; set; }
        public int IsEnable { get; set; }
    }
}

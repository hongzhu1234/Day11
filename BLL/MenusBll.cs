using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class MenusBll
    {
        MenusDal md = new MenusDal();
        public int Add(Menus menus)
        {
           return md.Add(menus);
        }

        public int Del(int id)
        {
            return md.Del(id);
        }

        public int Upt(Menus menus)
        {
            return md.Upt(menus);
        }

        public List<Menus> GetList()
        {
            return md.GetList();
        }
        public List<Menus> Paging(string name, int pindex, int psize, out int allcount)
        {
            return md.Paging(name, pindex, psize,out allcount);
        }

        public List<Menus> GetMenusByNo(string userID)
        {
            return md.GetMenusByNo(userID);
        }


        
    }
}

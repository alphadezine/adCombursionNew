using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADInternalNew.Core;
using ADInternalNew.DAL;

namespace ADInternalNew.Models
{
    public class ClientModel
    {
        AdmisInternalDataContext context;
        public ClientModel(AdmisInternalDataContext pcontext = null)
		{
			if (context == null)
			{
				context = new AdmisInternalDataContext();
			}
			else
			{
				context = pcontext;
			}
		}
        public List<User> GetClients(string term)
        {
            //var subquery = (from role in context.Roles where role.Role_Name=="Client" select role.Role_Id).Single();
            var result = (from client in context.Users
                          join role in context.User_To_Role_Mappings on client.User_Id equals role.User_Id
                          where (client.First_Name.ToLower().Contains(term.ToLower()) || client.Last_Name.ToLower().Contains(term.ToLower())) && role.Role_Id == Convert.ToInt32(Enums.Roles.Client)
                          select client).ToList();
            return result.ToList<User>();
        }
    }
}
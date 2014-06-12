using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Company
	{
		AdmisInternalDataContext context;
		public Tbl_Company(AdmisInternalDataContext pcontext = null)
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
		public int add(string Company_Name,string First_Contact_Name,int Internal_User_Id)
		{
			try{
				Company objCompany=new Company();
				objCompany.Company_Name=Company_Name;
				objCompany.First_Contact_Name=First_Contact_Name;
				objCompany.Internal_User_Id=Internal_User_Id;
				context.Companies.InsertOnSubmit(objCompany);
				context.SubmitChanges();
				return objCompany.User_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Id,string Company_Name,string First_Contact_Name,int Internal_User_Id)
		{
			try{
				Company objCompany = (from i in context.Companies where i.User_Id == User_Id select i).SingleOrDefault();
				if (objCompany != null)
				{
					objCompany.Company_Name=Company_Name;
					objCompany.First_Contact_Name=First_Contact_Name;
					objCompany.Internal_User_Id=Internal_User_Id;
					context.SubmitChanges();
					return true;
				}
				else
				{
					return false;
				}
 			}
			catch (Exception ex)
			{
				return false;
			}
		}
		 public Company selectOne(int User_Id)
		{
			try
			{
				return (from i in context.Companies where i.User_Id == User_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Company> selectAll()
		{
			try
			{
				return (from i in context.Companies  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


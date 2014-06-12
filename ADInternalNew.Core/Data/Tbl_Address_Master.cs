using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Address_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Address_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(string Address_Detail1,string Address_Detail2,int City_Id,string Zip_Code,int User_Id,int State_Id,int Country_Id)
		{
			try{
				Address_Master objAddress_Master=new Address_Master();
				objAddress_Master.Address_Detail1=Address_Detail1;
				objAddress_Master.Address_Detail2=Address_Detail2;
				objAddress_Master.City_Id=City_Id;
				objAddress_Master.Zip_Code=Zip_Code;
				objAddress_Master.User_Id=User_Id;
				objAddress_Master.State_Id=State_Id;
				objAddress_Master.Country_Id=Country_Id;
				context.Address_Masters.InsertOnSubmit(objAddress_Master);
				context.SubmitChanges();
				return objAddress_Master.Address_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Address_Id,string Address_Detail1,string Address_Detail2,int City_Id,string Zip_Code,int User_Id,int State_Id,int Country_Id)
		{
			try{
				Address_Master objAddress_Master = (from i in context.Address_Masters where i.Address_Id == Address_Id select i).SingleOrDefault();
				if (objAddress_Master != null)
				{
					objAddress_Master.Address_Detail1=Address_Detail1;
					objAddress_Master.Address_Detail2=Address_Detail2;
					objAddress_Master.City_Id=City_Id;
					objAddress_Master.Zip_Code=Zip_Code;
					objAddress_Master.User_Id=User_Id;
					objAddress_Master.State_Id=State_Id;
					objAddress_Master.Country_Id=Country_Id;
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
		 public Address_Master selectOne(int Address_Id)
		{
			try
			{
				return (from i in context.Address_Masters where i.Address_Id == Address_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Address_Master> selectAll()
		{
			try
			{
				return (from i in context.Address_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


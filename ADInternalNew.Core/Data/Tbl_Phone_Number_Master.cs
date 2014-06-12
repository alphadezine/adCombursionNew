using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Phone_Number_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Phone_Number_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(string Phone_Number,string Country_Code,string Phone_Ext,string Phone_Type)
		{
			try{
				Phone_Number_Master objPhone_Number_Master=new Phone_Number_Master();
				objPhone_Number_Master.Phone_Number=Phone_Number;
				objPhone_Number_Master.Country_Code=Country_Code;
				objPhone_Number_Master.Phone_Ext=Phone_Ext;
				objPhone_Number_Master.Phone_Type=Phone_Type;
				context.Phone_Number_Masters.InsertOnSubmit(objPhone_Number_Master);
				context.SubmitChanges();
				return objPhone_Number_Master.Phone_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Phone_Id,string Phone_Number,string Country_Code,string Phone_Ext,string Phone_Type)
		{
			try{
				Phone_Number_Master objPhone_Number_Master = (from i in context.Phone_Number_Masters where i.Phone_Id == Phone_Id select i).SingleOrDefault();
				if (objPhone_Number_Master != null)
				{
					objPhone_Number_Master.Phone_Number=Phone_Number;
					objPhone_Number_Master.Country_Code=Country_Code;
					objPhone_Number_Master.Phone_Ext=Phone_Ext;
					objPhone_Number_Master.Phone_Type=Phone_Type;
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
		 public Phone_Number_Master selectOne(int Phone_Id)
		{
			try
			{
				return (from i in context.Phone_Number_Masters where i.Phone_Id == Phone_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Phone_Number_Master> selectAll()
		{
			try
			{
				return (from i in context.Phone_Number_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


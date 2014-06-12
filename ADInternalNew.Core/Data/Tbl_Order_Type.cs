using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_Type
	{
		AdmisInternalDataContext context;
		public Tbl_Order_Type(AdmisInternalDataContext pcontext = null)
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
		public int add(string Order_Type_Name,int Level_Id)
		{
			try{
				Order_Type objOrder_Type=new Order_Type();
				objOrder_Type.Order_Type_Name=Order_Type_Name;
				objOrder_Type.Level_Id=Level_Id;
				context.Order_Types.InsertOnSubmit(objOrder_Type);
				context.SubmitChanges();
				return objOrder_Type.Order_Type_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_Type_Id,string Order_Type_Name,int Level_Id)
		{
			try{
				Order_Type objOrder_Type = (from i in context.Order_Types where i.Order_Type_Id == Order_Type_Id select i).SingleOrDefault();
				if (objOrder_Type != null)
				{
					objOrder_Type.Order_Type_Name=Order_Type_Name;
					objOrder_Type.Level_Id=Level_Id;
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
		 public Order_Type selectOne(int Order_Type_Id)
		{
			try
			{
				return (from i in context.Order_Types where i.Order_Type_Id == Order_Type_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_Type> selectAll()
		{
			try
			{
				return (from i in context.Order_Types  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


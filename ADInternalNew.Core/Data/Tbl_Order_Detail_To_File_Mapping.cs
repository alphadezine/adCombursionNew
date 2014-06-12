using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_Detail_To_File_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Order_Detail_To_File_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_To_User_Mapping_Id,int File_Id)
		{
			try{
				Order_Detail_To_File_Mapping objOrder_Detail_To_File_Mapping=new Order_Detail_To_File_Mapping();
				objOrder_Detail_To_File_Mapping.Order_To_User_Mapping_Id=Order_To_User_Mapping_Id;
				objOrder_Detail_To_File_Mapping.File_Id=File_Id;
				context.Order_Detail_To_File_Mappings.InsertOnSubmit(objOrder_Detail_To_File_Mapping);
				context.SubmitChanges();
				return objOrder_Detail_To_File_Mapping.Order_Detail_To_File_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_Detail_To_File_Mapping_Id,int Order_To_User_Mapping_Id,int File_Id)
		{
			try{
				Order_Detail_To_File_Mapping objOrder_Detail_To_File_Mapping = (from i in context.Order_Detail_To_File_Mappings where i.Order_Detail_To_File_Mapping_Id == Order_Detail_To_File_Mapping_Id select i).SingleOrDefault();
				if (objOrder_Detail_To_File_Mapping != null)
				{
					objOrder_Detail_To_File_Mapping.Order_To_User_Mapping_Id=Order_To_User_Mapping_Id;
					objOrder_Detail_To_File_Mapping.File_Id=File_Id;
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
		 public Order_Detail_To_File_Mapping selectOne(int Order_Detail_To_File_Mapping_Id)
		{
			try
			{
				return (from i in context.Order_Detail_To_File_Mappings where i.Order_Detail_To_File_Mapping_Id == Order_Detail_To_File_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_Detail_To_File_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Order_Detail_To_File_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


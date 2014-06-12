using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Payment_To_File_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Payment_To_File_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Payment_Id,int File_Id)
		{
			try{
				Payment_To_File_Mapping objPayment_To_File_Mapping=new Payment_To_File_Mapping();
				objPayment_To_File_Mapping.Payment_Id=Payment_Id;
				objPayment_To_File_Mapping.File_Id=File_Id;
				context.Payment_To_File_Mappings.InsertOnSubmit(objPayment_To_File_Mapping);
				context.SubmitChanges();
				return objPayment_To_File_Mapping.Payment_To_File_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Payment_To_File_Mapping_Id,int Payment_Id,int File_Id)
		{
			try{
				Payment_To_File_Mapping objPayment_To_File_Mapping = (from i in context.Payment_To_File_Mappings where i.Payment_To_File_Mapping_Id == Payment_To_File_Mapping_Id select i).SingleOrDefault();
				if (objPayment_To_File_Mapping != null)
				{
					objPayment_To_File_Mapping.Payment_Id=Payment_Id;
					objPayment_To_File_Mapping.File_Id=File_Id;
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
		 public Payment_To_File_Mapping selectOne(int Payment_To_File_Mapping_Id)
		{
			try
			{
				return (from i in context.Payment_To_File_Mappings where i.Payment_To_File_Mapping_Id == Payment_To_File_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Payment_To_File_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Payment_To_File_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


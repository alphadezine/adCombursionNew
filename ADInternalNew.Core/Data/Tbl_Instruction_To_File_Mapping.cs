using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Instruction_To_File_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Instruction_To_File_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Instruction_Id,int File_Id)
		{
			try{
				Instruction_To_File_Mapping objInstruction_To_File_Mapping=new Instruction_To_File_Mapping();
				objInstruction_To_File_Mapping.Instruction_Id=Instruction_Id;
				objInstruction_To_File_Mapping.File_Id=File_Id;
				context.Instruction_To_File_Mappings.InsertOnSubmit(objInstruction_To_File_Mapping);
				context.SubmitChanges();
				return objInstruction_To_File_Mapping.Instruction_To_File_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Instruction_To_File_Mapping_Id,int Instruction_Id,int File_Id)
		{
			try{
				Instruction_To_File_Mapping objInstruction_To_File_Mapping = (from i in context.Instruction_To_File_Mappings where i.Instruction_To_File_Mapping_Id == Instruction_To_File_Mapping_Id select i).SingleOrDefault();
				if (objInstruction_To_File_Mapping != null)
				{
					objInstruction_To_File_Mapping.Instruction_Id=Instruction_Id;
					objInstruction_To_File_Mapping.File_Id=File_Id;
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
		 public Instruction_To_File_Mapping selectOne(int Instruction_To_File_Mapping_Id)
		{
			try
			{
				return (from i in context.Instruction_To_File_Mappings where i.Instruction_To_File_Mapping_Id == Instruction_To_File_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Instruction_To_File_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Instruction_To_File_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


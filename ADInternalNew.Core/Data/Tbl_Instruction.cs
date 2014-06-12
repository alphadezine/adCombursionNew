using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Instruction
	{
		AdmisInternalDataContext context;
		public Tbl_Instruction(AdmisInternalDataContext pcontext = null)
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
		public int add(string Instruction_Value)
		{
			try{
				Instruction objInstruction=new Instruction();
				objInstruction.Instruction_Value=Instruction_Value;
				context.Instructions.InsertOnSubmit(objInstruction);
				context.SubmitChanges();
				return objInstruction.Instruction_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Instruction_Id,string Instruction_Value)
		{
			try{
				Instruction objInstruction = (from i in context.Instructions where i.Instruction_Id == Instruction_Id select i).SingleOrDefault();
				if (objInstruction != null)
				{
					objInstruction.Instruction_Value=Instruction_Value;
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
		 public Instruction selectOne(int Instruction_Id)
		{
			try
			{
				return (from i in context.Instructions where i.Instruction_Id == Instruction_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Instruction> selectAll()
		{
			try
			{
				return (from i in context.Instructions  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


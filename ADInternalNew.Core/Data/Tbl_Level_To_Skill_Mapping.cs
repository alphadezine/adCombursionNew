using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Level_To_Skill_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Level_To_Skill_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Level_Id,int Skill_Id)
		{
			try{
				Level_To_Skill_Mapping objLevel_To_Skill_Mapping=new Level_To_Skill_Mapping();
				objLevel_To_Skill_Mapping.Level_Id=Level_Id;
				objLevel_To_Skill_Mapping.Skill_Id=Skill_Id;
				context.Level_To_Skill_Mappings.InsertOnSubmit(objLevel_To_Skill_Mapping);
				context.SubmitChanges();
				return objLevel_To_Skill_Mapping.Level_To_Skill_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Level_To_Skill_Mapping_Id,int Level_Id,int Skill_Id)
		{
			try{
				Level_To_Skill_Mapping objLevel_To_Skill_Mapping = (from i in context.Level_To_Skill_Mappings where i.Level_To_Skill_Mapping_Id == Level_To_Skill_Mapping_Id select i).SingleOrDefault();
				if (objLevel_To_Skill_Mapping != null)
				{
					objLevel_To_Skill_Mapping.Level_Id=Level_Id;
					objLevel_To_Skill_Mapping.Skill_Id=Skill_Id;
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
		 public Level_To_Skill_Mapping selectOne(int Level_To_Skill_Mapping_Id)
		{
			try
			{
				return (from i in context.Level_To_Skill_Mappings where i.Level_To_Skill_Mapping_Id == Level_To_Skill_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Level_To_Skill_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Level_To_Skill_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


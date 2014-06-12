using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Skill
	{
		AdmisInternalDataContext context;
		public Tbl_Skill(AdmisInternalDataContext pcontext = null)
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
		public int add(string Skill_Name)
		{
			try{
				Skill objSkill=new Skill();
				objSkill.Skill_Name=Skill_Name;
				context.Skills.InsertOnSubmit(objSkill);
				context.SubmitChanges();
				return objSkill.Skill_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Skill_Id,string Skill_Name)
		{
			try{
				Skill objSkill = (from i in context.Skills where i.Skill_Id == Skill_Id select i).SingleOrDefault();
				if (objSkill != null)
				{
					objSkill.Skill_Name=Skill_Name;
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
		 public Skill selectOne(int Skill_Id)
		{
			try
			{
				return (from i in context.Skills where i.Skill_Id == Skill_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Skill> selectAll()
		{
			try
			{
				return (from i in context.Skills  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}


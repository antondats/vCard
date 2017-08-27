using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vCard.Models;

namespace vCard.Context
{
    public class EFRepository : IRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Skill> Skills
        {
            get { return context.Skills; }
        }

        public IEnumerable<Project> Projects
        {
            get { return context.Projects; }
        }

        public void SaveSkill(Skill skill)
        {
            if (skill.SkillID == 0)
                context.Skills.Add(skill);
            else
            {
                Skill temp = context.Skills.Find(skill.SkillID);
                if (temp != null)
                {
                    temp.Name = skill.Name;
                    temp.Category = skill.Category;
                    temp.Value = skill.Value;

                }
            }

            context.SaveChanges();

        }

        public void SaveProject(Project project)
        {
            if (project.ProjectID == 0)
                context.Projects.Add(project);
            else
            {
                Project temp = context.Projects.Find(project.ProjectID);
                if(temp != null)
                {
                    temp.Title = project.Title;
                    temp.Description = project.Description;
                    temp.Folder = project.Folder;
                }
            }
            context.SaveChanges();
        }

        public Skill DeleteSkill(int skillID)
        {
            Skill temp = context.Skills.Find(skillID);
            if(temp != null)
            {
                context.Skills.Remove(temp);
                context.SaveChanges();
            }
            return temp;
        }

        public Project DeleteProject(int projectID)
        {
            Project temp = context.Projects.Find(projectID);
            if(temp != null)
            {
                context.Projects.Remove(temp);
                context.SaveChanges();
            }
            return temp;
        }

    }
}
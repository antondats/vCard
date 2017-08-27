using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vCard.Models;

namespace vCard.Context
{
    public interface IRepository
    {
        IEnumerable<Skill> Skills { get; }
        IEnumerable<Project> Projects { get; }

        void SaveSkill(Skill skill);
        void SaveProject(Project project);
        Skill DeleteSkill(int skillID);
        Project DeleteProject(int projectID);
    }
}
